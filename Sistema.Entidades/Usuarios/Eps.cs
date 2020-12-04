using Sistema.Entidades.Visitantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Eps
    {

        [Key]
        public int id_eps { get; set; }
        public string desc_eps{ get; set; }

        public ICollection<Categoria> categoria { get; set; }
        public ICollection<Visitante> visitantes { get; set; }
    }
}
