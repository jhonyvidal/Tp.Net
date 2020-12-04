using Sistema.Entidades.Permisos;
using Sistema.Entidades.Registro;
using Sistema.Entidades.Usuarios.Admin;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Sistema.Entidades.Usuarios
{
    public class Municipio
    {
        [Key]
        public int id_municipio { get; set; }
        public string concat_municipio { get; set; }

        public ICollection<RegistroCall> registro { get; set; }
        public ICollection<Categoria> categoria { get; set; }

    }
}

	