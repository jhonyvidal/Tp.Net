﻿using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Almacen.Motivo
{
    public class ActualizarViewModel
    {
        [Required]
        public int idmotivo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
    }
}
