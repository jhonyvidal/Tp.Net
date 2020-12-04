using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Usuarios.Usuarios
{
    public class ContactosViewModel
    {
        public int id_empleado { get; set; }
        public string empleado { get; set; }
        public string tipo_contacto { get; set; }
        public string nombre_empleado { get; set; }
        public string celular_contacto { get; set; }
        public string fijo_contacto { get; set; }
        public int usuario { get; set; }
    }
}
