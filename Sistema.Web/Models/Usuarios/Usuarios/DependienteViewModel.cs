using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Municipio
{
    public class DependenteViewModel
    {
        public Int64 id_dependente { get; set; }
        public int id_empleado { get; set; }
        public string regional { get; set; }
        public string empleado { get; set; }
        public string nombre { get; set; }
        public DateTime fec_ncto { get; set; }
        public string fecha { get; set; }
        public string parentesco { get; set; }
        public string activo { get; set; }
        public string sexo { get; set; }
        public string escolaridad { get; set; }
        public string tipo_doc { get; set; }
        public string estado { get; set; }
        public int edad { get; set; }
    }
}
