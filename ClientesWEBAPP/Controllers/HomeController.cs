using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientesWEBAPP.Models;

namespace ClientesWEBAPP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Enter(string correo, string contrasena)
        {
            try
            {
                using (db_clientesCRUDEntities1 db = new db_clientesCRUDEntities1())
                {
                    var lst = from d in db.users where d.correo == correo && d.contrasena == contrasena select d;

                    if (lst.Count()>0)
                    {
                        users oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }
                

            }catch(Exception e)
            {
                return Content("Ocurrió un error : " + e.Message);
            }
        }

        
    }
}