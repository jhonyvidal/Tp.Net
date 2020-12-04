using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Cargo
    {

        [Key]
        public int id_cargo { get; set; }
        public string desc_cargo { get; set; }

        public ICollection<Categoria> categorias { get; set; }
    }
}
