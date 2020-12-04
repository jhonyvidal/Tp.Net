using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Encuesta
{
    public class EncuestaViewModel
    {
        public int id { get; set; }
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public int temperatura { get; set; }
        public DateTime fecha { get; set; }
        public string firma { get; set; }
        //public DateTime fecha { get; set; }


    }
}
