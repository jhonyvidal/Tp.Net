using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Logistica
{
    public class VerTurnoViewModel
    {
        public int idTurno { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }

    }
}
