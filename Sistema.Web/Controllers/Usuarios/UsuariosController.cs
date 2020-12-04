using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;
using Sistema.Web.Models.Permisos.Usuario;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly IConfiguration _config;

        public UsuariosController(DbContextSistema context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [Authorize(Roles = "1")]
        // GET: api/Usuarios/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var usuario = await _context.Usuarios.Include(p => p.categoria)
                .Include(p => p.categoria.cargo).Include(p => p.categoria.area).ToListAsync();
            //var usuario = await _context.Usuarios.Include(u => u.rol).ToListAsync();

            return usuario.Select(u => new UsuarioViewModel
            {

                id_usuario = u.id_usuario,
                nombre = u.categoria.nombre_empleado,
                regional = u.categoria.area.desc_area,
                cargo = u.categoria.cargo.desc_cargo,
                id_perfil = u.id_perfil,
                estado = u.estado,
                clave = u.clave,
                correo = u.correo

            });

        }
        //// GET: api/Usuarios/Mostrar/1
        ////[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var contacto = await _context.Usuarios.
                Include(c => c.categoria).Include(c => c.rol).Include(c => c.categoria.zona).Include(c => c.categoria.cargo).
                SingleOrDefaultAsync(a => a.id_empleado == id);

            if (contacto == null)
            {
                return NotFound();
            }

            return Ok(new UsuarioViewModel
            {
                correo = contacto.correo,
                id_usuario = contacto.id_usuario,
                nombre = contacto.categoria.nombre_empleado,
                rol = contacto.rol.desc_perfil,
                regional = contacto.categoria.zona.desc_zona,
                cargo = contacto.categoria.cargo.desc_cargo,


            });
        }

        // POST: api/Usuarios/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Newusuario = model.id_usuario;

            if (await _context.Usuarios.AnyAsync(u => u.id_usuario == Newusuario))
            {
                return BadRequest("El Usuario ya existe");
            }

            Usuario usuario = new Usuario
            {
                id_usuario = model.id_usuario,
                clave = model.clave,
                correo = model.correo,
                id_empleado = model.id_empleado,
                id_perfil = model.id_perfil,
                estado = model.estado
                //id_zona = model.id_zona
 
            };

            _context.Usuarios.Add(usuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }


        // PUT: api/Articulos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_usuario <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.id_usuario == model.id_usuario);

            if (usuario == null)
            {
                return NotFound();
            }
            usuario.id_usuario = model.id_usuario;
            usuario.clave = model.clave;
            usuario.correo = model.correo;
            usuario.id_empleado = model.id_empleado;
            usuario.id_perfil = model.id_perfil;
            //usuario.id_zona = model.id_zona;
            //usuario.id_zona = model.estado;


            // if (model.act_password == true)
            //{
            //  CrearPasswordHash(model.password, out byte[] passwordHash, out byte[] passwordSalt);
            // usuario.password_hash = passwordHash;
            //usuario.password_salt = passwordSalt;
            //}

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        //private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
       // {
            //using (var hmac = new System.Security.Cryptography.HMACSHA512())
            //{
             //   passwordSalt = hmac.Key;
             //  passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            //}

        //}

        // PUT: api/Usuarios/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.id_usuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.estado = 0;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Usuarios/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.id_usuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.estado = 1;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/Usuarios/CambioClave
        [HttpPut("[action]")]
        public async Task<IActionResult> CambioClave([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_usuario <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.id_usuario == model.id_usuario);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.clave = model.clave;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var id_usuario = model.id_usuario;

           
            var usuario = await _context.Usuarios.Include(c => c.categoria).FirstOrDefaultAsync(u => u.id_usuario == id_usuario);
            //var categoria = await _context.Categorias.FirstOrDefaultAsync(u => u.id_empleado == id_usuario);


            if (usuario == null)
            {
                //return BadRequest("EL usuario No existe");
                return BadRequest("Usuario o contraseña Incorrectos");
            }

            if (model.clave != usuario.clave)
            {
                //return BadRequest("Contraseña Incorrecta");
                return BadRequest("Usuario o contraseña Incorrectos");
            }

            if (usuario.estado == 0)
            {
                //return BadRequest("El Usuario Se encuentra inactivo");
                return BadRequest("Usuario o contraseña Incorrectos");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.id_usuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.id_perfil.ToString() ),
                new Claim("id_usuario", usuario.id_usuario.ToString() ),
                new Claim("id_zona", usuario.id_zona.ToString() ),
                new Claim("rol", usuario.id_perfil.ToString() ),
                new Claim("nombre", usuario.categoria.nombre_empleado )
            };

            return Ok(
                    new { token = GenerarToken(claims) }
                );

        }


        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.id_usuario == id);
        }
    }
}