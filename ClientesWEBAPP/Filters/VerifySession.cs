using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientesWEBAPP.Controllers;
using ClientesWEBAPP.Models;

namespace ClientesWEBAPP.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var user = (users)HttpContext.Current.Session["User"];

            if(user == null)
            {
                if (filterContext.Controller is HomeController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
                
            }
            else
            {
                if (filterContext.Controller is HomeController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Cliente");
                }
            }


            base.OnActionExecuting(filterContext);
        }
    }
}