using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Visitantes;
using Sistema.Web.Models.Encuesta;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EncuestaController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Encuesta/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EncuestaViewModel>> Listar()
        {
            var visitante = await _context.Encuesta.Include(c => c.categoria)
                .OrderByDescending(a => a.id_encuesta).Take(50).ToListAsync();

            return visitante.Select(r => new EncuestaViewModel
            {
                id = r.id_encuesta,
                id_empleado = r.id_empleado,
                nombre = r.categoria.nombre_empleado,
                temperatura = r.temperatura,
                fecha = r.fecha,
                firma = r.firma,

            });

        }

        // POST: api/Encuesta/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            var fechahora = DateTime.Now;
            // VALIDACION REGISTRO POR DIA
            //var Año = fechahora.Year;
            //var Mes = fechahora.Month;
            //var Dia = fechahora.Day;
            //DateTime Fecha = new DateTime(Año, Mes, Dia, 00, 00, 00);

            //var tempEncuesta = await _context.Encuesta
            //.Where(c => c.id_empleado == model.id_empleado &&  c.fecha > Fecha).ToListAsync();

            //if (tempEncuesta.Count > 0)
            //{
            //    return BadRequest("El empleado ya tiene un registro");
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           

            Encuesta crear = new Encuesta
            {

                id_empleado = model.id_empleado,
                fiebre = model.fiebre,
                fatiga = model.fatiga,
                tos = model.tos,
                dif_respirar = model.dif_respirar,
                vomito = model.vomito,
                diarrea = model.diarrea,
                cong_nasal = model.cong_nasal,
                dolor_garganta = model.dolor_garganta,
                escalofrio = model.escalofrio,
                dolor_muscular = model.dolor_muscular,
                otro = model.otro,
                contacto_externo = model.contacto_externo,
                otro_externo = model.otro_externo,
                temperatura = model.temperatura,
                transporte = model.transporte,
                edad_maxima = model.edad_maxima,
                hipertension = model.hipertension,
                diabetes = model.diabetes,
                cancer = model.cancer,
                enfer_corazon = model.enfer_corazon,
                pat_pulmonar = model.pat_pulmonar,
                renal = model.renal,
                inmunosupresion = model.inmunosupresion,
                obesidad = model.obesidad,
                corticoides = model.corticoides,
                fumador = model.fumador,
                desinfeccion = model.desinfeccion,
                fecha = fechahora,
                firma = model.firma,



            };

            _context.Encuesta.Add(crear);
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

        // GET: api/Encuesta/InformeEmpleado/1
        [HttpGet("[action]/{documento}")]

        public async Task<IEnumerable<EncuestaViewModel>> InformeEmpleado([FromRoute]  int documento)
        {

            var categoria = await _context.Encuesta.Include(c => c.categoria)
                  .Where(c => c.id_empleado == documento)
                  .ToListAsync();


            return categoria.Select(r => new EncuestaViewModel
            {
                id = r.id_encuesta,
                id_empleado = r.id_empleado,
                nombre = r.categoria.nombre_empleado,
                temperatura = r.temperatura,
                fecha = r.fecha,
                firma = r.firma,

            });
        }

        // GET: api/Encuesta/Informes/cedula/1/1
        [HttpGet("[action]/{cedula}/{finicial}/{ffinal}")]

        public async Task<IEnumerable<InformeViewModel>> Informes([FromRoute]  int cedula,string finicial, string ffinal)
        {

            DateTime fechainicial = Convert.ToDateTime(finicial);
            DateTime fechafinal = Convert.ToDateTime(ffinal);

            var categoria = await _context.Encuesta.Include(c => c.categoria)
                  .Where(c => cedula != 0 ? c.id_empleado == cedula : c.id_empleado != 0)
                  .Where(c => c.fecha >= fechainicial && c.fecha <= fechafinal)
                  .ToListAsync();


            return categoria.Select(c => new InformeViewModel
            {
                id_empleado = c.id_empleado,
                nombre = c.categoria.nombre_empleado,
                fiebre = c.fiebre,
                fatiga = c.fatiga,
                tos = c.tos,
                dif_respirar = c.dif_respirar,
                vomito = c.vomito,
                diarrea = c.diarrea,
                cong_nasal = c.cong_nasal,
                dolor_garganta = c.dolor_garganta,
                escalofrio = c.escalofrio,
                dolor_muscular = c.dolor_muscular,
                otro = c.otro,
                contacto_externo = c.contacto_externo,
                otro_externo = c.otro_externo,
                temperatura = c.temperatura,
                transporte = c.transporte,
                edad_maxima = c.edad_maxima,
                hipertension = c.hipertension,
                diabetes = c.diabetes,
                cancer = c.cancer,
                enfer_corazon = c.enfer_corazon,
                pat_pulmonar = c.pat_pulmonar,
                renal = c.renal,
                inmunosupresion = c.inmunosupresion,
                obesidad = c.obesidad,
                corticoides = c.corticoides,
                fumador = c.fumador,
                desinfeccion = c.desinfeccion,
                fecha = c.fecha.ToShortDateString(),

            });
        }

    }
}