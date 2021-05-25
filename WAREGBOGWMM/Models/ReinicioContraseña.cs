using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAREGBOGWMM.Models
{
    public class ReinicioContraseña
    {
        [Display(Name = "Código de usuario")]
        [Required(ErrorMessage = "Código de usuario es requerido.")]
        public string usuarioID { get; set; }

        [Display(Name = "Nueva contraseña")]
        [Required(ErrorMessage = "Nueva contraseña requerida.")]
        public string contraseñaNueva { get; set; }

        //[Display(Name = "Código de rol")]
        //[Required(ErrorMessage = "Código de rol es requerido.")]
        //public string codigoRol { get; set; }

        //[Display(Name = "Permiso")]
        //[Required(ErrorMessage = "Permiso para asignar requerido.")]
        //public string permiso { get; set; }
    }
}