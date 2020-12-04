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
using Sistema.Web.Models.Almacen.Cliente;

namespace Sistema.Web.Controllers
{
    //[Authorize(Roles = "Almacenero,Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesCallController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ClientesCallController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/ClientesCall/ConsecutivoCliente
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClientesCallViewModel>> ConsecutivoCliente()
        {

            var permiso = await _context.ClientesCall
            .OrderByDescending(a => a.idcliente)
            .Take(1)
            .ToListAsync();

            return permiso.Select(p => new ClientesCallViewModel
            {

                idcliente = p.idcliente + 1,

            });

        }

        // GET: api/ClientesCall/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<ClientesCallViewModel>> Listar()
        {
            var categoria = await _context.ClientesCall
            .OrderByDescending(c => c.idcliente)
            .Take(100).ToListAsync();

            return categoria.Select(c => new ClientesCallViewModel
            {
                idcliente = c.idcliente,
                documento = c.documento,
                nombre = c.nombre,
                telefono = c.telefono,
                descripcion = c.descripcion,
                condicion = c.condicion
            });

        }

        // GET: api/ClientesCall/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var categoria = await _context.ClientesCall.Where(c=>c.condicion==true).Take(10).ToListAsync();

            return categoria.Select(c => new SelectViewModel
            {
                idcliente = c.idcliente,
                documento = c.documento,
                nombre = c.nombre
            });

        }
        // GET: api/ClientesCall/ListarFiltro/texto
        //[Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<SelectViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var clientes = await _context.ClientesCall.Where(v => v.nombre.Contains(texto)).Take(15).OrderByDescending(a => a.idcliente).ToListAsync();

            return clientes.Select(c => new SelectViewModel
            {
                idcliente = c.idcliente,
                documento = c.documento,
                nombre = c.nombre
            });

        }
        // GET: api/ClientesCall/Listardocumento/id
        //[Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> Listardocumento([FromRoute] string id)
        {
            var clientes = await _context.ClientesCall.Where(v => v.documento.Contains(id)).Take(15).OrderByDescending(a => a.idcliente).ToListAsync();

            return clientes.Select(c => new SelectViewModel
            {
                idcliente = c.idcliente,
                documento = c.documento,
                nombre = c.nombre
            });

        }

        // GET: api/ClientesCall/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var categoria = await _context.ClientesCall.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new ClientesCallViewModel
            {
                idcliente = categoria.idcliente,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion,
                condicion = categoria.condicion
            });
        }

        // PUT: api/ClientesCall/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcliente <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.ClientesCall.FirstOrDefaultAsync(c => c.idcliente == model.idcliente);

            if (categoria == null)
            {
                return NotFound();
            }
            categoria.documento = model.documento;
            categoria.nombre = model.nombre;
            categoria.telefono = model.telefono;
            categoria.descripcion = model.descripcion;

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

        // POST: api/ClientesCall/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientesCall categoria = new ClientesCall
            {
                documento = model.documento,
                nombre = model.nombre,
                telefono= model.telefono,
                descripcion = model.descripcion,
                condicion = true 
            };

            //if (model.documento == categoria.documento)
            //{
            //    return NotFound("EL cliente Ya Existe");
            //}

            _context.ClientesCall.Add(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return NotFound("EL cliente Ya Existe");
            }

            return Ok();
        }

        // DELETE: api/ClientesCall/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.ClientesCall.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.ClientesCall.Remove(categoria);
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

        // PUT: api/ClientesCall/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.ClientesCall.FirstOrDefaultAsync(c => c.idcliente == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = false;

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

        // PUT: api/ClientesCall/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.ClientesCall.FirstOrDefaultAsync(c => c.idcliente == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = true;

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

        private bool CategoriaExists(int id)
        {
            return _context.ClientesCall.Any(e => e.idcliente == id);
        }
    }
}