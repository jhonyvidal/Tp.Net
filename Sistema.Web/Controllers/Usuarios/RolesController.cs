using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Web.Models.Permisos.Rol;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RolesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Listar()
        {
            var rol = await _context.Roles.ToListAsync();

            return rol.Select(r => new RolViewModel
            {
                id_perfil = r.id_perfil,
                desc_perfil = r.desc_perfil,
                estado = r.estado

            });

        }
        // GET: api/Roles/ListaGrupos/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<GrupoViewModel>> ListaGrupos([FromRoute] int id)
        {
            var rol = await _context.Grupos.Include(c => c.pagina)
                .Where(c => c.id_perfil == id).ToListAsync();

            return rol.Select(r => new GrupoViewModel
            {
                id_grupo = r.id_grupo,
                nombre = r.pagina.nombre,
                descripcion = r.pagina.descripcion,
                tipopagina = r.pagina.tipopagina,
                fecha = r.fecha.ToShortDateString(),


            });

        }

        // GET: api/Roles/ListaPaginas
        [HttpGet("[action]")]
        public async Task<IEnumerable<PaginaViewModel>> ListaPaginas()
        {
            var rol = await _context.Paginas.ToListAsync();

            return rol.Select(r => new PaginaViewModel
            {
                id_pagina = r.id_pagina,
                nombre = r.descripcion,
                tipopagina = r.tipopagina

            });

        }

        // POST: api/Roles/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            var consecutivo = await _context.Roles.Take(1).OrderByDescending(a => a.id_perfil).FirstOrDefaultAsync(u => u.id_perfil != 0);
         
            //var consecutivo = await _context.Roles.FirstOrDefaultAsync(u => u.id_perfil == u.id_perfil);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rol grupo = new Rol
            {
                id_perfil = consecutivo.id_perfil+1,
                desc_perfil = model.desc_perfil,
                estado = 1
            };

            _context.Roles.Add(grupo);
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
        // PUT: api/Roles/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_perfil <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Roles.FirstOrDefaultAsync(c => c.id_perfil == model.id_perfil);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.desc_perfil = model.desc_perfil;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }
        // POST: api/Roles/Adicionar
        [HttpPost("[action]")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechahora = DateTime.Now;
            var a = model.id_perfil.ToString();
            var b = model.id_pagina.ToString();
            var c = a+b;

            Grupo grupo = new Grupo
            {
                id_perfil = model.id_perfil,
                id_pagina = model.id_pagina,
                fecha = fechahora,
                indice = Int32.Parse(c),

            };

            _context.Grupos.Add(grupo);
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


        // DELETE: api/Roles/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Grupos.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Grupos.Remove(categoria);
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
    }
}