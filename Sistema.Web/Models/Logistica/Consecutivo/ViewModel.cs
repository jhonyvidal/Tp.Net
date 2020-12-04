using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Logistica
{
    public class VerConsecutivoViewModel
    {
        public int idConsecutivo { get; set; }
        public int idTurno { get; set; }
        public int consecutivo { get; set; }
        public string usuario { get; set; }
        public int estado { get; set; }
        public string fecha { get; set; }

    }
}
