using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoyectoFinalPañaleraValentino.Models;
using System.Data.Entity;
using System.Data;
namespace PoyectoFinalPañaleraValentino.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Proveedores> proveedores = db.Proveedores.Include(d => d.Compras).ToList();
            return View(proveedores);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Proveedores proveedores)
        {
            using (var db = new ModelProyecto())
            {
                db.Proveedores.Add(proveedores);
                db.SaveChanges();
            }
            return Redirect("/Proveedores/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Proveedores cat = db.Proveedores.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(Proveedores proveedores)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Proveedores.Find(proveedores.IdProveedor);

            if (TryUpdateModel(cat, "", new string[] { "Nombre", "Telefono","CodigoCiiu", "Direccion" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException c)
                {
                    ModelState.AddModelError(" ", c);

                }
            }
            return Redirect("/Proveedores/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Proveedores.Find(id);
                db.Proveedores.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException c)
            {
                ModelState.AddModelError(" ", c);

            }
            return RedirectToAction("Index");
        }


        public ActionResult Detalles(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Proveedores cat = db.Proveedores.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

    }

}