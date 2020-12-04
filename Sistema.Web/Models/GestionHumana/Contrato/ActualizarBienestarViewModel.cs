using System;

namespace Sistema.Web.Models.GestionHumana
{
    public class ActualizarBienestarContratoViewModel
    {
        public int id_contrato { get; set; }
        public bool induccion {get; set;}
        public bool eva_per_prueba {get; set;}
        public bool reinduccion { get; set; }
        public bool certificacion { get; set; }



    }
}
