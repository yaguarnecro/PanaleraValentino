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
    public class ComprasController : Controller
    {
        // GET: Compras
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Compras> compras = db.Compras.Include(C => C.Productos).ToList();
            return View(compras);
        }


        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Compras compras)
        {
            using (var db = new ModelProyecto())
            {
                db.Compras.Add(compras);
                db.SaveChanges();
            }
            return Redirect("/Compras/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Compras com = db.Compras.Find(id);

            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }

        [HttpPost]
        public ActionResult Modificar(Compras compras)
        {
            ModelProyecto db = new ModelProyecto();
            var com = db.Compras.Find(compras.IdCompra);

            if (TryUpdateModel(com, "", new string[] { "IdProveedor", "IdProducto", "IdEmpleado", "Cantidad", "Fecha","PrecioTotal" }))
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
            return Redirect("/Compras/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var com = db.Compras.Find(id);
                db.Compras.Remove(com);
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

            Compras com = db.Compras.Find(id);

            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }
    }
}