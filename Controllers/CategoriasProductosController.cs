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
    public class CategoriasProductosController : Controller
    {
        // GET: CategoriasProductos
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<CategoriasProducto> categoriasproducto = db.CategoriasProducto.Include(d => d.Categorias).ToList();
            return View(categoriasproducto);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(CategoriasProducto categoriasproducto)
        {
            using (var db = new ModelProyecto())
            {
                db.CategoriasProducto.Add(categoriasproducto);
                db.SaveChanges();
            }
            return Redirect("/CategoriasProductos/Index");
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            CategoriasProducto cate = db.CategoriasProducto.Find(id);

            if (cate == null)
            {
                return HttpNotFound();
            }
            return View(cate);
        }


        [HttpPost]
        public ActionResult Modificar(CategoriasProducto categoriasproducto)
        {
            ModelProyecto db = new ModelProyecto();
            var cate = db.CategoriasProducto.Find(categoriasproducto.IdCatProductos);

            if (TryUpdateModel(cate, "", new string[] { "IdCategoria", "IdProducto" }))
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
            return Redirect("/CategoriasProductos/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.CategoriasProducto.Find(id);
                db.CategoriasProducto.Remove(cat);
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

          CategoriasProducto cat = db.CategoriasProducto.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

    }
}