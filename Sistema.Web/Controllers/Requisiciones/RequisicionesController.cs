using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;
using Sistema.Entidades.Requisiciones;
using Sistema.Web.Models.Requisicion;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicionesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RequisicionesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Requisiciones/Listar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<RequisicionViewModel>> Listar()
        {
            var requisicion = await _context.Requisicion
                //.Include(i => i.usuario.categoria)
                //.Include(i=>i.persona)
                //.OrderByDescending(i=>i.idrequisicion)
                .Take(100)
                .ToListAsync();

            return requisicion.Select(i => new RequisicionViewModel
            {
                idrequisicion = i.idrequisicion,
                id_zona = i.id_zona,
                fechasolicitud = i.fechasolicitud,
                fechacontratacion = i.fechacontratacion,
                usuario = i.usuario,
                id_cargo =i.id_cargo,
                causal = i.causal,
                reemplazo = i.reemplazo,
                estado = i.estado
            });

        }


        // GET: api/Requisiciones/ListarFiltro/texto
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<RequisicionViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var requisicion = await _context.Requisicion
                //.Include(i => i.usuario.categoria)
                //.Include(i => i.persona)
                //.Where(i=>i.num_comprobante.Contains(texto))
                //.OrderByDescending(i => i.idrequisicion)
                .ToListAsync();

            return requisicion.Select(i => new RequisicionViewModel
            {
                idrequisicion = i.idrequisicion,
                estado = i.estado
            });

        }

        // GET: api/Requisiciones/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var requisicion = await _context.Requisicion.FirstOrDefaultAsync(c => c.idrequisicion == id);

            if (requisicion == null)
            {
                return NotFound();
            }

            return Ok(new DetalleViewModel
            {
                idrequisicion = requisicion.idrequisicion,
                fechacontratacion = requisicion.fechacontratacion,
                usuario = requisicion.usuario,
                id_zona = requisicion.id_zona,
                id_cargo = requisicion.id_cargo,
                id_area = requisicion.id_area,
                causal = requisicion.causal,
                reemplazo = requisicion.reemplazo,
                observacion = requisicion.observacion,
                jefe = requisicion.jefe,
                tipo_contrato = requisicion.tipo_contrato,
                tiempo = requisicion.tiempo,
                funcion = requisicion.funcion,
                deberes = requisicion.deberes,
                estudios = requisicion.estudios,
                experiencia = requisicion.experiencia,
                edad_maxima = requisicion.edad_maxima,
                edad_minima = requisicion.edad_minima,
                sexo = requisicion.sexo,
                estadocivil = requisicion.estadocivil,
                contesturafisica = requisicion.contesturafisica,
                dviajar = requisicion.dviajar,
                vehiculo = requisicion.vehiculo,
                vivienda = requisicion.vivienda,
                cintelectual = requisicion.cintelectual,
                iniciativa = requisicion.iniciativa,
                apegoanormas = requisicion.apegoanormas,
                actividadfuerza = requisicion.actividadfuerza,
                manejoactividades = requisicion.manejoactividades,
                toleranciapresion = requisicion.toleranciapresion,
                vocacion = requisicion.vocacion,
                trabajoequipo = requisicion.trabajoequipo,
                basico = requisicion.basico,
                hed = requisicion.hed,
                bonificacion = requisicion.bonificacion,
                hen = requisicion.hen,
                rn = requisicion.rn,
                auxmovilizacion = requisicion.auxmovilizacion,
                subtransporte = requisicion.subtransporte,
                estado = requisicion.estado,
                dominical = requisicion.dominical,
                comision = requisicion.comision,
                rodamiento = requisicion.rodamiento,
                registro = requisicion.registro,
                areaestudio = requisicion.areaestudio,
                tiporuta = requisicion.tiporuta,
                tipovehiculo = requisicion.tipovehiculo,
                turnocargo = requisicion.turnocargo


    });


        }
        // PUT: api/Requisiciones/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrequisicion <= 0)
            {
                return BadRequest();
            }

            var requisicion = await _context.Requisicion.FirstOrDefaultAsync(c => c.idrequisicion == model.idrequisicion);

            if (requisicion == null)
            {
                return NotFound("XD");
            }

            requisicion.estado = model.estado;
            requisicion.basico = model.basico;
            requisicion.hed = model.hed;
            requisicion.bonificacion = model.bonificacion;
            requisicion.hen = model.hen;
            requisicion.rn = model.rn;
            requisicion.auxmovilizacion = model.auxmovilizacion;
            requisicion.subtransporte = model.subtransporte;
            requisicion.dominical = model.dominical;
            requisicion.comision = model.comision;
            requisicion.rodamiento = model.rodamiento;
            requisicion.registro = model.registro;



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

        // POST: api/Requisiciones/Crear
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
      

            Requisicion requisicion = new Requisicion
            {
                
                fechacontratacion = model.fechacontratacion,
                fechasolicitud= fechaHora,
                usuario = model.usuario,
                id_zona =model.id_zona,
                id_cargo =model.id_cargo,
                id_area = model.id_area,
                causal = model.causal,
                reemplazo = model.reemplazo,
                observacion = model.observacion,
                jefe = model.jefe,
                tipo_contrato = model.tipo_contrato,
                tiempo = model.tiempo,
                funcion = model.funcion,
                deberes = model.deberes,
                estudios = model.estudios,
                experiencia = model.experiencia,
                edad_maxima = model.edad_maxima,
                edad_minima = model.edad_minima,
                sexo = model.sexo,
                estadocivil = model.estadocivil,
                contesturafisica = model.contesturafisica,
                dviajar = model.dviajar,
                vehiculo = model.vehiculo,
                vivienda = model.vivienda,
                cintelectual = model.cintelectual,
                iniciativa = model.iniciativa,
                apegoanormas = model.apegoanormas,
                actividadfuerza = model.actividadfuerza,
                manejoactividades = model.manejoactividades,
                toleranciapresion = model.toleranciapresion,
                vocacion = model.vocacion,
                trabajoequipo = model.trabajoequipo,
                basico = model.basico,
                hed = model.hed,
                bonificacion = model.bonificacion,
                hen = model.hen,
                rn = model.rn,
                auxmovilizacion = model.auxmovilizacion,
                subtransporte = model.subtransporte,
                estado = model.estado,
                dominical = model.dominical,
                comision = model.comision,
                rodamiento = model.rodamiento,
                areaestudio = model.areaestudio,
                tiporuta = model.tiporuta,
                tipovehiculo = model.tipovehiculo,
                turnocargo = model.turnocargo

            };      

            
            try
            {
                _context.Requisicion.Add(requisicion);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                //return BadRequest();
                return BadRequest("aqui esta la mierda");
            }

            return Ok();
        }

        // PUT: api/Requisiciones/Desactivar/1
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Anular([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var requisicion = await _context.Requisicion.FirstOrDefaultAsync(c=>c.idrequisicion == id);

            if (requisicion == null)
            {
                return NotFound();
            }

            requisicion.estado = "1";

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


        private bool RequisicionExists(int id)
        {
            return _context.Requisicion.Any(e => e.idrequisicion == id);
        }
    }
}