using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Dependencia
    {

        [Key]
        public int id_dependencia { get; set; }
        public string desc_dependencia { get; set; }

        public ICollection<Categoria> categorias { get; set; }
    }
}
