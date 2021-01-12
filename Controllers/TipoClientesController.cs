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
    public class TipoClientesController : Controller
    {
        // GET: TipoClientes
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Tipoclientes> tipoclientes = db.Tipoclientes.Include(d => d.Clientes).ToList();
            return View(tipoclientes);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Tipoclientes tipoclientes)
        {
            using (var db = new ModelProyecto())
            {
                db.Tipoclientes.Add(tipoclientes);
                db.SaveChanges();
            }
            return Redirect("/TipoClientes/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Tipoclientes cat = db.Tipoclientes.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(Tipoclientes tipoclientes)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Tipoclientes.Find(tipoclientes.IdTipoCliente);

            if (TryUpdateModel(cat, "", new string[] { "Descripcion" }))
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
            return Redirect("/TipoClientes/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Tipoclientes.Find(id);
                db.Tipoclientes.Remove(cat);
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

            Tipoclientes cat = db.Tipoclientes.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
    }
}