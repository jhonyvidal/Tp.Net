
using Sistema.Entidades.Usuarios;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Visitantes
{
    public class RegistroVisitante
    {
        [Required]
        public int idRegVisitante { get; set; }
        [Required]
        public int id_visitante { get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public int id_area { get; set; }

        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public string estado { get; set; }


        public Area area { get; set; }
        public Visitante visitante { get; set; }
    }
}
