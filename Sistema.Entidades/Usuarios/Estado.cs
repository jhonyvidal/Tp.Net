using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Estado
    {
        [Key]
        public int id_estado { get; set; }
        public string desc_estado { get; set; }
        public ICollection<Categoria> categoria { get; set; }
    }
}
