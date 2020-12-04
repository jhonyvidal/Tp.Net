using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Correspondencia
{
    public class CrearRemitenteViewModel
    {
        public int id_remitente { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public bool condicion { get; set; }
    }
}
