//using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;

namespace Sistema.Entidades.Logistica
{
    public class Turno
    {
        [Required]
        public int idTurno { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        
        //public Categoria categoria { get; set; }
        //public Usuario usuario { get; set; }

        public ICollection<Tarea> tarea { get; set; }
        //public ICollection<Usuario> usuario { get; set; }
    }
}
