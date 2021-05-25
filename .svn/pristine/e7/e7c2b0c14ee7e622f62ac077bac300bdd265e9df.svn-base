using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAREGBOGWMM.Models;

namespace WAREGBOGWMM.Controllers
{
    public class AsignacionPermisosController : Controller
    {
        // GET: AsignacionPermisos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AsignacionPermiso()
        {
            return View();
        }

        public ActionResult Test(AsignacionPermiso user)
        {

            if (ModelState.IsValid)
                throw new Exception("");

            return JavaScript("Alert('AsignacionPermisos');");
        }
    }
}