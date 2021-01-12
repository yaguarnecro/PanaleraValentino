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
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Categorias> categorias = db.Categorias.Include(d => d.CategoriasProducto).ToList();
            return View(categorias);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Categorias categorias)
        {
            using (var db = new ModelProyecto())
            {
                db.Categorias.Add(categorias);
                db.SaveChanges();
            }
            return Redirect("/Categorias/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Categorias cat = db.Categorias.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(Categorias categorias)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Categorias.Find(categorias.IdCategoria);

            if (TryUpdateModel(cat, "", new string[] { "Nombre", "Ubicacion"}))
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
            return Redirect("/Categorias/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Categorias.Find(id);
                db.Categorias.Remove(cat);
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

           Categorias cat = db.Categorias.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


    }
}