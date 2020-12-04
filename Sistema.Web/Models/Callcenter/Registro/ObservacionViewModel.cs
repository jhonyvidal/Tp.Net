using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Almacen.Observacion
{
    public class ObservacionViewModel
    {
        public int idobservacion { get; set; }
        [Required]
        public int idregistro { get; set; }
        [Required]
        public string observacion { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        public string usuario { get; set; }

        

    }
}
