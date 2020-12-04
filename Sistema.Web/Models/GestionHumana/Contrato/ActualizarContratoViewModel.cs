using System;

namespace Sistema.Web.Models.GestionHumana
{
    public class ActualizarContratoViewModel
    {
        public int id_contrato { get; set; }
        public bool adress { get; set; }
        public bool ruaf { get; set; }
        public bool contrato { get; set; }
        public string clausulas_adicionales { get; set; }
        public string anexos_contrato { get; set; }
        public bool politicas { get; set; }
        public bool man_funciones { get; set; }
        public bool carnet { get; set; }
        public bool dotacion { get; set; }
        public bool nomina_web { get; set; }
        public bool silogtran { get; set; }
        public string caja_compensacion { get; set; }

    }
}
