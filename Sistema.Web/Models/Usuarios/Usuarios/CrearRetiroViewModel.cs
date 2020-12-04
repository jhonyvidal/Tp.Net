using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Web.Models.Usuarios.Usuarios;

namespace Sistema.Web.Models.Categorias
{
    public class CrearRetiroViewModel
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
