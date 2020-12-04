//using Sistema.Entidades.Usuarios.Admin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Usuarios.Admin;

namespace Sistema.Entidades.Usuarios
{
    public class Rol
    {
        [Required]
        public int id_perfil { get; set; }
        [StringLength(50)]
        public string desc_perfil { get; set; }
        public int estado { get; set; }

        //public ICollection<Usuario> usuarios { get; set; }
        public ICollection<Grupo> grupo { get; set; }
        public ICollection<Usuario> suario { get; set; }
    }
}
