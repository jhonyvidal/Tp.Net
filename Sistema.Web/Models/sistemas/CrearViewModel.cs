﻿using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Contactostp
{
    public class CrearViewModel
    {
        [Required]
        public int id_contactostp { get; set; }
        [Required]
        public int id_empleado { get; set; }
        public int extension { get; set; }
        public string numero { get; set; }
        public string correo { get; set; }
        public int estado { get; set; }
    }
}
