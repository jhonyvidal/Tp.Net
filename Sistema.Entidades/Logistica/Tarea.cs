//using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Usuarios.Admin;

namespace Sistema.Entidades.Logistica
{
    public class Tarea
    {
        [Required]
        public int idTarea { get; set; }
        [StringLength(50)]
        public int idTurno { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }

        //public Categoria categoria { get; set; }
        public Turno turno { get; set; }

        //public ICollection<EntregaRemesa> EntregaRemesa { get; set; }

    }
}
