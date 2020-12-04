using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Permisos.Usuario
{
    public class UsuarioViewModel
    {
        public int id_usuario { get; set; }
        public string clave { get; set; }
        public string correo { get; set; }
        //public int id_empleado { get; set; }
        //public int id_zona { get; set; }
        public string regional { get; set; }
        public string cargo { get; set; }
        public string rol { get; set; }
        public int id_perfil { get; set; }
        public int estado { get; set; }
        public string nombre { get; set; }

    }
}
