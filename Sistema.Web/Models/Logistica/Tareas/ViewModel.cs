using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Logistica
{
    public class VerTareasViewModel
    {
        public int idTareas { get; set; }
        public int idTarea { get; set; }
        public string tarea { get; set; }
        public string turno { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public string estado { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaCierre { get; set; }

    }
}
