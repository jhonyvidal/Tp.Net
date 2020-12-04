using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Permisos.Usuario
{
    public class ActualizarViewModel
    {

        [Required]
        public int id_usuario { get; set; }
        [Required]
        public string clave { get; set; }
        public string correo { get; set; }
        [Required]
        public int id_empleado { get; set; }
        [Required]
        public int id_zona { get; set; }
        public int id_perfil { get; set; }
        public int estado { get; set; }
    }
}
