using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Correspondencia
{
    public class ObservacionViewModel
    {
        public int idobservacion { get; set; }

        public int id_correspondencia { get; set; }
        public string cambio_estado { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
    }
}
