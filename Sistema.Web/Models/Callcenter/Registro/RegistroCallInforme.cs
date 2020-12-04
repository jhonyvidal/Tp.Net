using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Almacen.Registro
{
    public class RegistroCallInforme
    {
        [Required]
        public int idregistro { get; set; }
        public string municipio { get; set; }
        public string cliente { get; set; }
        public string telefono { get; set; }
        public string motivo { get; set; }
        public string extension { get; set; }
        [StringLength(60)]
        public string remesa { get; set; }
        public string ordencargue { get; set; }
        public string transfiere { get; set; }
        [StringLength(270)]
        public string observacion { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }
        public string usuario { get; set; }
        public string documento { get; set; }

    }
}
