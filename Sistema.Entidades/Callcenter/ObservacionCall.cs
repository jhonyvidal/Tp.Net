using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Registro;

namespace Sistema.Entidades.Observacion
{
    public class ObservacionCall
    {
        public int idobservacion { get; set; }
        [Required]
        public int idregistro { get; set; }
        [Required]
        public string observacion { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
        public RegistroCall registro { get; set; }


    }
}
