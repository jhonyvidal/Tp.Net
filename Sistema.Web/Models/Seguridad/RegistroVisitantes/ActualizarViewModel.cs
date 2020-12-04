using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.RegistroVisitantes
{
    public class ActualizarViewModel
    {
        public int idRegVisitante { get; set; }

        public int id_visitante { get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public int id_area { get; set; }

    }
}
