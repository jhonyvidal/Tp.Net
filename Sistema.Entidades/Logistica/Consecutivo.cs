//using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;

namespace Sistema.Entidades.Logistica
{
    public class Consecutivo
    {
        [Required]
        public int idConsecutivo { get; set; }
        [StringLength(50)]
        public int idTurno { get; set; }
        public int consecutivo{ get; set; }
        public string usuario { get; set; }
        public int estado { get; set; }
        public DateTime fecha { get; set; }

        //public ICollection<Usuario> usuarios { get; set; }
        //public ICollection<Usuario> usuario { get; set; }
    }
}
