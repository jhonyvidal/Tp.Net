using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Logistica
{
    public class VerTareaViewModel
    {
        public int idTarea { get; set; }
        public int idTurno { get; set; }
        public string turno { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }

    }
}
