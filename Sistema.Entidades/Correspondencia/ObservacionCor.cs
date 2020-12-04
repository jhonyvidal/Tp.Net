using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Correspondencia
{
    public class ObservacionCor
    {
        [Required]
        public int idobservacion { get; set; }

        public int id_correspondencia { get; set; }
        public string cambio_estado { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }

        //public ICollection<correspondencia> Correspondencia { get; set; }
    }
}
