using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Extension;
using Sistema.Web.Models.Almacen.Extension;

namespace Sistema.Web.Controllers
{
    //[Authorize(Roles = "Almacenero,Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExtensionCallController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ExtensionCallController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/ExtensionCall/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<ExtensionCallViewModel>> Listar()
        {
            var categoria = await _context.ExtensionCall.ToListAsync();

            return categoria.Select(c => new ExtensionCallViewModel
            {
                idextencion = c.idextencion,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });

        }

        // GET: api/ExtensionCall/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var categoria = await _context.ExtensionCall.Where(c=>c.condicion==true).ToListAsync();

            return categoria.Select(c => new SelectViewModel
            {
                idextencion = c.idextencion,
                nombre = c.nombre
            });

        }

        // GET: api/ExtensionCall/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var categoria = await _context.ExtensionCall.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new ExtensionCallViewModel
            {
                idextencion = categoria.idextencion,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion,
                condicion = categoria.condicion
            });
        }

        // PUT: api/MotivosCall/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idextencion <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.ExtensionCall.FirstOrDefaultAsync(c => c.idextencion == model.idextencion);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = model.nombre;
            categoria.descripcion = model.descripcion;

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

        // POST: api/ExtensionCall/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExtensionCall categoria = new ExtensionCall
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            };

            _context.ExtensionCall.Add(categoria);
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

        // DELETE: api/ExtensionCall/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.ExtensionCall.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.ExtensionCall.Remove(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }           

            return Ok(categoria);
        }

        // PUT: api/ExtensionCall/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.ExtensionCall.FirstOrDefaultAsync(c => c.idextencion == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = false;

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

        // PUT: api/ExtensionCall/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.ExtensionCall.FirstOrDefaultAsync(c => c.idextencion == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = true;

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

        private bool CategoriaExists(int id)
        {
            return _context.ExtensionCall.Any(e => e.idextencion == id);
        }
    }
}