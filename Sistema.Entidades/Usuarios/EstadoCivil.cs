using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class EstadoCivil
    {

        [Key]
        public int id_estadocivil { get; set; }
        public string des_estadocivil { get; set; }

        public ICollection<Categoria> categoria { get; set; }
    }
}
