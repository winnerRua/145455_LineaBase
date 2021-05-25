using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAREGBOGWMM.App_Code;
using WAREGBOGWMM.Models;

namespace WAREGBOGWMM.Controllers
{
    public class ReinicioContraseñasController : Controller
    {
        // GET: ReinicioContraseñas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReinicioContraseñas()
        {
            return View();
        }

        //Reiniciar contraseñas.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReiniciarContraseña(ReinicioContraseña pass)
        {

            if (ModelState.IsValid)
            {
                //return View(user);
                var oError = "";
                new Utilerias().RestartPassword(pass, ref oError);
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

            return Content("<script language='javascript' type='text/javascript'>alert('Contraseña reiniciada!');</script>");
        }
    }
}