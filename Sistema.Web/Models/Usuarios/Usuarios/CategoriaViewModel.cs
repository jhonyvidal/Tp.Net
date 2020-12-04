using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Categorias
{
    public class CategoriaViewModel
    {

        public int id_empleado { get; set; }
        public string nombre_empleado { get; set; }
        public string municipio { get; set; }
        public DateTime fec_ingreso { get; set; }
        public String cargo { get; set; }
        public String estado { get; set; }
        public String zona { get; set; }
        public int nit_empresa { get; set; }
        public int id_estado { get; set; }
    }
}
