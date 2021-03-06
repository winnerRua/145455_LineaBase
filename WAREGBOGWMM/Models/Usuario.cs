 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAREGBOGWMM.App_Code;

namespace WAREGBOGWMM.Models
{
    public class Usuario
    {
        [Display(Name = "Alias de usuario")]
        [Required(ErrorMessage = "Se requiere de un alias de acceso")]
        public string nombreUsuario { get; set; }

        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "Nombre de usuario es requerido test")]
        public string nombreCompleto { get; set; }

        [Display(Name = "Número de documento")]
        [Required(ErrorMessage = "Número de documento del usuario requerido.")]
        public string documento { get; set; }

        [Display(Name = "Dirección del usuario")]
        [Required(ErrorMessage = "Dirección del usuario requerido.")]
        public string direccion { get; set; }

        [Display(Name = "Teléfono de usuario")]
        [Required(ErrorMessage = "Teléfonos del usuario requerido.")]
        public string telefono { get; set; }

        [Display(Name = "Fecha de nacimiento de usuario")]
        [Required(ErrorMessage = "Fecha de nacimiento del usuario requerido.")]
        public string fechaNacimiento { get; set; }


        [Display(Name = "Género de usuario")]
        [Required(ErrorMessage = "Género del usuario requerido.")]
        public string generoID { get; set; }
        public List<SelectListItem> genero { get; set; }


        [Display(Name = "Correo electrónico de usuario")]
        [Required(ErrorMessage = "Correo electrónico del usuario requerido.")]
        public string correo { get; set; }

        [Display(Name = "País de usuario")]
        [Required(ErrorMessage = "País del usuario requerido.")]
        public string paisID { get; set; }
        public List<SelectListItem> pais { get; set; }

        [Display(Name = "Rol de usuario")]
        [Required(ErrorMessage = "Rol del usuario requerido.")]
        public string rolID { get; set; }
        public List<SelectListItem> ROL { get; set; }

        [Display(Name = "Contraseña de usuario")]
        [Required(ErrorMessage = "Contraseña del usuario requerido.")]
        public string contra { get; set; }

        [Display(Name = "Estado de usuario")]
        [Required(ErrorMessage = "Estado del usuario requerido.")]
        public string estado { get; set; }

        [Display(Name = "Código de usuario")]
        [Required(ErrorMessage = "Debe ingresar un código de usuario a consultar.")]
        public string usuarioID { get; set; }

        [Display(Name = "Nueva contraseña")]
        [Required(ErrorMessage = "Nueva contraseña del usuario requerida.")]
        public string contraseñaNueva { get; set; }
    }
}