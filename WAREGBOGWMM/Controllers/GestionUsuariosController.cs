using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAREGBOGWMM.App_Code;
using WAREGBOGWMM.Models;
using System.Data;

namespace WAREGBOGWMM.Controllers
{
    public class GestionUsuariosController : Controller
    {
        // GET: GestionUsuarios
        public ActionResult IndexCrear()
        {
            return View();
        }

        public ActionResult CrearUsuarios()
        {
            var model = new Usuario();
            model.genero = new Utilerias().QueryGenre();
            model.ROL = new Utilerias().QueryRol();
            model.pais = new Utilerias().QueryPais();

            return View(model);
        }

        public ActionResult ModificarUsuarios()
        {
            var model = new Usuario();
            model.genero = new Utilerias().QueryGenre();
            model.ROL = new Utilerias().QueryRol();
            model.pais = new Utilerias().QueryPais();
            //var gen = new Utilerias().QueryGenre();
            //var rol = new Utilerias().QueryRol();
            //var user = new Usuario();
            //var rolY = new Usuario();
            
            //user.genero = gen;
            //rolY.ROL = rol;
            return View(model);
        }

        public ActionResult AltaBajaUsuarios()
        {
            return View();
        }

        //Crear usuarios
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuarios1(Usuario user) {

            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().CreateUser(user, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("Revise bien sus campos!");
            //Finalizado las validaciones correspondientes de datos;


            /*
             si oerror viene distinto de vacio, manejo de errores
             */
            var model = new Usuario();
            model.genero = new Utilerias().QueryGenre();
            model.ROL = new Utilerias().QueryRol();
            model.pais = new Utilerias().QueryPais();
            ViewBag.Message = String.Format("Usuario creado!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("CrearUsuarios", model);
            //return JavaScript("<script>alert('Usuario creado');</script>");
        }

        //Modificar usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarUsuarios1(Usuario user)
        {
            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().UpdateUser(user, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("Revise bien sus campos!");
            //Finalizado las validaciones correspondientes de datos;

            /*
             si oerror viene distinto de vacio, manejo de errores
             */

            var model = new Usuario();
            model.genero = new Utilerias().QueryGenre();
            model.ROL = new Utilerias().QueryRol();
            model.pais = new Utilerias().QueryPais();
            
            //ViewBag.Message = String.Format("Usuario actualizado!\\nSiendo hoy:{0}", DateTime.Now.ToString());

            return View("ModificarUsuarios", model);
            //return View("ModificarUsuarios");
            //return Content("<script language='javascript' type='text/javascript'>alert('Usuario actualizado!');</script>");
        }

        //Alta/Baja de usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AltaBajaUsuario1(Usuario user)
        {

            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().UpDownUser(user, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("Revise bien sus campos!");
            //Finalizado las validaciones correspondientes de datos;


            /*
             si oerror viene distinto de vacio, manejo de errores
             */

            ViewBag.Message = String.Format("Alta/Baja de usuario correcta!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("AltaBajaUsuarios");
            //return Content("<script language='javascript' type='text/javascript'>alert('Usuario habilitado/inhabilitado!');</script>");
        }

        //Consulta de usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaUsuario(string nombreUsu)
        {
            var user = new Usuario();
            if (ModelState.IsValid)
            {
                var oError = "";
                user = new Utilerias().QueryUser(nombreUsu, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("Revise bien sus campos!");
            //Finalizado las validaciones correspondientes de datos;


            /*
             si oerror viene distinto de vacio, manejo de errores
             */
            return Json(new { response = "", data = user });
        }
    }
}