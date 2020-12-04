using System;

namespace Sistema.Web.Models.Logistica
{
    public class ActualizarViewModel
    {
        public int idEntregaRemesa { get; set; }
        public int id_empleado { get; set; }
        public int cantidad { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public int id_usuario { get; set; }
    }
}
