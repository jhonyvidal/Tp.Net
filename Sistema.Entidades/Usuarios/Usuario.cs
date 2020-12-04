using Sistema.Entidades.Almacen;
using Sistema.Entidades.Correspondencia;
using Sistema.Entidades.Logistica;
using Sistema.Entidades.Registro;
using Sistema.Entidades.Ventas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Usuarios.Admin
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string clave { get; set; }
        public string correo { get; set; }
        public int id_empleado { get; set; }
        public int id_perfil { get; set; }
        public int estado { get; set; }
        public int id_zona { get; set; }
        public Categoria categoria { get; set; }
        public Rol rol { get; set; }
        public ICollection<Ingreso> ingresos { get; set; }
        public ICollection<RegistroCall> registro { get; set; }
        public ICollection<Venta> ventas { get; set; }
        public ICollection<correspondencia> Correspondencia { get; set; }
        public ICollection<EntregaRemesa> EntregaRemesa { get; set; }
    }
}
