using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Zona
    {
        [Key]
        public int id_zona { get; set; }
        public string desc_zona{ get; set; }
        public ICollection<Categoria> categoria { get; set; }
    }
}
