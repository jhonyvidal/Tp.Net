using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Almacen;
using Sistema.Datos.Mapping.Contactostp;
using Sistema.Datos.Mapping.Correspondencia;
using Sistema.Datos.Mapping.Extension;
using Sistema.Datos.Mapping.GestionHumana;
using Sistema.Datos.Mapping.Logistica;
using Sistema.Datos.Mapping.Motivo;
using Sistema.Datos.Mapping.Observacion;
using Sistema.Datos.Mapping.Permisos;
using Sistema.Datos.Mapping.Registro;
using Sistema.Datos.Mapping.Requisiciones;
using Sistema.Datos.Mapping.Sistemas;
using Sistema.Datos.Mapping.Usuarios;
using Sistema.Datos.Mapping.Usuarios.Admin;
using Sistema.Datos.Mapping.Ventas;
using Sistema.Datos.Mapping.Visitantes;
using Sistema.Entidades.Almacen;
using Sistema.Entidades.Contactostp;
using Sistema.Entidades.Correspondencia;
using Sistema.Entidades.Extension;
using Sistema.Entidades.GestionHumnana;
using Sistema.Entidades.Logistica;
using Sistema.Entidades.Motivo;
using Sistema.Entidades.Observacion;
using Sistema.Entidades.Permisos;
using Sistema.Entidades.Registro;
using Sistema.Entidades.Requisiciones;
using Sistema.Entidades.Sistemas;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;
using Sistema.Entidades.Ventas;
using Sistema.Entidades.Visitantes;


namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<NivelAcademico> NivelAcademico { get; set; }
        public DbSet<Dependencia> Dependencia { get; set; }
        public DbSet<Zona> zona { get; set; }
        public DbSet<Estado> estado { get; set; }
        public DbSet<Afp> afp { get; set; }
        public DbSet<Area> area { get; set; }
        public DbSet<Dependente> dependente { get; set; }
        public DbSet<Eps> eps { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<InfoContactos> InfoContactos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<CategoriaCompras> CategoriasCompras { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<DetalleIngreso> DetallesIngresos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<ClientesCall> ClientesCall { get; set; }
        public DbSet<MotivosCall> MotivosCall { get; set; }
        public DbSet<ExtensionCall> ExtensionCall { get; set; }
        public DbSet<RegistroCall> RegistroCall { get; set; }
        public DbSet<ObservacionCall> Observacion { get; set; }
        public DbSet<Requisicion> Requisicion { get; set; }
        public DbSet<correspondencia> Correspondencia { get; set; }
        public DbSet<ObservacionCor> ObservacionCor { get; set; }
        public DbSet<Remitente> Remitente { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Contactotp> Contactostp { get; set; }
        public DbSet<Visitante> Visitante { get; set; }
        public DbSet<RegistroVisitante> RegistroVisitante { get; set; }
        public DbSet<Encuesta> Encuesta { get; set; }
        public DbSet<EntregaRemesa> EntregaRemesa { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Consecutivo> Consecutivo { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Retiro> Retiro { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new EstadoCivilMap());
            modelBuilder.ApplyConfiguration(new NivelAcademicoMap());
            modelBuilder.ApplyConfiguration(new DependenciaMap());
            modelBuilder.ApplyConfiguration(new ZonaMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new AfpMap());
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new EpsMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new PaginaMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ContactosMap());
            modelBuilder.ApplyConfiguration(new InfoContactosMap());
            modelBuilder.ApplyConfiguration(new PermisosMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new PersonaMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new CategoriaComprasMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());
            modelBuilder.ApplyConfiguration(new DetalleIngresoMap());
            modelBuilder.ApplyConfiguration(new VentaMap());
            modelBuilder.ApplyConfiguration(new DetalleVentaMap());
            modelBuilder.ApplyConfiguration(new ClientesCallMap());
            modelBuilder.ApplyConfiguration(new MotivosCallMap());
            modelBuilder.ApplyConfiguration(new ExtensionCallMap());
            modelBuilder.ApplyConfiguration(new RegistroCallMap());
            modelBuilder.ApplyConfiguration(new ObservacionCallMap());
            modelBuilder.ApplyConfiguration(new RequisicionMap());
            modelBuilder.ApplyConfiguration(new CorrespondenciaMap());
            modelBuilder.ApplyConfiguration(new ObservacionCorMap());
            modelBuilder.ApplyConfiguration(new RemitenteMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new ContactostpMap());
            modelBuilder.ApplyConfiguration(new VisitanteMap());
            modelBuilder.ApplyConfiguration(new RegistroVisitanteMap());
            modelBuilder.ApplyConfiguration(new EncuestaMap());
            modelBuilder.ApplyConfiguration(new EntregaRemesaMap());
            modelBuilder.ApplyConfiguration(new TareaMap());
            modelBuilder.ApplyConfiguration(new TurnoMap());
            modelBuilder.ApplyConfiguration(new TareasMap());
            modelBuilder.ApplyConfiguration(new ConsecutivoMap());
            modelBuilder.ApplyConfiguration(new ContratoMap());
            modelBuilder.ApplyConfiguration(new RetiroMap());
        }

    }
}
