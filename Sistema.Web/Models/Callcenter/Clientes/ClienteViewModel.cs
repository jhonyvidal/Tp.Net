using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Almacen.Cliente
{
    public class ClientesCallViewModel
    {
        public int idcliente { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }

    }
}
