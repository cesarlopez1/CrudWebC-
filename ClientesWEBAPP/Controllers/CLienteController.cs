using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using ClientesWEBAPP.Models;
using ClientesWEBAPP.Models.ViewModels;

namespace ClientesWEBAPP.Controllers
{
    public class ClienteController : Controller
    {
        // GET: CLiente
        public ActionResult Index()
        {
            List<ListClienteViewModel> lst;
            using (db_clientesCRUDEntities db = new db_clientesCRUDEntities())
            {
                lst = (from d in db.clientes
                           select new ListClienteViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre,
                               Apellido = d.apellido,
                               Edad = d.edad.Value,
                               Correo = d.correo
                           }).ToList();
            }

                return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    using (db_clientesCRUDEntities db = new db_clientesCRUDEntities())
                    {
                        var oCliente = new clientes();
                        oCliente.correo = model.Correo;
                        oCliente.nombre = model.Nombre;
                        oCliente.apellido = model.Apellido;
                        oCliente.edad = model.Edad;

                        db.clientes.Add(oCliente);
                        db.SaveChanges();

                    }
                    return Redirect("/Cliente");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public ActionResult Editar(int Id)
        {
            ClienteViewModel model = new ClienteViewModel();
            using (db_clientesCRUDEntities db = new db_clientesCRUDEntities())
            {
                var oCliente = db.clientes.Find(Id);
                model.Nombre = oCliente.nombre;
                model.Apellido = oCliente.apellido;
                model.Edad = oCliente.edad.Value;
                model.Correo = oCliente.correo;
                model.Id = oCliente.id;
            }
                return View(model);
        }


        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    using (db_clientesCRUDEntities db = new db_clientesCRUDEntities())
                    {
                        var oCliente = db.clientes.Find(model.Id);
                        oCliente.correo = model.Correo;
                        oCliente.nombre = model.Nombre;
                        oCliente.apellido = model.Apellido;
                        oCliente.edad = model.Edad;

                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("/Cliente");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            ClienteViewModel model = new ClienteViewModel();
            using (db_clientesCRUDEntities db = new db_clientesCRUDEntities())
            {
                var oCliente = db.clientes.Find(Id);
                db.clientes.Remove(oCliente);
                db.SaveChanges();
            }
            return Redirect("/Cliente");
        }

        public ActionResult PrintPDF()
        {
            List<ListClienteViewModel> lst;
            using (db_clientesCRUDEntities db = new db_clientesCRUDEntities())
            {
                lst = (from d in db.clientes
                       select new ListClienteViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Apellido = d.apellido,
                           Edad = d.edad.Value,
                           Correo = d.correo
                       }).ToList();
            }

            return new Rotativa.ViewAsPdf("PrintPDF", lst);
            
            
        }
    }
}
