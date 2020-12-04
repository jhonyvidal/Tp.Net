using Sistema.Entidades.Correspondencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Correspondencia
{
    public class CrearViewModel
    {
        public int id_remitente { get; set; }

        public int id_usuario { get; set; }
        public int id_tipodocumento { get; set; }
        public string desdoc { get; set; }
        public int usuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_cumplido { get; set; }
        public string folios { get; set; }
        public string anexos { get; set; }
        public string estado { get; set; }

        public List<ObservacionCor> observaciones { get; set; }
    }
}
