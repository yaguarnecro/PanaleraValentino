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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<Clientes> clientes = db.Clientes.Include(E => E.Tipoclientes).ToList();
            return View(clientes);
        }


        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(Clientes clientes)
        {
            using (var db = new ModelProyecto())
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
            }
            return Redirect("/Clientes/Index");
        }


        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Clientes cli = db.Clientes.Find(id);

            if (cli == null)
            {
                return HttpNotFound();
            }
            return View(cli);
        }

        [HttpPost]
        public ActionResult Modificar(Clientes clientes)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.Clientes.Find(clientes.Cedula);

            if (TryUpdateModel(cat, "", new string[] { "IdTipocliente", "PrimerNombre", "SegundoNombre", "PrimerApellido", "SegundoApellido", "Telefono", "CorreoElectronico" }))
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
            return Redirect("/Clientes/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.Clientes.Find(id);
                db.Clientes.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException c)
            {
                ModelState.AddModelError(" ", c);

            }
            return RedirectToAction("Index");
        }


        public ActionResult Detalles(int? id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

           Clientes cat = db.Clientes.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

      

    }
}