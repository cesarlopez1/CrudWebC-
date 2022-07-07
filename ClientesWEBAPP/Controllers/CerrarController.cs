using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientesWEBAPP.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session["User"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}