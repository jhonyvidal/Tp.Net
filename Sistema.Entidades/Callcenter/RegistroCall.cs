using Sistema.Entidades.Almacen;
using Sistema.Entidades.Extension;
using Sistema.Entidades.Motivo;
using Sistema.Entidades.Observacion;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Registro
{
    public class RegistroCall
    {
        [Required]
        public int idregistro { get; set; }
        [Required]
        public int id_municipio { get; set; }
        [Required]
        public int idcliente { get; set; }
        [Required]
        public int idmotivo { get; set; }
        public int idextencion { get; set; }
        [StringLength(60)]
        public string remesa { get; set; }
        public string ordencargue { get; set; }
        public string transfiere { get; set; }
        [StringLength(270)]
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public int id_usuario { get; set; }

        //public ICollection<Articulo> articulos { get; set; }
        public Usuario usuarios { get; set; }
        public ClientesCall clientes { get; set; }
        public MotivosCall motivos { get; set; }
        public ExtensionCall extensiones { get; set; }
        public Municipio municipio { get; set; }

        public ICollection<ObservacionCall> observaciones { get; set; }
    }
}
