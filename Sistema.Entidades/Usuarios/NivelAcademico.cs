using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class NivelAcademico
    {

        [Key]
        public int id_nivelacademico { get; set; }
        public string desc_nivelacademico { get; set; }

        public ICollection<Categoria> categorias { get; set; }
    }
}
