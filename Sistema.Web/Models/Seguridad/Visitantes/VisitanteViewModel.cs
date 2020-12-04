using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Visitantes
{
    public class VisitanteViewModel
    {
        public int id_visitante { get; set; }
        public string tipodocumento { get; set; }
        public string documento { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string sexo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string rh { get; set; }
        public string arl { get; set; }
        public int ? id_eps { get; set; }
        public string observacion { get; set; }
        public string tipo_vehiculo { get; set; }
        public string placa { get; set; }
        public string estado { get; set; }

    }
}
