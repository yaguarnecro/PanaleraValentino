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
    public class TipoEmpleadoController : Controller
    {
        // GET: TipoEmpleado
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<TipoEmpleados> tipoempleados = db.TipoEmpleados.Include(d => d.Empleados).ToList();
            return View(tipoempleados);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(TipoEmpleados tipoempleados)
        {
            using (var db = new ModelProyecto())
            {
                db.TipoEmpleados.Add(tipoempleados);
                db.SaveChanges();
            }
            return Redirect("/TipoEmpleado/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            TipoEmpleados cat = db.TipoEmpleados.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(TipoEmpleados tipoempleados)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.TipoEmpleados.Find(tipoempleados.IdTipoEmpleado);

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
            return Redirect("/TipoEmpleado/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.TipoEmpleados.Find(id);
                db.TipoEmpleados.Remove(cat);
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

            TipoEmpleados cat = db.TipoEmpleados.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
    }
}