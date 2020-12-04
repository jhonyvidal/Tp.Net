using System;

namespace Sistema.Web.Models.Logistica
{
    public class ActualizarTareaViewModel
    {
        public int idTarea { get; set; }
        public int idTurno { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
    }
}
