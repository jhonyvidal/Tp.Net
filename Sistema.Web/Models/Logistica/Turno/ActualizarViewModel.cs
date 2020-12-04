using System;

namespace Sistema.Web.Models.Logistica
{
    public class ActualizarTurnoViewModel
    {
        public int idTurno { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
    }
}
