using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Logistica;
using Sistema.Web.Models.Logistica;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TareaController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Tarea/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VerTareaViewModel>> Listar()
        {
            var rol = await _context.Tarea.Include(a => a.turno).ToListAsync();

            return rol.Select(r => new VerTareaViewModel
            {
   
                idTarea = r.idTarea,
                turno = r.turno.nombre,
                idTurno = r.idTurno,
                nombre = r.nombre,
                fecha = r.fecha

    });

        }

        // POST: api/Tarea/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearTareaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fecha = DateTime.Now;
            Tarea tarea = new Tarea
            {

                idTurno = model.idTurno,
                nombre =  model.nombre,
                fecha = fecha

            };




            try
            {
                _context.Tarea.Add(tarea);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        // PUT: api/Tarea/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarTareaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idTarea <= 0)
            {
                return BadRequest();
            }

            var tarea = await _context.Tarea.FirstOrDefaultAsync(c => c.idTarea == model.idTarea);

            if (tarea == null)
            {
                return NotFound();
            }

            tarea.idTurno = model.idTurno;
            tarea.nombre = model.nombre;

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

    }
}