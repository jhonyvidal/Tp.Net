using Sistema.Entidades.Permisos;
using Sistema.Entidades.Contactostp;
using Sistema.Entidades.Usuarios.Admin;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema.Entidades.Visitantes;
using Sistema.Entidades.Logistica;

namespace Sistema.Entidades.Usuarios
{
    public class Retiro
    {
        [Key]
        public int id_empleado { get; set; }
        [Required]
        public string motivo_retiro { get; set; }

        public string obsernacion_retiro { get; set; }
        public DateTime fecha_retiro { get; set; }
        public int usuario { get; set; }
        public string mvto { get; set; }

        public DateTime? inicio_vac { get; set; }
        public DateTime? fin_vac { get; set; }

    }
}

	