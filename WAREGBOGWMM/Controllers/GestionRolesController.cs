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
    public class GestionRolesController : Controller
    {
        // GET: GestionRoles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearRoles()
        {
            return View();
        }

        public ActionResult ModificarRoles()
        {
            return View();
        }

        public ActionResult AltaBajaRoles()
        {
            return View();
        }

        //Creación de roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearRoles(Rol uRol)
        {
            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().CreateRol(uRol, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("");
            ViewBag.Message = String.Format("Rol creado!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("CrearRoles");
            //return Content("<script language='javascript' type='text/javascript'>alert('Rol creado!');</script>");
        }

        //Modificación de roles.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarRoles1(Rol uRol)
        {
            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().UpdateRol(uRol, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("");
            ViewBag.Message = String.Format("Rol modificado!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("ModificarRoles");
        }

        //Alta y bada de roles.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AltaBajaRoles1(Rol uRol)
        {
            if (ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().UpDownRol(uRol, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("");
            ViewBag.Message = String.Format("Alta/Baja de rol!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("AltaBajaRoles");
        }

        //Consulta de rol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaRol(string uRol)
        {
            var rol = new Rol();
            if (ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                rol = new Utilerias().QueryRol1(uRol, ref oError);
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
            //dt = new Utilerias().QueryUser();
            return Json(new { response = "", data = rol });
            //return View("ModificarRoles", uRol);
            //return Content("<script language='javascript' type='text/javascript'>alert('Usuario habilitado/inhabilitado!');</script>");
        }
    }
}