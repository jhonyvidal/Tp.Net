using System;

namespace Sistema.Web.Models.GestionHumana
{
    public class CrearContratoViewModel
    {
        public int cedula { get; set; }
        public string nombre_empleado { get; set; }
        public int id_cargo { get; set; }
        public int id_zona { get; set; }
        public DateTime fecha_ingreso { get; set; }
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
    }
}
