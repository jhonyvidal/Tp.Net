using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Dependente
    {

        [Key]
        public Int64 id_dependente { get; set; }
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public DateTime fec_ncto { get; set; }
        public string parentesco { get; set; }
        public string activo { get; set; }
        public string sexo { get; set; }
        public string escolaridad { get; set; }
        public string tipo_doc { get; set; }

        public Categoria categoria { get; set; }


    }
}
