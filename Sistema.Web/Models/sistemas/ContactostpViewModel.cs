using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Contactostp
{
    public class ContactostpViewModel
    {
        public int id_contactostp { get; set; }
        public int id_empleado { get; set; }
        public int extension { get; set; }
        public string numero { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string regional { get; set; }
        public int estado { get; set; }

    }
}
