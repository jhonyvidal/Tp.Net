using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.GestionHumnana;
using Sistema.Web.Models.GestionHumana;


namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ContratoController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Contrato/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VerContratoViewModel>> Listar()
        {
            var rol = await _context.Contrato
                //.Include(a => a.tarea).Include(a => a.tarea.turno)
                //.Where(a => a.id_estado != 3)
                .ToListAsync();

            return rol.Select(r => new VerContratoViewModel
            {
                id_contrato = r.id_contrato,
                cedula = r.cedula,
                nombre_empleado = r.nombre_empleado,
                id_cargo = r.id_cargo,
                id_zona = r.id_zona,
                fecha_ingreso = r.fecha_ingreso,
                fecha = r.fecha_ingreso.ToShortDateString(),
                duracion_contrato = r.duracion_contrato,
                periodo_prueba = r.periodo_prueba,
                proceso_sel = r.proceso_sel,
                compliance = r.compliance,
                visita_dom = r.visita_dom,
                ex_medico = r.ex_medico,
                poligrafo = r.poligrafo,
                hv = r.hv,
                licencia = r.licencia,
                cer_academica = r.cer_academica,
                car_laboral = r.car_laboral,
                car_personal = r.car_personal,
                id_eps = r.id_eps,
                id_afp = r.id_afp,
                id_arl = r.id_arl,
                fotografias = r.fotografias,
                cer_banco = r.cer_banco,
                id_estado = r.id_estado,
                id_proceso = r.id_proceso

            });

        }
        // GET: api/Contrato/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var contrato = await _context.Contrato.
            //Include(c => c.cargo).Include(c => c.estado).Include(c => c.zona).Include(c => c.municipio).Include(c => c.municipio).Include(c => c.afp).
            //Include(c => c.area).Include(c => c.eps).
            FirstOrDefaultAsync(c => c.id_contrato == id);


            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(new VerContratoViewModel
            {
                id_contrato = contrato.id_contrato,
                cedula = contrato.cedula,
                nombre_empleado = contrato.nombre_empleado,
                id_cargo = contrato.id_cargo,
                id_zona = contrato.id_zona,
                fecha_ingreso = contrato.fecha_ingreso,
                fecha = contrato.fecha_ingreso.ToLongDateString(),
                duracion_contrato = contrato.duracion_contrato,
                periodo_prueba = contrato.periodo_prueba,
                proceso_sel = contrato.proceso_sel,
                compliance = contrato.compliance,
                visita_dom = contrato.visita_dom,
                ex_medico = contrato.ex_medico,
                poligrafo = contrato.poligrafo,
                hv = contrato.hv,
                licencia = contrato.licencia,
                cer_academica = contrato.cer_academica,
                car_laboral = contrato.car_laboral,
                car_personal = contrato.car_personal,
                id_eps = contrato.id_eps,
                id_afp = contrato.id_afp,
                id_arl = contrato.id_arl,
                fotografias = contrato.fotografias,
                cer_banco = contrato.cer_banco,
                id_estado = contrato.id_estado,
                id_proceso = contrato.id_proceso,


                adress = contrato.adress,
                ruaf = contrato.ruaf,
                contrato = contrato.contrato,
                clausulas_adicionales = contrato.clausulas_adicionales,
                anexos_contrato = contrato.anexos_contrato,
                politicas = contrato.politicas,
                man_funciones = contrato.man_funciones,
                carnet = contrato.carnet,
                dotacion = contrato.dotacion,
                nomina_web = contrato.nomina_web,
                silogtran = contrato.silogtran,
                caja_compensacion = contrato.caja_compensacion,


                induccion = contrato.induccion,
                eva_per_prueba = contrato.eva_per_prueba,
                reinduccion = contrato.reinduccion,
                certificacion = contrato.certificacion,

            });
        }



        // POST: api/Contrato/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearContratoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fecha = DateTime.Now;
            Contrato Contrato = new Contrato
            {
                cedula = model.cedula,
                nombre_empleado = model.nombre_empleado,
                id_cargo = model.id_cargo,
                id_zona = model.id_zona,
                fecha_ingreso = model.fecha_ingreso,
                duracion_contrato = model.duracion_contrato,
                periodo_prueba = model.periodo_prueba,
                proceso_sel = model.proceso_sel,
                compliance = model.compliance,
                visita_dom = model.visita_dom,
                ex_medico = model.ex_medico,
                poligrafo = model.poligrafo,
                hv = model.hv,
                licencia = model.licencia,
                cer_academica = model.cer_academica,
                car_laboral = model.car_laboral,
                car_personal = model.car_personal,
                id_eps = model.id_eps,
                id_afp = model.id_afp,
                id_arl = model.id_arl,
                fotografias = model.fotografias,
                cer_banco = model.cer_banco,
                id_estado = 1,
                id_proceso = 1,
                fecha = fecha

            };

            try
            {
                _context.Contrato.Add(Contrato);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }



        // PUT: api/Contrato/ActualizarContratacion
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarContratacion([FromBody] ActualizarContratoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_contrato <= 0)
            {
                return BadRequest();
            }

            var contrato = await _context.Contrato.FirstOrDefaultAsync(c => c.id_contrato == model.id_contrato);

            if (contrato == null)
            {
                return NotFound();
            }

            contrato.adress = model.adress;
            contrato.ruaf = model.ruaf;
            contrato.contrato = model.contrato;
            contrato.clausulas_adicionales = model.clausulas_adicionales;
            contrato.anexos_contrato = model.anexos_contrato;
            contrato.politicas = model.politicas;
            contrato.man_funciones = model.man_funciones;
            contrato.carnet = model.carnet;
            contrato.dotacion = model.dotacion;
            contrato.nomina_web = model.nomina_web;
            contrato.silogtran = model.silogtran;
            contrato.caja_compensacion = model.caja_compensacion;
            contrato.id_proceso = 2;

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

        // PUT: api/Contrato/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_contrato <= 0)
            {
                return BadRequest();
            }

            var contrato = await _context.Contrato.FirstOrDefaultAsync(c => c.id_contrato == model.id_contrato);

            if (contrato == null)
            {
                return NotFound();
            }
            contrato.cedula = model.cedula;
            contrato.nombre_empleado = model.nombre_empleado;
            contrato.id_cargo = model.id_cargo;
            contrato.id_zona = model.id_zona;
            contrato.fecha_ingreso = model.fecha_ingreso;
            contrato.duracion_contrato = model.duracion_contrato;
            contrato.periodo_prueba = model.periodo_prueba;
            contrato.proceso_sel = model.proceso_sel;
            contrato.compliance = model.compliance;
            contrato.visita_dom = model.visita_dom;
            contrato.ex_medico = model.ex_medico;
            contrato.poligrafo = model.poligrafo;
            contrato.hv = model.hv;
            contrato.licencia = model.licencia;
            contrato.cer_academica = model.cer_academica;
            contrato.car_laboral = model.car_laboral;
            contrato.car_personal = model.car_personal;
            contrato.id_eps = model.id_eps;
            contrato.id_afp = model.id_afp;
            contrato.id_arl = model.id_arl;
            contrato.fotografias = model.fotografias;
            contrato.cer_banco = model.cer_banco;
            contrato.id_proceso = 1;

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

        // PUT: api/Contrato/ActualizarBienestar
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarBienestar([FromBody] ActualizarBienestarContratoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_contrato <= 0)
            {
                return BadRequest();
            }

            var contrato = await _context.Contrato.FirstOrDefaultAsync(c => c.id_contrato == model.id_contrato);

            if (contrato == null)
            {
                return NotFound();
            }

            contrato.induccion = model.induccion;
            contrato.eva_per_prueba = model.eva_per_prueba;
            contrato.reinduccion = model.reinduccion;
            contrato.certificacion = model.certificacion;
            contrato.id_proceso = 3;

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

        // PUT: api/Contrato/Activar/5/5
        [HttpPut("[action]/{id}/{estado}")]
        public async Task<IActionResult> Activar([FromRoute] int id,int estado)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var contrato = await _context.Contrato.FirstOrDefaultAsync(c => c.id_contrato == id);

            if (contrato == null)
            {
                return NotFound();
            }

            contrato.id_estado = estado;

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