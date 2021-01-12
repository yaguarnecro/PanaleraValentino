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
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Productos> productos = db.Productos.Include(d => d.CategoriasProducto).ToList();
            return View(productos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Productos productos)
        {
            using (var db = new ModelProyecto())
            {
                db.Productos.Add(productos);
                db.SaveChanges();
            }
            return Redirect("/Productos/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Productos cat = db.Productos.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(Productos productos)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Productos.Find(productos.IdProducto);

            if (TryUpdateModel(cat, "", new string[] { "Nombre", "Costo", "Existencia", "Estado", "Tipo", "Tamaño", "Empaque", "PuntoMaximo", "PuntoReorden", "PuntoMinimo", "Clasificacion","FechaVencimiento" }))
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
            return Redirect("/Productos/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Productos.Find(id);
                db.Productos.Remove(cat);
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

            Productos cat = db.Productos.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
    }
    
}