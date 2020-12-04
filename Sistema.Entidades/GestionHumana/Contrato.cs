using Sistema.Entidades.Visitantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.GestionHumnana
{
    public class Contrato
    {

        [Key]
        public int id_contrato { get; set; }
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
        public string caja_compensacion { get; set; }
        public int id_usuario{ get; set; }
        public int id_estado { get; set; }
        public DateTime fecha { get; set; }
        public bool requisicion { get; set; }
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

        public bool? induccion { get; set; }
        public bool? eva_per_prueba { get; set; }
        public bool? reinduccion { get; set; }
        public bool? certificacion { get; set; }


        //public ICollection<Categoria> categoria { get; set; }
    }
}
