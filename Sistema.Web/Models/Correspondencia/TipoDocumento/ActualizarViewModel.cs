using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Correspondencia
{
    public class ActualizarTipoDocumentoViewModel
    {
        public int id_tipodocumento { get; set; }
        public string nombre { get; set; }
        public string prioridad { get; set; }
        public int? fecha_plazo { get; set; }
        public bool condicion { get; set; }
    }
}
