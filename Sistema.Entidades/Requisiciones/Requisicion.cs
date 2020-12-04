using Sistema.Entidades.Usuarios;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Requisiciones
{
    public class Requisicion
    {
        //[Key]
        public int idrequisicion { get; set; }
        public DateTime fechasolicitud { get; set; }
        public DateTime fechacontratacion { get; set; }
        public string usuario { get; set; }
        public int id_zona { get; set; }
        public int id_cargo { get; set; }
        public int id_area { get; set; }
        public string causal { get; set; }
        public int reemplazo { get; set; }
        public string observacion { get; set; }
        public int jefe { get; set; }
        public string tipo_contrato { get; set; }
        public string tiempo { get; set; }
        public string funcion { get; set; }
        public string deberes { get; set; }
        public string estudios { get; set; }
        public string experiencia { get; set; }
        public int edad_minima { get; set; }
        public int edad_maxima { get; set; }
        public string sexo { get; set; }
        public string estadocivil { get; set; }
        public string contesturafisica { get; set; }
        public string dviajar { get; set; }
        public string vehiculo { get; set; }
        public string vivienda { get; set; }
        public string cintelectual { get; set; }
        public string iniciativa { get; set; }
        public string apegoanormas { get; set; }
        public string actividadfuerza { get; set; }
        public string manejoactividades { get; set; }
        public string toleranciapresion { get; set; }
        public string vocacion { get; set; }
        public string trabajoequipo { get; set; }
        public int basico { get; set; }
        public int hed { get; set; }
        public int bonificacion { get; set; }
        public int hen { get; set; }
        public int rn { get; set; }
        public int auxmovilizacion { get; set; }
        public int subtransporte { get; set; }
        public string estado { get; set; }
        public int dominical { get; set; }
        public int comision { get; set; }
        public int rodamiento { get; set; }
        public string registro { get; set; }
        public string areaestudio { get; set; }
        public string tiporuta { get; set; }
        public string tipovehiculo { get; set; }
        public string turnocargo { get; set; }


        //public Categoria categoria  { get; set; }

    }
}

	