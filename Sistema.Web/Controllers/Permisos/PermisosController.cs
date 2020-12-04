using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Permisos;
using Sistema.Web.Models.Permisos;


namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PermisosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Permisos/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<PermisosViewModel>> Listar()
        {
        
            var permisos = await _context.Permisos.Include(p => p.categoria).Include(p => p.categoria.cargo).OrderByDescending(a => a.id_permiso).Take(100).ToListAsync();

            return permisos.Select(p => new PermisosViewModel
             
            {   
                id_permiso = p.id_permiso,
                nombre = p.categoria.nombre_empleado,
                regional = p.categoria.id_zona,
                cargo = p.categoria.cargo.desc_cargo,
                id_empleado = p.id_empleado,
                id_clasificapermiso = p.id_clasificapermiso,
                fecha_registro = p.fecha_registro,
                por_hora = p.por_hora,
                por_dia = p.por_dia,
                fec_inicio = p.fec_inicio,
                fec_final = p.fec_final,
                hora_inicio = p.hora_inicio,
                hora_fin = p.hora_fin,
                hrs_permiso = p.hrs_permiso,
                dcto_nomina = p.dcto_nomina,
                dcto_vacaciones = p.dcto_vacaciones,
                jefe_inmediato = p.jefe_inmediato,
                dir_nalgh =p.dir_nalgh,
                estado = p.estado,
                motivo_permiso = p.motivo_permiso,
                id_reemplaza = p.id_reemplaza,
                renumerado = p.renumerado,
                jefe_autoriza = p.jefe_autoriza


    });

        }

        // GET: api/Permisos/ListarFiltro/texto
        //[Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<PermisosViewModel>> ListarFiltro([FromRoute] string texto)
        {
            int numero = 0;
            int textoint = 0;

            if (int.TryParse(texto, out numero)) { numero = 1; textoint = Int32.Parse(texto); }

            var permisos = await _context.Permisos.Include(p => p.categoria).Include(p => p.categoria.cargo)
            .Where(c => numero != 1 ? c.categoria.nombre_empleado.Contains(texto) : c.categoria.id_empleado == textoint)
            .OrderByDescending(a => a.id_permiso).ToListAsync();
      

            return permisos.Select(p => new PermisosViewModel
            {
                id_permiso = p.id_permiso,
                nombre = p.categoria.nombre_empleado,
                regional = p.categoria.id_zona,
                cargo = p.categoria.cargo.desc_cargo,
                id_empleado = p.id_empleado,
                id_clasificapermiso = p.id_clasificapermiso,
                fecha_registro = p.fecha_registro,
                por_hora = p.por_hora,
                por_dia = p.por_dia,
                fec_inicio = p.fec_inicio,
                fec_final = p.fec_final,
                hora_inicio = p.hora_inicio,
                hora_fin = p.hora_fin,
                hrs_permiso = p.hrs_permiso,
                dcto_nomina = p.dcto_nomina,
                dcto_vacaciones = p.dcto_vacaciones,
                jefe_inmediato = p.jefe_inmediato,
                dir_nalgh = p.dir_nalgh,
                estado = p.estado,
                motivo_permiso = p.motivo_permiso,
                id_reemplaza = p.id_reemplaza,
                renumerado = p.renumerado,
                jefe_autoriza = p.jefe_autoriza
            });

        }
        // GET: api/Permisos/Listado
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<PermisosViewModel>> Listado([FromRoute] String id)
        {

            var permisos = await _context.Permisos.Include(p => p.categoria)
                .Include(p => p.categoria.cargo)
                //.Where(p => p.jefe_inmediato.Contains(id))
                .Where(p => p.jefe_autoriza == id)
                .OrderByDescending(a => a.id_permiso).Take(100).ToListAsync();

            return permisos.Select(p => new PermisosViewModel

            {
                id_permiso = p.id_permiso,
                nombre = p.categoria.nombre_empleado,
                regional = p.categoria.id_zona,
                cargo = p.categoria.cargo.desc_cargo,
                id_empleado = p.id_empleado,
                id_clasificapermiso = p.id_clasificapermiso,
                fecha_registro = p.fecha_registro,
                por_hora = p.por_hora,
                por_dia = p.por_dia,
                fec_inicio = p.fec_inicio,
                fec_final = p.fec_final,
                hora_inicio = p.hora_inicio,
                hora_fin = p.hora_fin,
                hrs_permiso = p.hrs_permiso,
                dcto_nomina = p.dcto_nomina,
                dcto_vacaciones = p.dcto_vacaciones,
                jefe_inmediato = p.jefe_inmediato,
                dir_nalgh = p.dir_nalgh,
                estado = p.estado,
                motivo_permiso = p.motivo_permiso,
                id_reemplaza = p.id_reemplaza,
                renumerado = p.renumerado,
                jefe_autoriza = p.jefe_autoriza

            });

        }
        // GET: api/permisos/Consecutivopermiso
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConsecutivoViewModel>> ConsecutivoPermiso()
        {

            var permiso = await _context.Permisos
            .OrderByDescending(a => a.id_permiso)
            .Take(1)
            .ToListAsync();

            return permiso.Select(p => new ConsecutivoViewModel
            {

                id_permiso = p.id_permiso + 1,

            });

        }


        // GET: api/Permisos/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<CantidadPermisos>> Mostrar([FromRoute] int id)
        {
            DateTime fechaHora = DateTime.Now;
            var Año = fechaHora.Year;
            DateTime Fecha = new DateTime(Año, 01, 01, 00, 00, 00);


            var permisos = await _context.Permisos
            .Where (a => a.fec_inicio > Fecha)
            .Where(a => a.id_empleado == id)
            .Where(a => a.estado != "ANULADO")
            .ToListAsync();

            return permisos.Select(p => new CantidadPermisos
            {

                id_permiso = p.id_permiso,
                id_empleado = p.id_empleado,
                nomina = p.dcto_nomina,
                vacaciones = p.dcto_vacaciones,
                remunerado = p.jefe_inmediato,
                compensado = p.dir_nalgh,


            });
        }

        // GET: api/Permisos/MostrarPDF/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> MostrarPDF([FromRoute] int id)
        {

            var categoria = await _context.Permisos
             .Include(p => p.categoria)
             .Include(p => p.categoria.cargo)
            .FirstOrDefaultAsync(c => c.id_permiso == id);


            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new PermisosViewModel
            {

                id_permiso = categoria.id_permiso,
                nombre = categoria.categoria.nombre_empleado,
                regional = categoria.categoria.id_zona,
                cargo = categoria.categoria.cargo.desc_cargo,
                id_empleado = categoria.id_empleado,
                id_clasificapermiso = categoria.id_clasificapermiso,
                fecha_registro = categoria.fecha_registro,
                por_hora = categoria.por_hora,
                por_dia = categoria.por_dia,
                fec_inicio = categoria.fec_inicio,
                fec_final = categoria.fec_final,
                hora_inicio = categoria.hora_inicio,
                hora_fin = categoria.hora_fin,
                hrs_permiso = categoria.hrs_permiso,
                dcto_nomina = categoria.dcto_nomina,
                dcto_vacaciones = categoria.dcto_vacaciones,
                jefe_inmediato = categoria.jefe_inmediato,
                dir_nalgh = categoria.dir_nalgh,
                estado = categoria.estado,
                motivo_permiso = categoria.motivo_permiso,
                id_reemplaza = categoria.id_reemplaza,
                renumerado = categoria.renumerado,
                jefe_autoriza = categoria.jefe_autoriza

            });
        }

        // PUT: api/Categorias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_permiso <= 0)
            {
                return BadRequest();
            }

            var permiso = await _context.Permisos.FirstOrDefaultAsync(c => c.id_permiso == model.id_permiso);

            if (permiso == null)
            {
                return NotFound();
            }

            permiso.id_empleado = model.id_empleado;
            permiso.id_clasificapermiso = model.id_clasificapermiso;
            permiso.fecha_registro = model.fecha_registro;
            permiso.por_hora = model.por_hora;
            permiso.por_dia = model.por_dia;
            permiso.fec_inicio = model.fec_inicio;
            permiso.fec_final = model.fec_final;
            permiso.hora_inicio = model.hora_inicio;
            permiso.hora_fin = model.hora_fin;
            permiso.hrs_permiso = model.hrs_permiso;
            permiso.dcto_nomina = model.dcto_nomina;
            permiso.dcto_vacaciones = model.dcto_vacaciones;
            permiso.jefe_inmediato = model.jefe_inmediato;
            permiso.dir_nalgh = model.dir_nalgh;
            permiso.motivo_permiso = model.motivo_permiso;
            permiso.id_reemplaza = model.id_reemplaza;
            permiso.renumerado = model.renumerado;


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

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Permiso permiso = new Permiso
            {

                id_permiso = model.id_permiso,
                id_empleado = model.id_empleado,
                id_clasificapermiso = model.id_clasificapermiso,
                fecha_registro = model.fecha_registro,
                por_hora = model.por_hora,
                por_dia = model.por_dia,
                fec_inicio = model.fec_inicio,
                fec_final = model.fec_final,
                hora_inicio = model.hora_inicio,
                hora_fin = model.hora_fin,
                hrs_permiso = model.hrs_permiso,
                dcto_nomina = model.dcto_nomina,
                dcto_vacaciones = model.dcto_vacaciones,
                jefe_inmediato = model.jefe_inmediato,
                dir_nalgh = model.dir_nalgh,
                estado = model.estado,
                motivo_permiso = model.motivo_permiso,
                id_reemplaza = model.id_reemplaza,
                renumerado = model.renumerado,
                jefe_autoriza = model.jefe_autoriza
                

            };


        

            try
            {
                _context.Permisos.Add(permiso);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        // DELETE: api/Categorias/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
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

        // PUT: api/Categorias/Desactivar/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var permiso = await _context.Permisos.FirstOrDefaultAsync(c => c.id_permiso == id);

            if (permiso == null)
            {
                return NotFound();
            }



            permiso.estado = "ANULADO";

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

        // PUT: api/Categorias/Activar/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var permiso = await _context.Permisos.FirstOrDefaultAsync(c => c.id_permiso == id);

            if (permiso == null)
            {
                return NotFound();
            }

            permiso.estado = "CONCEDIDO";

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

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.id_empleado == id);
        }
    }
}