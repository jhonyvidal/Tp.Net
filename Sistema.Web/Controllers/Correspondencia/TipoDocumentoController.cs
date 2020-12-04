using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Correspondencia;
using Sistema.Web.Models.Correspondencia;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TipoDocumentoController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/TipoDocumento/Listar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoDocumentoViewModel>> Listar()
        {
            var tipoDocumento = await _context.TipoDocumento.ToListAsync();

            return tipoDocumento.Select(a => new TipoDocumentoViewModel
            {
                id_tipodocumento = a.id_tipodocumento,
                nombre = a.nombre,
                prioridad = a.prioridad,
                fecha_plazo = a.fecha_plazo,
                condicion = a.condicion,
            });

        }

        // GET: api/Remitente/Mostrar/1
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var tipoDocumento = await _context.TipoDocumento.
                SingleOrDefaultAsync(a => a.id_tipodocumento == id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return Ok(new TipoDocumentoViewModel
            {
                nombre = tipoDocumento.nombre,
                prioridad = tipoDocumento.prioridad,
                fecha_plazo = tipoDocumento.fecha_plazo,
                condicion = tipoDocumento.condicion,
            });
        }

        // PUT: api/Remitente/Actualizar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarTipoDocumentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_tipodocumento <= 0)
            {
                return BadRequest();
            }

            var tipoDocumento = await _context.TipoDocumento.FirstOrDefaultAsync(a => a.id_tipodocumento == model.id_tipodocumento);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            tipoDocumento.nombre = model.nombre;
            tipoDocumento.prioridad = model.prioridad;
            tipoDocumento.fecha_plazo = model.fecha_plazo;

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

        // POST: api/TipoDocumento/Crear
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearTipoDocumentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoDocumento tipoDocumento = new TipoDocumento
            {
                nombre = model.nombre,
                //condicion = model.condicion,

            };

            _context.TipoDocumento.Add(tipoDocumento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/TipoDocumento/Desactivar/1
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tipoDocumento = await _context.TipoDocumento.FirstOrDefaultAsync(a => a.id_tipodocumento == id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            tipoDocumento.condicion = false;

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

        // PUT: api/Remitente/Activar/1
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tipoDocumento = await _context.TipoDocumento.FirstOrDefaultAsync(a => a.id_tipodocumento == id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            tipoDocumento.condicion = true;

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



        private bool TipoDocumentoExists(int id)
        {
            return _context.TipoDocumento.Any(e => e.id_tipodocumento == id);
        }
    }
}