using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Permisos
{
    public class CantidadPermisos
    {
        public int id_permiso { get; set; }
        public int id_empleado { get; set; }
        public string nomina { get; set; }
        public string vacaciones { get; set; }
        public string remunerado { get; set; }
        public string compensado { get; set; }

    }
}
