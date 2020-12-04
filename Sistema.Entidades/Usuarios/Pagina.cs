//using Sistema.Entidades.Usuarios.Admin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Usuarios
{
    public class Pagina
    {
        [Required]
        public int id_pagina { get; set; }
        [StringLength(50)]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tipopagina { get; set; }

        public ICollection<Grupo> grupo { get; set; }


    }
}
