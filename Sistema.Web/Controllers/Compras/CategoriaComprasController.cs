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
using Sistema.Web.Models.Almacen.Categoria;

namespace Sistema.Web.Controllers
{
    //[Authorize(Roles = "Almacenero,Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasComprasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CategoriasComprasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/CategoriasCompras/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<CategoriaComprasViewModel>> Listar()
        {
            var categoria = await _context.CategoriasCompras.ToListAsync();

            return categoria.Select(c => new CategoriaComprasViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });

        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var categoria = await _context.CategoriasCompras.Where(c=>c.condicion==true).ToListAsync();

            return categoria.Select(c => new SelectViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre
            });

        }

        // GET: api/Categorias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var categoria = await _context.CategoriasCompras.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new CategoriaComprasViewModel {
                idcategoria = categoria.idcategoria,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion,
                condicion = categoria.condicion
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

            if (model.idcategoria <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.CategoriasCompras.FirstOrDefaultAsync(c => c.idcategoria == model.idcategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = model.nombre;
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

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoriaCompras categoria = new CategoriaCompras
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            };

            _context.CategoriasCompras.Add(categoria);
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

        // DELETE: api/Categorias/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.CategoriasCompras.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.CategoriasCompras.Remove(categoria);
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

        // PUT: api/Categorias/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.CategoriasCompras.FirstOrDefaultAsync(c => c.idcategoria == id);

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

        // PUT: api/Categorias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.CategoriasCompras.FirstOrDefaultAsync(c => c.idcategoria == id);

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
            return _context.CategoriasCompras.Any(e => e.idcategoria == id);
        }
    }
}