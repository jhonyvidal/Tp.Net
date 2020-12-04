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
    public class CorrespondenciaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CorrespondenciaController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Correspondencia/Listar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<CorrespondenciaViewModel>> Listar()
        {
            var correspondencia = await _context.Correspondencia
                .Include(c => c.destinatario.categoria).Include(c => c.remitente)
                .Include(c => c.TipoDocumento)
                .OrderByDescending(a => a.id_correspondencia).Take(100).ToListAsync();

            return correspondencia.Select(a => new CorrespondenciaViewModel
            {
                id_correspondencia = a.id_correspondencia,
                id_remitente = a.id_remitente,
                documento = a.remitente.documento,
                remitente = a.remitente.nombre,
                id_usuario = a.id_usuario,
                destinatario = a.destinatario.categoria.nombre_empleado,
                id_tipodocumento = a.id_tipodocumento,
                tipodocumento = a.TipoDocumento.nombre,
                desdoc = a.desdoc,
                prioridad = a.TipoDocumento.prioridad,
                plazo = a.TipoDocumento.fecha_plazo,
                usuario = a.usuario,
                fecha_ingreso = a.fecha_ingreso,
                fecha_cumplido = a.fecha_cumplido,
                folios = a.folios,
                anexos = a.anexos,
                estado = a.estado,
            });

        }
        // GET: api/Correspondencia/Informe
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<CorrespondenciaViewModel>> Informe()
        {
            var correspondencia = await _context.Correspondencia
                .Include(c => c.destinatario.categoria).Include(c => c.remitente)
                .Include(c => c.TipoDocumento)
                .OrderByDescending(a => a.id_correspondencia).ToListAsync();

            return correspondencia.Select(a => new CorrespondenciaViewModel
            {
                id_correspondencia = a.id_correspondencia,
                id_remitente = a.id_remitente,
                remitente = a.remitente.nombre,
                id_usuario = a.id_usuario,
                destinatario = a.destinatario.categoria.nombre_empleado,
                id_tipodocumento = a.id_tipodocumento,
                tipodocumento = a.TipoDocumento.nombre,
                desdoc = a.desdoc,
                prioridad = a.TipoDocumento.prioridad,
                plazo = a.TipoDocumento.fecha_plazo,
                usuario = a.usuario,
                fecha_ingreso = a.fecha_ingreso,
                fecha_cumplido = a.fecha_cumplido,
                folios = a.folios,
                anexos = a.anexos,
                estado = a.estado,
            });

        }

        // GET: api/Permisos/Listado/id
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<CorrespondenciaViewModel>> Listado([FromRoute] int id)
        {

            var correspondencia = await _context.Correspondencia
               .Include(c => c.destinatario.categoria).Include(c => c.remitente)
               .Include(c => c.TipoDocumento)
                //.Where(p => p.jefe_inmediato.Contains(id))
                .Where(p => p.id_usuario == id)
                .OrderByDescending(a => a.id_correspondencia).Take(100).ToListAsync();

            return correspondencia.Select(a => new CorrespondenciaViewModel

            {
                id_correspondencia = a.id_correspondencia,
                id_remitente = a.id_remitente,
                remitente = a.remitente.nombre,
                id_usuario = a.id_usuario,
                destinatario = a.destinatario.categoria.nombre_empleado,
                id_tipodocumento = a.id_tipodocumento,
                tipodocumento = a.TipoDocumento.nombre,
                desdoc =a.desdoc,
                prioridad = a.TipoDocumento.prioridad,
                plazo = a.TipoDocumento.fecha_plazo,
                usuario = a.usuario,
                fecha_ingreso = a.fecha_ingreso,
                fecha_cumplido = a.fecha_cumplido,
                folios =a.folios,
                anexos =a.anexos,
                estado = a.estado,

            });

        }
        // GET: api/Correspondencia/ListarObservaciones/id
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id_correspondencia}")]
        public async Task<IEnumerable<ObservacionViewModel>> ListarObservaciones([FromRoute] int id_correspondencia)
        {
            var detalle = await _context.ObservacionCor
                .Where(d => d.id_correspondencia == id_correspondencia)
                .ToListAsync();

            return detalle.Select(d => new ObservacionViewModel
            {
                idobservacion = d.idobservacion,
                id_correspondencia = d.id_correspondencia,
                cambio_estado = d.cambio_estado,
                observacion = d.observacion,
                fecha = d.fecha,
                usuario = d.usuario
            });

        }

        // GET: api/Correspondencia/Mostrar/1
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var correspondencia = await _context.Correspondencia.
                SingleOrDefaultAsync(a => a.id_correspondencia == id);

            if (correspondencia == null)
            {
                return NotFound();
            }

            return Ok(new CorrespondenciaViewModel
            {
                id_correspondencia = correspondencia.id_correspondencia,
                id_remitente = correspondencia.id_remitente,
                id_usuario = correspondencia.id_usuario,
                id_tipodocumento = correspondencia.id_tipodocumento,
                desdoc = correspondencia.desdoc,
                usuario = correspondencia.usuario,
                fecha_ingreso = correspondencia.fecha_ingreso,
                fecha_cumplido = correspondencia.fecha_cumplido,
                folios = correspondencia.folios,
                anexos = correspondencia.anexos,
                estado = correspondencia.estado,
            });
        }

        // PUT: api/Correspondencia/Actualizar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_correspondencia <= 0)
            {
                return BadRequest();
            }

            var correspondencia = await _context.Correspondencia.FirstOrDefaultAsync(a => a.id_correspondencia == model.id_correspondencia);

            if (correspondencia == null)
            {
                return NotFound();
            }

            correspondencia.id_remitente = model.id_remitente;
            correspondencia.id_usuario = model.id_usuario;
            correspondencia.id_tipodocumento = model.id_tipodocumento;
            correspondencia.desdoc = model.desdoc;
            correspondencia.usuario = model.usuario;
            //correspondencia.fecha_ingreso = model.fecha_ingreso;
            correspondencia.fecha_cumplido = model.fecha_cumplido;
            correspondencia.folios = model.folios;
            correspondencia.anexos = model.anexos;
            correspondencia.estado = "ASIGNADO";

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
        // POST: api/Correspondencia/CrearObservacion
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearObservacion([FromBody] ObservacionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fecha = DateTime.Now;
            ObservacionCor articulo = new ObservacionCor
            {
                id_correspondencia = model.id_correspondencia,
                observacion = model.observacion,
                cambio_estado = model.cambio_estado,
                fecha = fecha,
                usuario = model.usuario,

            };

            _context.ObservacionCor.Add(articulo);
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

        // POST: api/Correspondencia/Crear
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechahora = DateTime.Now;

            correspondencia Correspondencia = new correspondencia
            {
                id_remitente = model.id_remitente,
                id_usuario = model.id_usuario,
                id_tipodocumento = model.id_tipodocumento,
                desdoc = model.desdoc,
                usuario = model.usuario,
                fecha_ingreso = fechahora,
                fecha_cumplido = model.fecha_cumplido,
                folios = model.folios,
                anexos = model.anexos,
                estado = "GENERADO"
            };

            
            try
            {
                _context.Correspondencia.Add(Correspondencia);
                await _context.SaveChangesAsync();

                var id = Correspondencia.id_correspondencia;
                 foreach (var det in model.observaciones)
                {
                    ObservacionCor detalle = new ObservacionCor
                    {
                        id_correspondencia = id,
                        observacion = det.observacion,
                        cambio_estado= det.cambio_estado,
                        fecha = fechahora,
                        usuario = det.usuario
                    };
                    _context.ObservacionCor.Add(detalle);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Correspondencia/Cumplir/5/Estado
        [HttpPut("[action]/{id}/{estado}")]
        public async Task<IActionResult> Cumplir([FromRoute] int id, string estado)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var correspondencia = await _context.Correspondencia.FirstOrDefaultAsync(c => c.id_correspondencia == id);

            if (correspondencia == null)
            {
                return NotFound();
            }

            correspondencia.estado = estado;

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


        private bool CorrespondenciaExists(int id)
        {
            return _context.Correspondencia.Any(e => e.id_correspondencia == id);
        }
    }
}