using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Sistemas
{
    public class InfoContactos
    {
        [Key]
        public int id_contactostp { get; set; }
        public int id_empleado { get; set; }
        public int extension { get; set; }
        public string numero { get; set; }
        public string correo { get; set; }
        public int estado { get; set; }
        public bool correo_empleado { get; set; }
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string regional { get; set; }
    }
}
