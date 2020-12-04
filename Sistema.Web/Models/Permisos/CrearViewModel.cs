using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Permisos
{
    public class CrearViewModel
    {

        public int id_permiso { get; set; }
        public int id_empleado { get; set; }
        public int id_clasificapermiso { get; set; }
        public DateTime fecha_registro { get; set; }
        public string por_hora { get; set; }
        public string por_dia { get; set; }
        public DateTime fec_inicio { get; set; }
        public DateTime fec_final { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
        public int hrs_permiso { get; set; }
        public string dcto_nomina { get; set; }
        public string dcto_vacaciones { get; set; }
        public string jefe_inmediato { get; set; }
        public string dir_nalgh { get; set; }
        public string estado { get; set; }
        public string motivo_permiso { get; set; }
        public int id_reemplaza { get; set; }
        public string renumerado { get; set; }
        public string jefe_autoriza { get; set; }

    }
}

