using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Almacen.Registro
{
    public class ActualizarViewModel
    {
        [Required]
        public int idregistro { get; set; }
        [Required]
        public string estado { get; set; }
 

    }
}
