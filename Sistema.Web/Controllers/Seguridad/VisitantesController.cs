using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Visitantes;
using Sistema.Web.Models.Visitantes;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitantesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public VisitantesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Visitantes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VisitanteViewModel>> Listar()
        {
            //var visitante = await _context.Visitante.Include(p => p.area).ToListAsync();
            var visitante = await _context.Visitante.ToListAsync();

            return visitante.Select(r => new VisitanteViewModel
            {
                id_visitante = r.id_visitante,
                tipodocumento = r.tipodocumento,
                documento =r.documento,
                apellido1 =r.apellido1,
                apellido2 =r.apellido2,
                nombre1 = r.nombre1,
                nombre2 =r.nombre2,
                sexo =r.sexo,
                fecha_nacimiento =r.fecha_nacimiento,
                rh =r.rh,
                arl = r.arl,
                id_eps = r.id_eps,
                estado = r.estado,
                observacion= r.observacion,
                tipo_vehiculo = r.tipo_vehiculo,
                placa = r.placa,


             });

        }
        // GET: api/Visitantes/ConsecutivoVisitante
        [HttpGet("[action]")]
        public async Task<IEnumerable<VisitanteViewModel>> ConsecutivoVisitante()
        {

            var permiso = await _context.Visitante
            .OrderByDescending(a => a.id_visitante)
            .Take(1)
            .ToListAsync();

            return permiso.Select(p => new VisitanteViewModel
            {

                id_visitante = p.id_visitante + 1,

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

            Visitante crear = new Visitante
            {

                tipodocumento = model.tipodocumento,
                documento = model.documento,
                apellido1 = model.apellido1,
                apellido2 = model.apellido2,
                nombre1 = model.nombre1,
                nombre2 = model.nombre2,
                sexo = model.sexo,
                fecha_nacimiento = model.fecha_nacimiento,
                rh = model.rh,
                arl = model.arl,
                id_eps = model.id_eps,
                observacion = model.observacion,
                tipo_vehiculo = model.tipo_vehiculo,
                placa = model.placa,
                img = model.img,
                estado = "ACTIVO",

            };

            _context.Visitante.Add(crear);
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

        // GET: api/Visitante/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] string id)
        {

            var categoria = await _context.Visitante.FirstOrDefaultAsync(c => c.documento == id);


            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new VisitanteViewModel
            {
                id_visitante =categoria.id_visitante,

            });
        }

        // PUT: api/Visitantes/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_visitante <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Visitante.FirstOrDefaultAsync(c => c.id_visitante == model.id_visitante);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.tipodocumento = model.tipodocumento;
            categoria.documento = model.documento;
            categoria.apellido1 = model.apellido1;
            categoria.apellido2 = model.apellido2;
            categoria.nombre1 = model.nombre1;
            categoria.nombre2 = model.nombre2;
            categoria.sexo = model.sexo;
            categoria.fecha_nacimiento = model.fecha_nacimiento;
            categoria.rh = model.rh;
            categoria.arl = model.arl;
            categoria.id_eps = model.id_eps;
            categoria.observacion = model.observacion;
            categoria.tipo_vehiculo = model.tipo_vehiculo;
            categoria.placa = model.placa;



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