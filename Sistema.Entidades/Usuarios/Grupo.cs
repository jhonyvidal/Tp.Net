
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Usuarios
{
    public class Grupo
    {
        [Required]
        public int id_grupo { get; set; }
        public int id_perfil { get; set; }
        public int id_pagina { get; set; }
        public int indice { get; set; }
        public DateTime fecha { get; set; }

        public Rol rol { get; set; }
        public Pagina pagina { get; set; }


    }
}
