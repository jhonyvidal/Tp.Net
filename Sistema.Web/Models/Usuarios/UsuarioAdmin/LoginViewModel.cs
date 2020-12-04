using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Permisos.Usuario
{
    public class LoginViewModel
    {
        [Required]
        public int id_usuario { get; set; }
        [Required]
        public string clave { get; set; }
    }
}
