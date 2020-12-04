using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Motivo;
using Sistema.Web.Models.Almacen.Motivo;

namespace Sistema.Web.Controllers
{
    //[Authorize(Roles = "Almacenero,Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class MotivosCallController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public MotivosCallController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/MotivosCall/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<MotivosCallViewModel>> Listar()
        {
            var categoria = await _context.MotivosCall.ToListAsync();

            return categoria.Select(c => new MotivosCallViewModel
            {
                idmotivo = c.idmotivo,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });

        }

        // GET: api/MotivosCall/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var categoria = await _context.MotivosCall.Where(c=>c.condicion==true).ToListAsync();

            return categoria.Select(c => new SelectViewModel
            {
                idmotivo = c.idmotivo,
                nombre = c.nombre
            });

        }

        // GET: api/MotivosCall/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var categoria = await _context.MotivosCall.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new MotivosCallViewModel
            {
                idmotivo = categoria.idmotivo,
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

            if (model.idmotivo <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.MotivosCall.FirstOrDefaultAsync(c => c.idmotivo == model.idmotivo);

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

        // POST: api/MotivosCall/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MotivosCall categoria = new MotivosCall
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            };

            _context.MotivosCall.Add(categoria);
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

        // DELETE: api/MotivosCall/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.MotivosCall.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.MotivosCall.Remove(categoria);
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

        // PUT: api/MotivosCall/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.MotivosCall.FirstOrDefaultAsync(c => c.idmotivo == id);

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

        // PUT: api/MotivosCall/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.MotivosCall.FirstOrDefaultAsync(c => c.idmotivo == id);

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
            return _context.MotivosCall.Any(e => e.idmotivo == id);
        }
    }
}