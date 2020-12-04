using System.Collections.Generic;
using Sistema.Entidades.Usuarios;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Correspondencia;

namespace Sistema.Entidades.Contactostp
{
    public class Contactotp
    {
        public int id_contactostp { get; set; }
        public int id_empleado { get; set; }
        public int extension { get; set; }
        public string numero { get; set; }
        public string correo { get; set; }
        public int estado { get; set; }

        public Categoria categoria { get; set; }
        //public ICollection<correspondencia> correspondencia { get; set; }


    }
}
