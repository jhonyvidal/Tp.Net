using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Almacen.Cliente
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        public string telefono { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        [Required]
        public string documento { get; set; }
        [Required]
        public int idcliente { get; set; }
    }
}
