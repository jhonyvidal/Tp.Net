using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Correspondencia
{
    public class CorrespondenciaViewModel
    {
        public int id_correspondencia { get; set; }

        public int id_remitente { get; set; }
        public string documento { get; set; }
        public string remitente { get; set; }
        public int id_usuario { get; set; }
        public string destinatario { get; set; }
        public int id_tipodocumento { get; set; }
        public string tipodocumento { get; set; }
        public string desdoc { get; set; }
        public string prioridad { get; set; }
        public int? plazo { get; set; }
        public string correo { get; set; }
        public int usuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_cumplido { get; set; }
        public string folios { get; set; }
        public string anexos { get; set; }
        public string estado { get; set; }
    }
}
