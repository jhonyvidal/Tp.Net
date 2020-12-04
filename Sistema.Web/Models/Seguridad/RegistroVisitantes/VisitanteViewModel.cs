using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.RegistroVisitantes
{
    public class VisitanteViewModel
    {
        public int idRegVisitante { get; set; }

        public int id_visitante { get; set; }
        public string nombre { get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public string area { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public string estado { get; set; }

    }
}
