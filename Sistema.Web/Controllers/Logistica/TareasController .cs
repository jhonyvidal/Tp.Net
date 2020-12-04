using System;
using System.Collections.Generic;
using System.IO;
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
    public class TareasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TareasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Tareas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VerTareasViewModel>> Listar()
        {
            var rol = await _context.Tareas.Include(a => a.tarea).Include(a => a.tarea.turno)
                .Where(a => a.estado != "CERRADO").ToListAsync();

            return rol.Select(r => new VerTareasViewModel
            {
                idTareas = r.idTareas,
                idTarea = r.idTarea,
                tarea = r.tarea.nombre,
                turno = r.tarea.turno.nombre,
                observacion = r.observacion,
                usuario = r.usuario,
                estado = r.estado,
                fechaCierre = r.fechaCierre.ToShortDateString(),
                fechaCreacion = r.fechaCreacion.ToShortDateString()


            });

        }

        // GET: api/Tareas/ListarConsecutivo
        [HttpGet("[action]")]
        public async Task<IEnumerable<VerConsecutivoViewModel>> ListarConsecutivo()
        {
            var rol = await _context.Consecutivo.ToListAsync();

            return rol.Select(r => new VerConsecutivoViewModel
            {
                idConsecutivo = r.idConsecutivo,
                idTurno = r.idTurno,
                consecutivo = r.consecutivo,
                usuario = r.usuario,
                estado = r.estado,
                fecha = r.fecha.ToShortDateString(),
 
            });;

        }

        //// POST: api/Tareas/Crear
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Crear([FromBody] CrearTareasViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var fecha = DateTime.Now;
        //    Tareas tareas = new Tareas
        //    {

        //        idTarea = model.idTarea,
        //        observacion = model.observacion,
        //        usuario = model.usuario,
        //        estado = model.estado,
        //        fechaCreacion = fecha,
        //        fechaCierre = model.fechaCierre

        //    };

        //    try
        //    {
        //        _context.Tareas.Add(tareas);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();

        //}

        // POST: api/Tareas/CrearTurnos
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearTurnos([FromBody] CrearTareasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            var consultaTarea = await _context.Tarea.Where(a => a.idTurno == model.idTurno).ToListAsync();
         

            try
            {
                foreach (var det in consultaTarea)
                {
                    Tareas tareas = new Tareas
                    {
                        idTarea = det.idTarea,
                        estado = "ACTIVO",
                        fechaCreacion = fechaHora,
                        fechaCierre = fechaHora
                    };
                    _context.Tareas.Add(tareas);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Tareas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarTareasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idTareas <= 0)
            {
                return BadRequest();
            }

            var tarea = await _context.Tareas.FirstOrDefaultAsync(c => c.idTareas == model.idTareas);

            if (tarea == null)
            {
                return NotFound();
            }

            tarea.observacion = model.observacion;


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
        // PUT: api/Tareas/AbrirTurno
        [HttpPut("[action]")]
        public async Task<IActionResult> AbrirTurno([FromBody] ActualizarConsecutivoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (model.idConsecutivo <= 0)
            //{
            //    return BadRequest();
            //}
            var fechaHora = DateTime.Now;
            var tarea = await _context.Consecutivo.FirstOrDefaultAsync(c => c.idConsecutivo == 1);

            if (tarea == null)
            {
                return NotFound();
            }
            tarea.idTurno = model.idTurno;
            tarea.usuario = model.usuario;
            tarea.estado = 1;
            tarea.fecha = fechaHora;


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
        // PUT: api/Tareas/CerrarTurno
        [HttpPut("[action]")]
        public async Task<IActionResult> CerrarTurno([FromBody] ActualizarConsecutivoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (model.idConsecutivo <= 0)
            //{
            //    return BadRequest();
            //}
            var fechaHora = DateTime.Now;
            var tarea = await _context.Consecutivo.FirstOrDefaultAsync(c => c.idConsecutivo == 1);

            if (tarea == null)
            {
                return NotFound();
            }

            tarea.usuario = model.usuario;
            tarea.estado = 0;
            tarea.fecha = fechaHora;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            var consultaTareas = await _context.Tareas.Where(a => a.estado == "ACTIVO").ToListAsync();

            try
            {
                foreach (var det in consultaTareas)
                {
                    det.estado = "PENDIENTE";
                    det.usuario = model.usuario;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/Tareas/Activar/5/usuario
        [HttpPut("[action]/{id}/{usuario}")]
        public async Task<IActionResult> Activar([FromRoute] int id,string usuario)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tareas = await _context.Tareas.FirstOrDefaultAsync(c => c.idTareas == id);

            if (tareas == null)
            {
                return NotFound();
            }

                tareas.estado = "CERRADO";
                tareas.usuario = usuario;

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