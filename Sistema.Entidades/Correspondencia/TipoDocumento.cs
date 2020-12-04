using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Correspondencia
{
    public class TipoDocumento
    {
        [Required]
        public int id_tipodocumento { get; set; }
        public string nombre { get; set; }
        public string prioridad { get; set; }
        public int? fecha_plazo { get; set; }
        public bool condicion { get; set; }

        public ICollection<correspondencia> Correspondencia { get; set; }
    }
}
