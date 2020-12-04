using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Observacion;
using Sistema.Entidades.Registro;
using Sistema.Web.Models.Almacen.Observacion;
using Sistema.Web.Models.Almacen.Registro;


namespace Sistema.Web.Controllers
{
    //[Authorize(Roles = "Almacenero,Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroCallController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RegistroCallController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/RegistroCall/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<RegistroCallViewModel>> Listar()
        {
            var categoria = await _context.RegistroCall.Include(c => c.clientes)
           .Include(c => c.motivos).Include(c => c.extensiones).Include(c => c.municipio).Include(c => c.usuarios.categoria)
           .OrderByDescending(c => c.idregistro)
           .Take(100).ToListAsync();


            return categoria.Select(c => new RegistroCallViewModel
            {
                idregistro = c.idregistro,
                municipio= c.municipio.concat_municipio,
                id_municipio=c.id_municipio,
                cliente = c.clientes.nombre,
                telefono = c.clientes.telefono,
                idcliente=c.idcliente,
                documento = c.clientes.documento,
                nombrecliente = c.clientes.nombre,
                motivo = c.motivos.nombre,
                idmotivo=c.idmotivo,
                extension = c.extensiones.nombre,
                idextension=c.idextencion,
                remesa= c.remesa,
                ordencargue= c.ordencargue,
                transfiere = c.transfiere,
                fecha = c.fecha,
                estado = c.estado,
                usuario = c.usuarios.categoria.nombre_empleado,
                id_usuario=c.id_usuario
            });

        }
        // GET: api/RegistroCall/Informe/finicial/ffinal
        [HttpGet("[action]/{finicial}/{ffinal}")]
        public async Task<IEnumerable<RegistroCallInforme>> Informe([FromRoute] string finicial, string ffinal)
        {
            //DateTime fechaHora = DateTime.Now;
            //var Año = fechaHora.Year;
            //var Mes = fechaHora.Month;
            //DateTime Fecha = new DateTime(Año, Mes, 01, 00, 00, 00);
            DateTime fechainicial = Convert.ToDateTime(finicial);
            DateTime fechafinal = Convert.ToDateTime(ffinal);

            var categoria = await _context.Observacion.Include(c => c.registro.municipio)
           .Include(c => c.registro.clientes).Include(c => c.registro.motivos).Include(c => c.registro.extensiones)
           .Include(c => c.registro).Include(c => c.registro.usuarios.categoria)
           .Where(c => c.fecha >= fechainicial && c.fecha <= fechafinal).ToListAsync();


            return categoria.Select(c => new RegistroCallInforme
            {
                idregistro = c.idregistro,
                municipio = c.registro.municipio.concat_municipio,
                cliente = c.registro.clientes.nombre,
                telefono = c.registro.clientes.telefono,
                documento = c.registro.clientes.documento,
                motivo = c.registro.motivos.nombre,
                extension = c.registro.extensiones.nombre,
                remesa = c.registro.remesa,
                ordencargue = c.registro.ordencargue,
                transfiere = c.registro.transfiere,
                fecha = c.fecha.ToShortDateString(),
                hora = c.fecha.ToLongTimeString(),
                observacion = c.observacion,
                estado = c.registro.estado,
                usuario = c.registro.usuarios.categoria.nombre_empleado,
            });

        }

        // GET: api/RegistroCall/ListarFiltro/texto
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<RegistroCallViewModel>> ListarFiltro([FromRoute] string texto)
        {
            int numero = 0;
            int textoint = 0;

            if (int.TryParse(texto, out numero)) { numero = 1; textoint = Int32.Parse(texto); }

            var categoria = await _context.RegistroCall.Include(c => c.clientes)
           .Include(c => c.motivos).Include(c => c.extensiones).Include(c => c.municipio).Include(c => c.usuarios.categoria)
            .Where(c => numero != 1 ? c.clientes.nombre.Contains(texto) : c.clientes.documento.Contains(texto))
            .OrderByDescending(a => a.idregistro).ToListAsync();

            return categoria.Select(c => new RegistroCallViewModel
            {
                idregistro = c.idregistro,
                municipio = c.municipio.concat_municipio,
                id_municipio = c.id_municipio,
                cliente = c.clientes.nombre,
                telefono = c.clientes.telefono,
                idcliente = c.idcliente,
                documento = c.clientes.documento,
                motivo = c.motivos.nombre,
                idmotivo = c.idmotivo,
                extension = c.extensiones.nombre,
                idextension = c.idextencion,
                remesa = c.remesa,
                ordencargue = c.ordencargue,
                transfiere = c.transfiere,
                fecha = c.fecha,
                estado = c.estado,
                usuario = c.usuarios.categoria.nombre_empleado,
                id_usuario = c.id_usuario
            });

        }

        // GET: api/RegistroCall/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var categoria = await _context.RegistroCall.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new RegistroCallViewModel
            {
                idregistro = categoria.idregistro,
                cliente = categoria.clientes.nombre,
                motivo = categoria.motivos.nombre,
                extension = categoria.extensiones.nombre,
                remesa = categoria.remesa,
                ordencargue = categoria.ordencargue,
                transfiere = categoria.transfiere,
                fecha = categoria.fecha,
                estado = categoria.estado,
                //usuario = categoria.usuarios.categoria.nombre_empleado
            });
        }

        // PUT: api/RegistroCall/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idregistro <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.RegistroCall.FirstOrDefaultAsync(c => c.idregistro == model.idregistro);

            if (categoria == null)
            {
                return NotFound("XD");
            }

            categoria.estado = model.estado;


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
        // GET: api/Ingresos/ListarObservacion
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{idregistro}")]
        public async Task<IEnumerable<ObservacionViewModel>> ListarObservaciones([FromRoute] int idregistro)
        {
            var detalle = await _context.Observacion
                .Where(d => d.idregistro == idregistro)
                .ToListAsync();

            return detalle.Select(d => new ObservacionViewModel
            {
                idobservacion = d.idobservacion,
                idregistro = d.idregistro,
                observacion = d.observacion,
                fecha = d.fecha,
                usuario = d.usuario
            });

        }

        // POST: api/RegistroCall/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fecha = DateTime.Now;
            RegistroCall categoria = new RegistroCall
            {
                id_municipio = model.id_municipio,
                idcliente = model.idcliente,
                idmotivo = model.idmotivo,
                idextencion = model.idextencion,
                remesa = model.remesa,
                ordencargue = model.ordencargue,
                transfiere = model.transfiere,
                fecha = fecha,
                estado = model.estado,
                id_usuario = model.id_usuario
            };
            
            try
            {
                _context.RegistroCall.Add(categoria);
                await _context.SaveChangesAsync();

                var id = categoria.idregistro;
                foreach (var det in model.observaciones)
                {
                    ObservacionCall detalle = new ObservacionCall
                    {
                        idregistro = id,
                        observacion = det.observacion,
                        fecha = fecha,
                        usuario = det.usuario
                    };
                    _context.Observacion.Add(detalle);
                }
                await _context.SaveChangesAsync();
            }
            
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/RegistroCall/CrearObservacion
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearObservacion([FromBody] ObservacionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fecha = DateTime.Now;
            ObservacionCall articulo = new ObservacionCall
            {
                idregistro = model.idregistro,
                observacion = model.observacion,
                fecha = fecha,
                usuario = model.usuario,
                
            };

            _context.Observacion.Add(articulo);
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

        // DELETE: api/RegistroCall/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.RegistroCall.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.RegistroCall.Remove(categoria);
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

        private bool CategoriaExists(int id)
        {
            return _context.RegistroCall.Any(e => e.idmotivo == id);
        }
    }
}