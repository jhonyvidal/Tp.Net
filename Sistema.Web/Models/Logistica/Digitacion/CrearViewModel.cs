using System;

namespace Sistema.Web.Models.Logistica
{
    public class CrearViewModel
    {
        public int id_empleado { get; set; }
        public int cantidad { get; set; }
        public int digitacion { get; set; }
        public int despacho { get; set; }
        public int sobre { get; set; }
        public string observacion { get; set; }
        public int id_usuario { get; set; }
    }
}
