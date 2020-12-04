using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios.Admin;
using Sistema.Entidades.Contactostp;

namespace Sistema.Entidades.Correspondencia
{
    public class correspondencia
    {
        [Required]
        public int id_correspondencia{ get; set; }
        public int id_remitente { get; set; }

        public int id_usuario { get; set; }
        public int id_tipodocumento { get; set; }
        public string desdoc { get; set; }
        public int usuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_cumplido { get; set; }
        public string folios { get; set; }
        public string anexos { get; set; }
        public string estado { get; set; }

        //public Contactotp correo { get; set; }
        public Usuario destinatario { get; set; }
        public Remitente remitente { get; set; }
        public TipoDocumento TipoDocumento{ get; set; }

    }
}
