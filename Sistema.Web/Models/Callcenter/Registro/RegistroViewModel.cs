using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Almacen.Registro
{
    public class RegistroCallViewModel
    {
        [Required]
        public int idregistro { get; set; }
        [Required]
        public int id_municipio { get; set; }
        public string municipio { get; set; }
        [Required]
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public string nombrecliente { get; set; }
        public string telefono { get; set; }
        [Required]
        public int idmotivo { get; set; }
        public string motivo { get; set; }
        [Required]
        public int idextension { get; set; }
        public string extension { get; set; }
        [StringLength(60)]
        public string remesa { get; set; }
        public string ordencargue { get; set; }
        public string transfiere { get; set; }
        [StringLength(270)]
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string documento { get; set; }

    }
}
