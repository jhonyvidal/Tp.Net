using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Registro;


namespace Sistema.Entidades.Almacen
{
    public class ClientesCall
    {
        [Required]
        public int idcliente { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string documento { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool condicion { get; set; }

        public ICollection<RegistroCall> registro { get; set; }
    }
}
