//using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;

namespace Sistema.Entidades.Logistica
{
    public class EntregaRemesa
    {
        [Required]
        public int idEntregaRemesa { get; set; }
        [StringLength(50)]
        public int id_empleado { get; set; }
        public int cantidad { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public int id_usuario { get; set; }
        public int digitacion { get; set; }
        public int despacho { get; set; }
        public int sobre { get; set; }
        public Categoria categoria { get; set; }

        public Usuario usuario { get; set; }

        //public ICollection<Usuario> usuarios { get; set; }
        //public ICollection<Usuario> usuario { get; set; }
    }
}
