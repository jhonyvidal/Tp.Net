using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Web.Models.Categorias;
using Sistema.Web.Models.Municipio;
using Sistema.Web.Models.Usuarios.Usuarios;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CategoriasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<CategoriaViewModel>> Listar()
        {
            var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.estado).Include(c => c.zona).Include(c => c.municipio)
               .Take(10).OrderByDescending(a => a.fec_ingreso).ToListAsync();


            return categoria.Select(c => new CategoriaViewModel
            {
                id_empleado = c.id_empleado,
                nombre_empleado = c.nombre_empleado,
                fec_ingreso = c.fec_ingreso,
                municipio = c.municipio.concat_municipio,
                cargo = c.cargo.desc_cargo,
                zona = c.zona.desc_zona,
                estado = c.estado.desc_estado,
                nit_empresa = c.nit_empresa,
                id_estado = c.id_estado

            });
        }
        // GET: api/Categorias/birthday 
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaBirthday>> Birthday() 
        {
            DateTime fechaHora = DateTime.Now;
            var Año = fechaHora.Year;
            var Mes = fechaHora.Month;
            var Dia = fechaHora.Day;
            //DateTime Fecha = new DateTime(Año, Mes, Dia, 00, 00, 00);

            var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.zona)
            .Where(c=> (c.fec_ncto).Day == Dia &&  (c.fec_ncto).Month == Mes && c.id_estado != 2).ToListAsync();


            return categoria.Select(c => new CategoriaBirthday
            {
                nombre_empleado = c.nombre_empleado,
                cargo = c.cargo.desc_cargo,
                zona = c.zona.desc_zona,

            });
        }
        // GET: api/Categorias/birthdayNext 
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaBirthday>> BirthdayNext()
        {
            DateTime fechaHora = DateTime.Now;

            var Mes = fechaHora.Month;
            var Dia = fechaHora.Day;
            var final = Dia + 6;
            //DateTime Fecha = new DateTime(Año, Mes, Dia, 00, 00, 00);

            var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.zona)
            .Where(c => (c.fec_ncto).Day > Dia && (c.fec_ncto).Day < final && (c.fec_ncto).Month == Mes && c.id_estado != 2)
            .OrderBy  (a => (a.fec_ncto).Day).ToListAsync();


            return categoria.Select(c => new CategoriaBirthday
            {
                nombre_empleado = c.nombre_empleado,
                cargo = c.cargo.desc_cargo,
                zona = c.zona.desc_zona,
                fecha = c.fec_ncto.ToShortDateString(),

            });
        }
        // GET: api/Categorias/birthdayNextMes 
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaBirthday>> BirthdayNextMes()
        {
            DateTime fechaHora = DateTime.Now;

            var Año = fechaHora.Year;
            var Mes = fechaHora.Month;
            var Dia = fechaHora.Day;
            var Diafinal = Dia + 6;
            var Mesfinal = Mes;

            var CantidadDias = System.DateTime.DaysInMonth(Año, Mes);

            if (Diafinal > CantidadDias){Diafinal = Diafinal - CantidadDias; Mesfinal = Mes + 1; }
            else { Diafinal = 0; Mesfinal = 0; }
           

                var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.zona)
                .Where(c => (c.fec_ncto).Day <= Diafinal && (c.fec_ncto).Month == Mesfinal && c.id_estado != 2)
                .OrderBy(a => (a.fec_ncto).Day).ToListAsync();
          

            return categoria.Select(c => new CategoriaBirthday
                {
                    nombre_empleado = c.nombre_empleado,
                    cargo = c.cargo.desc_cargo,
                    zona = c.zona.desc_zona,
                    fecha = c.fec_ncto.ToShortDateString(),

                });
            
        }
        // GET: api/Categorias/ListarFiltroEmpleados/texto
        //[Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<CategoriaViewModel>> ListarFiltroEmpleados([FromRoute] string texto)
        {
            int numero = 0;
            int textoint = 0;
     
            if (int.TryParse(texto, out numero)) { numero = 1; textoint = Int32.Parse(texto); }

            var categoria = await _context.Categorias.Include(c => c.zona).Include(c => c.municipio).Include(c => c.cargo).Include(c => c.estado)
            .Where(c => numero != 1 ? c.nombre_empleado.Contains(texto):c.id_empleado == textoint)
            .Take(15).OrderByDescending(a => a.fec_ingreso).ToListAsync();

            return categoria.Select(c => new CategoriaViewModel
            {
                id_empleado = c.id_empleado,
                nombre_empleado = c.nombre_empleado,
                fec_ingreso = c.fec_ingreso,
                municipio = c.municipio.concat_municipio,
                cargo = c.cargo.desc_cargo,
                zona = c.zona.desc_zona,
                estado = c.estado.desc_estado,
                nit_empresa = c.nit_empresa
            });

        }
        // GET: api/Categorias/Informe
        [HttpGet("[action]")]
        public async Task<IEnumerable<InformeViewModel>> Informe()
        {
     
            var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.estado)
            .Include(c => c.zona).Include(c => c.municipio).Include(c => c.afp).Include(c => c.estadocivil).Include(c => c.nivelacademico)
            .Include(c => c.area).Include(c => c.eps).Include(c => c.dependencia).ToListAsync();

            return categoria.Select(c => new InformeViewModel
            {
                id_empleado = c.id_empleado,
                nombre_empleado = c.nombre_empleado,
                fec_ingreso = c.fec_ingreso.ToShortDateString(),
                libreta_militar = c.libreta_militar,
                direccion = c.direccion,
                barrio = c.barrio,
                comuna = c.comuna,
                estrato = c.estrato,
                celular = c.celular,
                telefono_fijo = c.telefono_fijo,
                correo = c.correo,
                grupo_sanguineo = c.grupo_sanguineo,
                id_dependencia = c.dependencia.desc_dependencia,
                id_estado_civil = c.estadocivil.des_estadocivil,
                id_nivelacademico = c.nivelacademico.desc_nivelacademico,
                recibe_dotacion = c.recibe_dotacion,
                conyuge = c.conyuge,
                cedula_conyuge = c.cedula_conyuge,
                sexo = c.sexo,
                fec_ncto = c.fec_ncto.ToShortDateString(),
                talla_bota = c.talla_bota,
                talla_camisa = c.talla_camisa,
                talla_pantalon = c.talla_pantalon,
                fec_nctoconyuge = c.fec_nctoconyuge.ToShortDateString(),
                id_subsede = c.id_subsede,
                id_nivelacademico_conyuge = c.nivelacademico.desc_nivelacademico,
                labora_conyuge = c.labora_conyuge,
                nit_empresa = c.nit_empresa,
                id_tipoconductor = c.id_tipoconductor,
                medio_transporte = c.medio_transporte,
                placa_operativa = c.placa_operativa,
                jornada = c.jornada,
                tipo_empleado = c.tipo_empleado,
                cargo = c.cargo.desc_cargo,
                estado = c.estado.desc_estado,
                zona = c.zona.desc_zona,
                municipio = c.municipio.concat_municipio,
                afp = c.afp.desc_afp,
                area = c.area.desc_area,
                eps = c.eps.desc_eps,
                titulo = c.titulo

            });
        }
        // GET: api/Categorias/Informes/s/1/1/1
        [HttpGet("[action]/{estado}/{area}/{cargo}/{zona}/{finicial}/{ffinal}")]

        public async Task<IEnumerable<InformeViewModel>> Informes([FromRoute] string estado,int area,int cargo,int zona,string finicial,string ffinal)
        {

            DateTime fechainicial = Convert.ToDateTime(finicial);
            DateTime fechafinal = Convert.ToDateTime(ffinal);

            var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.estado)
                  .Include(c => c.zona).Include(c => c.municipio).Include(c => c.afp).
                  Include(c => c.area).Include(c => c.eps).Include(c=>c.estadocivil).Include(c => c.nivelacademico).Include(c => c.dependencia)
                  .Where(c => estado=="N"? c.id_estado != 2: c.id_estado != 0).Where(c => area != 0 ? c.id_area == area: c.id_area != 0)
                  .Where(c => cargo != 0 ? c.id_cargo == cargo : c.id_cargo != 0).Where(c => zona != 100 ? c.id_zona == zona : c.id_zona != 100)
                  .Where(c=> c.fec_ingreso >= fechainicial && c.fec_ingreso <= fechafinal).ToListAsync();
            

            return categoria.Select(c => new InformeViewModel
            {
                    id_empleado = c.id_empleado,
                    nombre_empleado = c.nombre_empleado,
                    fec_ingreso = c.fec_ingreso.ToShortDateString(),
                    libreta_militar = c.libreta_militar,
                    direccion = c.direccion,
                    barrio = c.barrio,
                    comuna = c.comuna,
                    estrato = c.estrato,
                    celular = c.celular,
                    telefono_fijo = c.telefono_fijo,
                    correo = c.correo,
                    grupo_sanguineo = c.grupo_sanguineo,
                    id_dependencia = c.dependencia.desc_dependencia,
                    id_estado_civil = c.estadocivil.des_estadocivil,
                    id_nivelacademico = c.nivelacademico.desc_nivelacademico,
                    recibe_dotacion = c.recibe_dotacion,
                    conyuge = c.conyuge,
                    cedula_conyuge = c.cedula_conyuge,
                    sexo = c.sexo,
                    fec_ncto = c.fec_ncto.ToShortDateString(),
                    talla_bota = c.talla_bota,
                    talla_camisa = c.talla_camisa,
                    talla_pantalon = c.talla_pantalon,
                    fec_nctoconyuge = c.fec_nctoconyuge.ToShortDateString(),
                    id_subsede = c.id_subsede,
                    id_nivelacademico_conyuge = c.nivelacademico.desc_nivelacademico,
                    labora_conyuge = c.labora_conyuge,
                    nit_empresa = c.nit_empresa,
                    id_tipoconductor = c.id_tipoconductor,
                    medio_transporte = c.medio_transporte,
                    placa_operativa = c.placa_operativa,
                    jornada = c.jornada,
                    tipo_empleado = c.tipo_empleado,
                    cargo = c.cargo.desc_cargo,
                    estado = c.estado.desc_estado,
                    zona = c.zona.desc_zona,
                    municipio = c.municipio.concat_municipio,
                    afp = c.afp.desc_afp,
                    area = c.area.desc_area,
                    eps = c.eps.desc_eps,
                    titulo = c.titulo
            });
        }
        // GET: api/Categorias/ListarRetiro
        [HttpGet("[action]")]
        public async Task<IEnumerable<CrearRetiroViewModel>> ListarRetiro()

        {
            var categoria = await _context.Retiro.ToListAsync();

            return categoria.Select(c => new CrearRetiroViewModel
            {
                id_empleado = c.id_empleado,
                motivo_retiro = c.motivo_retiro,
                obsernacion_retiro = c.obsernacion_retiro,
                fecha_retiro =c.fecha_retiro,
                usuario = c.usuario,
                inicio_vac = c.inicio_vac,
                fin_vac = c.fin_vac

            });
        }

        // GET: api/Categorias/ListarMunicipio
        [HttpGet("[action]")]
        public async Task<IEnumerable<MunicipioViewModel>> ListarMunicipio()

        {
            var categoria = await _context.Municipio.ToListAsync();

            return categoria.Select(c => new MunicipioViewModel
            {
                id_municipio = c.id_municipio,
                concat_municipio = c.concat_municipio

            });
        }
        // GET: api/Categorias/ListarFiltro/texto
        //[Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<MunicipioViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var municipios = await _context.Municipio.Where(v => v.concat_municipio.Contains(texto)).Take(15).OrderByDescending(a => a.id_municipio).ToListAsync();

            return municipios.Select(c => new MunicipioViewModel
            {
                id_municipio = c.id_municipio,
                concat_municipio = c.concat_municipio
            });

        }
        // GET: api/Categorias/ListarAfp
        [HttpGet("[action]")]
        public async Task<IEnumerable<AfpViewModel>> ListarAfp()

        {
            var categoria = await _context.afp.ToListAsync();

            return categoria.Select(c => new AfpViewModel
            {
                id_afp = c.id_afp,
                desc_afp = c.desc_afp

            });
        }
        // GET: api/Categorias/ListarArea
        [HttpGet("[action]")]
        public async Task<IEnumerable<AreaViewModel>> ListarArea()

        {
            var categoria = await _context.area.ToListAsync();

            return categoria.Select(c => new AreaViewModel
            {
                id_area = c.id_area,
                desc_area = c.desc_area

            });
        }
        // GET: api/Categorias/ListarCargo

        [HttpGet("[action]")]
        public async Task<IEnumerable<CargoViewModel>> ListarCargo()

        {
            var categoria = await _context.cargos.ToListAsync();

            return categoria.Select(c => new CargoViewModel
            {
                id_cargo = c.id_cargo,
                desc_cargo = c.desc_cargo

            });
        }
        // GET: api/Categorias/ListarEps
        [HttpGet("[action]")]
        public async Task<IEnumerable<EpsViewModel>> ListarEps()

        {
            var categoria = await _context.eps.ToListAsync();

            return categoria.Select(c => new EpsViewModel
            {
                id_eps = c.id_eps,
                desc_eps = c.desc_eps
            });
        }
        // GET: api/Categorias/ListarDependentes
        [HttpGet("[action]")]
        public async Task<IEnumerable<DependenteViewModel>> ListarDependentes()

        {
            var categoria = await _context.dependente.Include(d => d.categoria).Include(p => p.categoria.zona).Include(p => p.categoria.estado).ToListAsync();



            int calcular(DateTime fecha)
            {
                int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;

                return edad;
            }

            return categoria.Select
            (d => new DependenteViewModel
            {
                id_dependente = d.id_dependente,
                empleado = d.categoria.nombre_empleado,
                regional = d.categoria.zona.desc_zona,
                nombre = d.nombre,
                fecha = d.fec_ncto.ToShortDateString(),
                parentesco = d.parentesco,
                activo = d.activo,
                sexo = d.sexo,
                escolaridad = d.escolaridad,
                tipo_doc = d.tipo_doc,
                estado= d.categoria.estado.desc_estado,
                edad = calcular(d.fec_ncto),

            });
        }
        // GET: api/Categorias/MostrarDependentes/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<DependenteViewModel>> MostrarDependentes([FromRoute] int id)
        {

            var categoria = await _context.dependente
              .Where(c => c.id_empleado == id)
              .ToListAsync();
            //.FirstOrDefaultAsync(c => c.id_empleado == id);


            return categoria.Select(d => new DependenteViewModel
            {

                id_dependente = d.id_dependente,
                id_empleado = d.id_empleado,
                nombre = d.nombre,
                fec_ncto = d.fec_ncto,
                parentesco = d.parentesco,
                activo = d.activo,
                sexo = d.sexo,
                escolaridad = d.escolaridad,
                tipo_doc = d.tipo_doc

            });
        }
        // GET: api/Categorias/ListarContactos
        [HttpGet("[action]")]
        public async Task<IEnumerable<ContactosViewModel>> ListarContactos()

        {
            var categoria = await _context.Contactos.Include(d => d.categoria).ToListAsync();

            return categoria.Select(d => new ContactosViewModel
            {
                empleado = d.categoria.nombre_empleado,
                id_empleado =d.categoria.id_empleado,
                tipo_contacto = d.tipo_contacto,
                nombre_empleado = d.nombre_empleado,
                celular_contacto = d.celular_contacto,
                fijo_contacto = d.fijo_contacto,
            });
        }
        // GET: api/Categorias/MostrarContactos/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ContactosViewModel>> MostrarContactos([FromRoute] int id)
        {

            var contacto = await _context.Contactos
              .Where(c => c.id_empleado == id)
              .ToListAsync();
            //.FirstOrDefaultAsync(c => c.id_empleado == id);


            return contacto.Select(d => new ContactosViewModel
            {

                tipo_contacto = d.tipo_contacto,
                nombre_empleado = d.nombre_empleado,
                celular_contacto = d.celular_contacto,
                fijo_contacto = d.fijo_contacto,

            });
        }

        // GET: api/Categorias/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
          
            var categoria = await _context.Categorias.Include(c => c.cargo).Include(c => c.estado)
            .Include(c => c.zona).Include(c => c.municipio).Include(c => c.municipio).Include(c => c.afp).
            Include(c => c.area).Include(c => c.eps).FirstOrDefaultAsync(c => c.id_empleado == id);
           
            
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new EmpleadosViewModel
            {
                id_empleado = categoria.id_empleado,
                nombre_empleado = categoria.nombre_empleado,
                fec_ingreso = categoria.fec_ingreso,
                compensacion = categoria.compensacion,
                libreta_militar = categoria.libreta_militar,
                certificado_judicial = categoria.certificado_judicial,
                id_municipio = categoria.id_municipio,
                direccion = categoria.direccion,
                barrio = categoria.barrio,
                comuna = categoria.comuna,
                estrato = categoria.estrato,
                celular = categoria.celular,
                telefono_fijo = categoria.telefono_fijo,
                correo = categoria.correo,
                grupo_sanguineo = categoria.grupo_sanguineo,
                id_dependencia = categoria.id_dependencia,
                id_cargo = categoria.id_cargo,
                id_estado = categoria.id_estado,
                id_eps = categoria.id_eps,
                id_afp = categoria.id_afp,
                id_estado_civil = categoria.id_estado_civil,
                id_nivelacademico = categoria.id_nivelacademico,
                recibe_dotacion = categoria.recibe_dotacion,
                conyuge = categoria.conyuge,
                cedula_conyuge = categoria.cedula_conyuge,
                sexo = categoria.sexo,
                id_zona = categoria.id_zona,
                fec_ncto = categoria.fec_ncto,
                talla_bota = categoria.talla_bota,
                talla_camisa = categoria.talla_camisa,
                talla_pantalon = categoria.talla_pantalon,
                fec_nctoconyuge = categoria.fec_nctoconyuge,
                id_area = categoria.id_area,
                id_subsede = categoria.id_subsede,
                id_nivelacademico_conyuge = categoria.id_nivelacademico_conyuge,
                labora_conyuge = categoria.labora_conyuge,
                nit_empresa = categoria.nit_empresa,
                id_tipoconductor = categoria.id_tipoconductor,
                medio_transporte = categoria.medio_transporte,
                placa_operativa = categoria.placa_operativa,
                jornada = categoria.jornada,
                tipo_empleado = categoria.tipo_empleado,
                cargo = categoria.cargo.desc_cargo,
                estado = categoria.estado.desc_estado,
                zona = categoria.zona.desc_zona,
                municipio = categoria.municipio.concat_municipio,
                afp = categoria.afp.desc_afp,
                area = categoria.area.desc_area,
                eps = categoria.eps.desc_eps,
                titulo = categoria.titulo


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

            if (model.id_empleado <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.id_empleado == model.id_empleado);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.id_empleado = model.id_empleado;
            categoria.nombre_empleado = model.nombre_empleado;
            categoria.fec_ingreso = model.fec_ingreso;
            categoria.libreta_militar = model.libreta_militar;
            categoria.id_municipio = model.id_municipio;
            categoria.direccion = model.direccion;
            categoria.barrio = model.barrio;
            categoria.comuna = model.comuna;
            categoria.estrato = model.estrato;
            categoria.celular = model.celular;
            categoria.telefono_fijo = model.telefono_fijo;
            categoria.correo = model.correo;
            categoria.grupo_sanguineo = model.grupo_sanguineo;
            categoria.id_dependencia = model.id_dependencia;
            categoria.id_cargo = model.id_cargo;
            categoria.id_eps = model.id_eps;
            categoria.id_afp = model.id_afp;
            categoria.id_estado_civil = model.id_estado_civil;
            categoria.id_nivelacademico = model.id_nivelacademico;
            categoria.recibe_dotacion = model.recibe_dotacion;
            categoria.conyuge = model.conyuge;
            categoria.cedula_conyuge = model.cedula_conyuge;
            categoria.sexo = model.sexo;
            categoria.id_zona = model.id_zona;
            categoria.fec_ncto = model.fec_ncto;
            categoria.talla_bota = model.talla_bota;
            categoria.talla_camisa = model.talla_camisa;
            categoria.talla_pantalon = model.talla_pantalon;
            categoria.fec_nctoconyuge = model.fec_nctoconyuge;
            categoria.id_area = model.id_area;
            categoria.id_subsede = model.id_subsede;
            categoria.id_nivelacademico_conyuge = model.id_nivelacademico_conyuge;
            categoria.labora_conyuge = model.labora_conyuge;
            categoria.nit_empresa = model.nit_empresa;
            categoria.id_tipoconductor = model.id_tipoconductor;
            categoria.medio_transporte = model.medio_transporte;
            categoria.placa_operativa = model.placa_operativa;
            categoria.jornada = model.jornada;
            categoria.titulo = model.titulo;


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
            Categoria categoria = new Categoria
            {
                id_empleado = model.id_empleado,
                nombre_empleado = model.nombre_empleado,
                fec_ingreso = model.fec_ingreso,
                compensacion = model.compensacion,
                libreta_militar = model.libreta_militar,
                certificado_judicial =model.certificado_judicial,
                id_municipio = model.id_municipio,
                direccion = model.direccion,
                barrio = model.barrio,
                comuna=model.comuna,
                estrato=model.estrato,
                celular=model.celular,
                telefono_fijo=model.telefono_fijo,
                correo=model.correo,
                grupo_sanguineo=model.grupo_sanguineo,
                cod_usuario=model.cod_usuario,
                txt_auditoria=model.txt_auditoria,
                id_dependencia=model.id_dependencia,
                id_cargo=model.id_cargo,
                id_estado = model.id_estado,
                id_eps=model.id_eps,
                id_afp=model.id_afp,
                id_estado_civil=model.id_estado_civil,
                id_nivelacademico=model.id_nivelacademico,
                recibe_dotacion=model.recibe_dotacion,
                conyuge=model.conyuge,
                cedula_conyuge=model.cedula_conyuge,
                sexo=model.sexo,
                id_zona=model.id_zona,
                fec_ncto=model.fec_ncto,
                talla_bota=model.talla_bota,
                talla_camisa=model.talla_camisa,
                talla_pantalon=model.talla_pantalon,
                fec_nctoconyuge=model.fec_nctoconyuge,
                id_area=model.id_area,
                id_subsede=model.id_subsede,
                id_nivelacademico_conyuge=model.id_nivelacademico_conyuge,
                labora_conyuge=model.labora_conyuge,
                nit_empresa=model.nit_empresa,
                abreviatura=model.abreviatura,
                id_tipoconductor=model.id_tipoconductor,
                medio_transporte=model.medio_transporte,
                admin_sgi=model.admin_sgi,
                placa_operativa=model.placa_operativa,
                jornada=model.jornada,
                tipo_empleado=model.tipo_empleado,
                titulo=model.titulo

            };


            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                if (model.dependiente == "SI") {
                    var id = categoria.id_empleado;
                    foreach (var det in model.detalles)
                    {
                        Dependente dependente = new Dependente
                        {
                            id_empleado = id,
                            id_dependente = det.id_dependente,
                            nombre = det.nombre,
                            fec_ncto = det.fec_ncto,
                            parentesco = det.parentesco,
                            activo = "S",
                            sexo = det.sexo,
                            escolaridad = "0",
                            tipo_doc = det.tipo_doc

                        };

                        _context.dependente.Add(dependente);
                    }
                    await _context.SaveChangesAsync();
                }
                if (model.contacto == "SI")
                {
                    var id = categoria.id_empleado;
                    foreach (var det in model.contactos)
                    {
                        Contactos contactos = new Contactos
                        {
                            id_empleado = id,
                            tipo_contacto = det.tipo_contacto,
                            nombre_empleado =det.nombre_empleado,
                            celular_contacto = det.celular_contacto,
                            fijo_contacto = det.fijo_contacto,
                            usuario = model.usuario
                           
                         };

                        _context.Contactos.Add(contactos);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        // POST: api/Categorias/CrearRetiro
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearRetiro([FromBody] CrearRetiroViewModel model)
        {
            DateTime fechaHora = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Retiro retiro = new Retiro
            {
                id_empleado = model.id_empleado,
                motivo_retiro = model.motivo_retiro,
                obsernacion_retiro = model.obsernacion_retiro,
                fecha_retiro = model.fecha_retiro,
                usuario = model.usuario,
                mvto = model.motivo_retiro,
                inicio_vac = fechaHora,
                fin_vac = fechaHora

            };

            try
            {
                _context.Retiro.Add(retiro);
                await _context.SaveChangesAsync();

                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.id_empleado == model.id_empleado);

                if (categoria == null)
                {
                    return NotFound();
                }

                categoria.id_estado = 2;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }

        // POST: api/Categorias/CrearNuevoRetiro
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearNuevoRetiro([FromBody] CrearRetiroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Retiro retiro = new Retiro
            {
                id_empleado = model.id_empleado,
            };

            _context.Retiro.Add(retiro);
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

        // POST: api/Categorias/CrearDependiente
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearDependiente([FromBody] CrearDependenteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dependente dependiente = new Dependente
            {
                id_empleado = model.id_empleado   ,
                id_dependente = model.id_dependente,
                nombre = model.nombre,
                fec_ncto = model.fec_ncto,
                parentesco = model.parentesco,
                activo = "S",
                sexo = model.sexo,
                escolaridad = "0",
                tipo_doc = model.tipo_doc
            };

            _context.dependente.Add(dependiente);
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
        // POST: api/Categorias/CrearContacto
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearContacto([FromBody] CrearContactosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contactos contacto = new Contactos
            {
                id_empleado = model.id_empleado,
                tipo_contacto = model.tipo_contacto,
                nombre_empleado = model.nombre_empleado,
                celular_contacto = model.celular_contacto,
                fijo_contacto = model.fijo_contacto,
                usuario = model.usuario
            };

            _context.Contactos.Add(contacto);
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

            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.id_empleado == id);
            //var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.id_estado = 2;
            //categoria.idcategoria = 2;

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

            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.id_empleado == id);
            //var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.id_estado = 1;
            //categoria.idcategoria = 1;

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
            //return _context.Categorias.Any(e => e.idcategoria == id);
        }
    }
}