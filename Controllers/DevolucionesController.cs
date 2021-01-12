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
    public class DevolucionesController : Controller
    {
        // GET: Devoluciones
        public ActionResult Index()
    { 
         ModelProyecto db = new ModelProyecto();
        List<Devolucion> devolucion = db.Devolucion.Include(d => d.Garantia).ToList();
            return View(devolucion);
    }

    public ActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Guardar(Devolucion devolucion)
    {
        using (var db = new ModelProyecto())
        {
            db.Devolucion.Add(devolucion);
            db.SaveChanges();
        }
        return Redirect("/Devoluciones/Index");
    }


    [HttpGet]
    public ActionResult Editar(string id)
    {
        ModelProyecto db = new ModelProyecto();
        if (id == null)
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

       Devolucion cat = db.Devolucion.Find(id);

        if (cat == null)
        {
            return HttpNotFound();
        }
        return View(cat);
    }


    [HttpPost]
    public ActionResult Modificar(Devolucion devolucion)
    {
        ModelProyecto db = new ModelProyecto();
        var cat = db.Devolucion.Find(devolucion.IdDevolucion);

        if (TryUpdateModel(cat, "", new string[] {"IdGarantia","IdProducto","Estado","ValorDevuelto" }))
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
        return Redirect("/Devoluciones/Index");
    }


    [HttpGet]
    public ActionResult Eliminar(string id)
    {
        try
        {
            ModelProyecto db = new ModelProyecto();
            var dev = db.Devolucion.Find(id);
            db.Devolucion.Remove(dev);
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

       Devolucion dev = db.Devolucion.Find(id);

        if (dev == null)
        {
            return HttpNotFound();
        }
        return View(dev);
    }



       }
    }
