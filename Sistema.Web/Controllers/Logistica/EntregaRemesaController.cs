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
    public class EntregaRemesaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EntregaRemesaController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/EntregaRemesa/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EntregaRemesaViewModel>> Listar()
        {
            var rol = await _context.EntregaRemesa
                .Include(a => a.categoria).Include(a => a.usuario.categoria)
                .ToListAsync();

            return rol.Select(r => new EntregaRemesaViewModel
            {
                idEntregaRemesa = r.idEntregaRemesa,
                empleado = r.categoria.nombre_empleado,
                id_empleado = r.id_empleado,
                digitacion = r.digitacion,
                despacho = r.despacho,
                sobre = r.sobre,
                cantidad = r.cantidad,
                observacion = r.observacion,
                fecha = r.fecha,
                id_usuario = r.id_usuario,
                usuario =r.usuario.categoria.nombre_empleado
              
    });

        }

        // POST: api/EntregaRemesa/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fecha = DateTime.Now;
            EntregaRemesa entregaRemesa = new EntregaRemesa
            {

                id_empleado = model.id_empleado,
                digitacion = model.digitacion,
                despacho = model.despacho,
                sobre = model.sobre,
                cantidad = model.cantidad,
                observacion = model.observacion,
                id_usuario = model.id_usuario,
                fecha = fecha

            };




            try
            {
                _context.EntregaRemesa.Add(entregaRemesa);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        // PUT: api/EntregaRemesa/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idEntregaRemesa <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.EntregaRemesa.FirstOrDefaultAsync(c => c.idEntregaRemesa == model.idEntregaRemesa);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.observacion = model.observacion;

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