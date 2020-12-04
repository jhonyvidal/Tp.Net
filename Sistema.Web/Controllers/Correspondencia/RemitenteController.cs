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
    public class RemitenteController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RemitenteController (DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/Remitente/Consecutivo
        [HttpGet("[action]")]
        public async Task<IEnumerable<RemitenteViewModel>> Consecutivo()
        {

            var permiso = await _context.Remitente
            .OrderByDescending(a => a.id_remitente)
            .Take(1)
            .ToListAsync();

            return permiso.Select(p => new RemitenteViewModel
            {

                id_remitente = p.id_remitente + 1

            });

        }

        // GET: api/Remitente/Listar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<RemitenteViewModel>> Listar()
        {
            var remitente = await _context.Remitente.ToListAsync();

            return remitente.Select(a => new RemitenteViewModel
            {
               id_remitente = a.id_remitente,
               documento =a.documento,
               nombre = a.nombre,
               telefono = a.telefono,
               email = a.email,
               direccion = a.direccion,
               ciudad = a.ciudad,
               condicion = a.condicion,
            });

        }

        // GET: api/Remitente/Mostrar/1
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var remitente = await _context.Remitente.
                SingleOrDefaultAsync(a => a.id_remitente == id);

            if (remitente == null)
            {
                return NotFound();
            }

            return Ok(new RemitenteViewModel
            {
              id_remitente = remitente.id_remitente,
              documento = remitente.documento,
              nombre = remitente.nombre,
              telefono = remitente.telefono,
              email = remitente.email,
              ciudad = remitente.ciudad,
              direccion =remitente.direccion,
              condicion = remitente.condicion,
            });
        }

        // PUT: api/Remitente/Actualizar
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarRemitenteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_remitente <= 0)
            {
                return BadRequest();
            }

            var remitente = await _context.Remitente.FirstOrDefaultAsync(a => a.id_remitente == model.id_remitente);

            if (remitente == null)
            {
                return NotFound();
            }


            remitente.documento = model.documento;
            remitente.nombre = model.nombre;
            remitente.telefono = model.telefono;
            remitente.email = model.email;
            remitente.direccion = model.direccion;
            remitente.ciudad = model.ciudad;

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

        // POST: api/Remitente/Crear
        //[Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearRemitenteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Remitente remitente = new Remitente
            {
                documento = model.documento,
                nombre = model.nombre,
                telefono = model.telefono,
                email = model.email,
                direccion =model.direccion,
                ciudad =model.ciudad,
                condicion = true,

            };

            _context.Remitente.Add(remitente);
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
        // DELETE: api/Contactostp/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var categoria = await _context.Contactostp.FindAsync(id);
            var remitente = await _context.Remitente.FirstOrDefaultAsync(u => u.id_remitente == id);
            if (remitente == null)
            {
                return NotFound();
            }

            _context.Remitente.Remove(remitente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


            return Ok(remitente);
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

            var remitente = await _context.Remitente.FirstOrDefaultAsync(a => a.id_remitente == id);

            if (remitente == null)
            {
                return NotFound();
            }

            remitente.condicion = true;

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



        private bool RemitenteExists(int id)
        {
            return _context.Remitente.Any(e => e.id_remitente == id);
        }
    }
}