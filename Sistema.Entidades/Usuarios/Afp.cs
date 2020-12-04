using Sistema.Entidades.Visitantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Afp
    {

        [Key]
        public int id_afp { get; set; }
        public string desc_afp { get; set; }

        public ICollection<Categoria> categoria { get; set; }
    }
}
