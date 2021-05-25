using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAREGBOGWMM.Models
{
    public class AsignacionPermiso
    {
        [Display(Name = "Región")]
        [Required(ErrorMessage = "Región para el permiso es requerido.")]
        public string region { get; set; }

        [Display(Name = "Estado de permiso")]
        [Required(ErrorMessage = "Estado de permiso es requerido.")]
        public string estadoActivo { get; set; }

        [Display(Name = "Código de usuario")]
        [Required(ErrorMessage = "Código de usuario es requerido.")]
        public string codigoUsuario { get; set; }

        [Display(Name = "Código de rol")]
        [Required(ErrorMessage = "Código de rol es requerido.")]
        public string codigoRol { get; set; }

        [Display(Name = "Permiso")]
        [Required(ErrorMessage = "Permiso para asignar requerido.")]
        public string permiso { get; set; }
    }
}