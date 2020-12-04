using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.GestionHumana
{
    public class VerContratoViewModel
    {
        public int id_contrato { get; set; }
        public int cedula { get; set; }
        public string nombre_empleado { get; set; }
        public int id_cargo { get; set; }
        public int id_zona { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string fecha { get; set; }
        public int duracion_contrato { get; set; }
        public int periodo_prueba { get; set; }
        public bool proceso_sel { get; set; }
        public bool compliance { get; set; }
        public bool visita_dom { get; set; }
        public bool ex_medico { get; set; }
        public bool poligrafo { get; set; }
        public bool hv { get; set; }
        public string licencia { get; set; }
        public bool cer_academica { get; set; }
        public bool car_laboral { get; set; }
        public bool car_personal { get; set; }
        public int id_eps { get; set; }
        public int id_afp { get; set; }
        public int id_arl { get; set; }
        public bool fotografias { get; set; }
        public bool cer_banco { get; set; }
        public int id_estado { get; set; }
        public int id_proceso { get; set; }


        public bool? adress { get; set; }
        public bool? ruaf { get; set; }
        public bool? contrato { get; set; }
        public string clausulas_adicionales { get; set; }
        public string anexos_contrato { get; set; }
        public bool? politicas { get; set; }
        public bool? man_funciones { get; set; }
        public bool? carnet { get; set; }
        public bool? dotacion { get; set; }
        public bool? nomina_web { get; set; }
        public bool? silogtran { get; set; }
        public string caja_compensacion { get; set; }


        public bool? induccion { get; set; }
        public bool? eva_per_prueba { get; set; }
        public bool? reinduccion { get; set; }
        public bool? certificacion { get; set; }

    }
}
