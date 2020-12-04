using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Visitantes;
using Sistema.Web.Models.RegistroVisitantes;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVisitantesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RegistroVisitantesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Visitantes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VisitanteViewModel>> Listar()
        {
            var visitante = await _context.RegistroVisitante.Include(p => p.area).Include(p => p.visitante).ToListAsync();

            return visitante.Select(r => new VisitanteViewModel
            {
                idRegVisitante = r.idRegVisitante,
                id_visitante = r.id_visitante,
                nombre = r.visitante.apellido1+" "+r.visitante.apellido2+" "+r.visitante.nombre1,
                motivo =r.motivo,
                observacion =r.observacion,
                area = r.area.desc_area,
                fecha_ingreso = r.fecha_ingreso,
                fecha_salida = r.fecha_salida,
                estado = r.estado,
 
    });

        }

        // POST: api/Visitantes/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechahora = DateTime.Now;

            RegistroVisitante crear = new RegistroVisitante
            {

                id_visitante = model.id_visitante,
                motivo = model.motivo,
                observacion = model.observacion,
                id_area = model.id_area,
                fecha_ingreso = fechahora,
                fecha_salida = fechahora,
                estado = "ACTIVO",
     


            };

            _context.RegistroVisitante.Add(crear);
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


        // PUT: api/Visitantes/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idRegVisitante <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.RegistroVisitante.FirstOrDefaultAsync(c => c.idRegVisitante == model.idRegVisitante);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.id_visitante = model.id_visitante;
            categoria.motivo = model.motivo;
            categoria.observacion = model.observacion;
            categoria.id_area = model.id_area;

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

        // PUT: api/Visitantes/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var fechahora = DateTime.Now;

            var usuario = await _context.RegistroVisitante.FirstOrDefaultAsync(u => u.idRegVisitante == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.estado = "RETIRADO";
            usuario.fecha_salida = fechahora;

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


    }
}