using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sistema.Datos;
using Sistema.Entidades.Contactostp;
using Sistema.Web.Models.Contactostp;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactostpController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly IConfiguration _config;

        public ContactostpController(DbContextSistema context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Contactostp/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ContactostpViewModel>> Listar()
        {
            var usuario = _context.InfoContactos.ToList();
            //var usuario = await _context.Contactostp.Include(p => p.categoria).Include(p => p.categoria.cargo).Include(p => p.categoria.zona).ToListAsync();
            //var usuario = await _context.Usuarios.Include(u => u.rol).ToListAsync();

            return usuario.Select(u => new ContactostpViewModel
            {

                id_contactostp = u.id_contactostp,
                id_empleado = u.id_empleado,
                nombre = u.nombre,
                cargo = u.cargo,
                regional = u.regional,
                extension = u.extension,
                numero = u.numero,
                correo = u.correo,
                estado = u.estado 

            });

        }
        //// GET: api/Contactostp/Mostrar/1
        ////[Authorize(Roles = "Almacenero,Administrador")]
        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> Mostrar([FromRoute] int id)
        //{

        //    var contacto = await _context.Contactostp.
        //        SingleOrDefaultAsync(a => a.id_empleado == id);

        //    if (contacto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(new ContactostpViewModel
        //    {
        //        id_contactostp = contacto.id_contactostp,
        //        id_empleado = contacto.id_empleado,
        //        extension = contacto.extension,
        //        numero = contacto.numero,
        //        correo = contacto.correo,
        //        estado = contacto.estado
        //    });
        //}

        // POST: api/Contactostp/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contactotp contactotp = new Contactotp
            {

                id_contactostp = model.id_contactostp,
                id_empleado = model.id_empleado,
                extension = model.extension,
                numero = model.numero,
                correo = model.correo,
                estado = model.estado

            };

            _context.Contactostp.Add(contactotp);
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
        // PUT: api/Contactostp/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_contactostp <= 0)
            {
                return BadRequest();
            }

            var contactostp = await _context.Contactostp.FirstOrDefaultAsync(c => c.id_contactostp == model.id_contactostp);

            if (contactostp == null)
            {
                return NotFound();
            }
            contactostp.id_contactostp = model.id_contactostp;
            contactostp.id_empleado = model.id_empleado;
            contactostp.extension = model.extension;
            contactostp.numero = model.numero;
            contactostp.correo = model.correo;

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

        // DELETE: api/Contactostp/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var categoria = await _context.Contactostp.FindAsync(id);
            var categoria = await _context.Contactostp.FirstOrDefaultAsync(u => u.id_contactostp == id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Contactostp.Remove(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


            return Ok(categoria);
        }

        // PUT: api/Contactostp/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var contactotp = await _context.Contactostp.FirstOrDefaultAsync(u => u.id_contactostp == id);

            if (contactotp == null)
            {
                return NotFound();
            }

            contactotp.estado = 0;

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

        // PUT: api/Contactostp/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var contactotp = await _context.Contactostp.FirstOrDefaultAsync(u => u.id_contactostp == id);

            if (contactotp == null)
            {
                return NotFound();
            }

            contactotp.estado = 1;

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


        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.id_usuario == id);
        }
    }
}