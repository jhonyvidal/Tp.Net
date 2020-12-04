using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Contactos
    {
        public int id_contacto { get; set; }
        public int id_empleado { get; set; }
        public string tipo_contacto { get; set; }
        public string nombre_empleado { get; set; }
        public string celular_contacto { get; set; }
        public string fijo_contacto { get; set; }
        public int usuario { get; set; }

        public Categoria categoria { get; set; }
    }
}
