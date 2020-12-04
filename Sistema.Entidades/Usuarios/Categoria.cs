using Sistema.Entidades.Permisos;
using Sistema.Entidades.Contactostp;
using Sistema.Entidades.Usuarios.Admin;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Visitantes;
using Sistema.Entidades.Logistica;

namespace Sistema.Entidades.Usuarios
{
    public class Categoria
    {
        [Key]
        public int id_empleado { get; set; }
        [Required]
        public string nombre_empleado { get; set; }
        public DateTime fec_ingreso { get; set; }
        public int compensacion { get; set; }
        public string libreta_militar { get; set; }
        public string certificado_judicial { get; set; }
        public int id_municipio { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public string comuna { get; set; }
        public string estrato { get; set; }
        public string celular { get; set; }
        public string telefono_fijo { get; set; }
        public string correo { get; set; }
        public string grupo_sanguineo { get; set; }
        public int cod_usuario { get; set; }
        public string txt_auditoria { get; set; }
        public int id_dependencia { get; set; }
        public int id_cargo { get; set; }
        public int id_estado { get; set; }
        public int id_eps { get; set; }
        public int id_afp { get; set; }
        public int id_estado_civil { get; set; }
        public int id_nivelacademico { get; set; }
        public string recibe_dotacion { get; set; }
        public string conyuge { get; set; }
        public string cedula_conyuge { get; set; }
        public string sexo { get; set; }
        public int id_zona { get; set; }
        public DateTime fec_ncto { get; set; }
        public string talla_bota { get; set; }
        public string talla_camisa { get; set; }
        public string talla_pantalon { get; set; }
        public DateTime fec_nctoconyuge { get; set; }
        public int id_area { get; set; }
        public int id_subsede { get; set; }
        public int id_nivelacademico_conyuge { get; set; }
        public string labora_conyuge { get; set; }
        public int nit_empresa { get; set; }
        public string abreviatura { get; set; }
        public int id_tipoconductor { get; set; }
        public string medio_transporte { get; set; }
        public string admin_sgi { get; set; }
        public string placa_operativa { get; set; }
        public string jornada { get; set; }
        public string tipo_empleado { get; set; }
        public string titulo { get; set; }

        public Cargo cargo { get; set; }
        public EstadoCivil estadocivil { get; set; }
        public NivelAcademico nivelacademico { get; set; }
        public Dependencia dependencia { get; set; }
        public Estado estado { get; set; }
        public Zona zona { get; set; }
        public Municipio municipio { get; set; }
        public Afp afp { get; set; }
        public Area area { get; set; }
        public Eps eps { get; set; }
   

        public ICollection<Contactos> contactos { get; set; }
        public ICollection<Dependente> dependente { get; set; }
        public ICollection<Permiso> permiso { get; set; }
        
        public ICollection<Contactotp> contactostp { get; set; }
        public ICollection<Usuario> usuario { get; set; }
        public ICollection<Venta> ventas { get; set; }
        public ICollection<Encuesta> Encuesta { get; set; }
        public ICollection<EntregaRemesa> EntregaRemesa { get; set; }


    }
}

	