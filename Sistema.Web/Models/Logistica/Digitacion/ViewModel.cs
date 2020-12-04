using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Logistica
{
    public class EntregaRemesaViewModel
    {
        public int idEntregaRemesa { get; set; }
        public int id_empleado { get; set; }
        public string empleado { get; set; }
        public int cantidad { get; set; }
        public int digitacion { get; set; }
        public int despacho { get; set; }
        public int sobre { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
    }
}
