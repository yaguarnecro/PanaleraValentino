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
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Empleados> empleados = db.Empleados.Include(d => d.TipoEmpleados).ToList();
            return View(empleados);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Empleados empleados)
        {
            using (var db = new ModelProyecto())
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
            }
            return Redirect("/Empleados/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Empleados cat = db.Empleados.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(Empleados empleados)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Empleados.Find(empleados.IdEmpleado);

            if (TryUpdateModel(cat, "", new string[] {"PrimerNombre","SegundoNombre","PrimerApellido","SegundoApellido","Edad","Telefono","Direccion","TipoEmpleado"}))
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
            return Redirect("/Empleados/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Empleados.Find(id);
                db.Empleados.Remove(cat);
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

            Empleados cat = db.Empleados.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

    }
}
