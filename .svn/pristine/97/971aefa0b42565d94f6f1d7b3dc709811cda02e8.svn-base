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
    public class GestionPermisosController : Controller
    {
        // GET: GestionPermisos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearPermisos()
        {
            return View();
        }

        public ActionResult ModificarPermisos()
        {
            return View();
        }

        public ActionResult AltaBajaPermisos()
        {
            return View();
        }

        //Crear permiso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPermisos(Permiso permit)
        {
            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().CreatePermiso(permit, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("");
            ViewBag.Message = String.Format("Permiso creado!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("CrearPermisos");
        }

        //Modificar permiso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarPermisos1(Permiso permit)
        {
            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().UpdatePermiso(permit, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("");
            ViewBag.Message = String.Format("Permiso modificado!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("ModificarPermisos");
        }

        //Alta/Baja permiso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AltaBajaPermisos1(Permiso permit)
        {
            if (!ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().UpDownPermiso(permit, ref oError);
            }
            else
            {
                return View("Revise bien sus campos!");
            }
            //throw new Exception("");
            ViewBag.Message = String.Format("Alta/baja de permiso!\\nSiendo hoy:{0}", DateTime.Now.ToString());
            return View("AltaBajaPermisos");
        }

        //Consulta de permiso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaPermiso(string permiso)
        {
            var permit = new Permiso();
            if (ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                permit = new Utilerias().QueryPermiso(permiso, ref oError);
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
            return Json(new { response = "", data = permit });
            //return View("ModificarPermisos", permit);
            //return DataTable;
            //return Content("<script language='javascript' type='text/javascript'>alert('Usuario habilitado/inhabilitado!');</script>");
            //return Content()
        }
    }
}