using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Correspondencia
{
    public class Remitente
    {
        [Required]
        public int id_remitente { get; set; }

        public string documento { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public bool condicion { get; set; }

        public ICollection<correspondencia> Correspondencia { get; set; }
    }
}
