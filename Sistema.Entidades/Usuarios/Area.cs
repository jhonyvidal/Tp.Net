using Sistema.Entidades.Visitantes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Area
    {

        [Key]
        public int id_area { get; set; }
        public string desc_area{ get; set; }

        public ICollection<Categoria> categoria { get; set; }
        public ICollection<RegistroVisitante> visitantes{ get; set; }
    }
}
