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
    public class TurnoController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TurnoController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Turno/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VerTurnoViewModel>> Listar()
        {
            var rol = await _context.Turno.ToListAsync();

            return rol.Select(r => new VerTurnoViewModel
            {
   
                idTurno = r.idTurno,
                nombre = r.nombre,
                estado = r.estado,
                fecha = r.fecha

            });

        }

        // POST: api/Turno/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearTurnoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fecha = DateTime.Now;
            Turno turno = new Turno
            {
                nombre =  model.nombre,
                estado = model.estado,
                fecha = fecha

            };

            try
            {
                _context.Turno.Add(turno);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        // PUT: api/Turno/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarTurnoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idTurno <= 0)
            {
                return BadRequest();
            }

            var turno = await _context.Turno.FirstOrDefaultAsync(c => c.idTurno == model.idTurno);

            if (turno == null)
            {
                return NotFound();
            }

            turno.nombre = model.nombre;
            turno.estado = model.estado;

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