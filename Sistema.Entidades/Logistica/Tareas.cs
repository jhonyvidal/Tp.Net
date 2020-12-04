//using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;

namespace Sistema.Entidades.Logistica
{
    public class Tareas
    {
        [Required]
        public int idTareas { get; set; }
        public int idTarea { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public string estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaCierre { get; set; }

        public Tarea tarea { get; set; }

        //public Usuario usuario { get; set; }

        //public ICollection<Usuario> usuarios { get; set; }
        //public ICollection<Usuario> usuario { get; set; }
    }
}
