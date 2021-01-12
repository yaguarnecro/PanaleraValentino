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
    public class GarantiaController : Controller
    {
        // GET: Garantia
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Garantia> garantia = db.Garantia.Include(d => d.Devolucion).ToList();
            return View(garantia);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Garantia garantia)
        {
            using (var db = new ModelProyecto())
            {
                db.Garantia.Add(garantia);
                db.SaveChanges();
            }
            return Redirect("/Garantia/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Garantia cat = db.Garantia.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(Garantia garantia)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Garantia.Find(garantia.IdGarantia);

            if (TryUpdateModel(cat, "", new string[] { "Descripcion", "EstadoActivo" }))
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
            return Redirect("/Garantia/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Garantia.Find(id);
                db.Garantia.Remove(cat);
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

            Garantia cat = db.Garantia.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
    }
    
}