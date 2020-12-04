using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Observacion;

namespace Sistema.Web.Models.Almacen.Registro
{
    public class CrearViewModel
    {
        [Required]
        public int idregistro { get; set; }
        [Required]
        public int id_municipio { get; set; }
        [Required]
        public int idcliente { get; set; }
        [Required]
        public int idmotivo { get; set; }
        public int idextencion { get; set; }
        [StringLength(60)]
        public string remesa { get; set; }
        public string ordencargue { get; set; }
        public string transfiere { get; set; }
        [StringLength(270)]
        public string estado { get; set; }
        public int id_usuario { get; set; }

        public List<ObservacionCall> observaciones { get; set; }


    }
}
