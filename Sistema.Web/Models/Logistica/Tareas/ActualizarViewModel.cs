using System;

namespace Sistema.Web.Models.Logistica
{
    public class ActualizarTareasViewModel
    {
        public int idTareas { get; set; }
        public int idTarea { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public string estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaCierre { get; set; }
    }
}
