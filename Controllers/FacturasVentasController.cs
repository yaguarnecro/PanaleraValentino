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
    public class FacturasVentasController : Controller
    {
        // GET: FacturasVentas
        public ActionResult Index()
        {
            ModelProyecto db = new ModelProyecto();
            List<FacturasVentas> facturasventas = db.FacturasVentas.Include(d => d.Clientes).ToList();
            return View(facturasventas);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(FacturasVentas facturasventas)
        {
            using (var db = new ModelProyecto())
            {
                db.FacturasVentas.Add(facturasventas);
                db.SaveChanges();
            }
            return Redirect("/FacturasVentas/Index");
        }


        [HttpGet]
        public ActionResult Editar(string id)
        {
            ModelProyecto db = new ModelProyecto();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            FacturasVentas cat = db.FacturasVentas.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult Modificar(FacturasVentas facturasventas)
        {
            ModelProyecto db = new ModelProyecto();
            var cat = db.FacturasVentas.Find(facturasventas.IdFacturaVenta);

            if (TryUpdateModel(cat, "", new string[] { "IdProducto", "IdEmpleado", "CedulaCliente", "PrecioProducto", "Cantidad", "PrecioTotal", "Iva","Fecha" }))
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
            return Redirect("/FacturasVentas/Index");
        }


        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            try
            {
                ModelProyecto db = new ModelProyecto();
                var cat = db.FacturasVentas.Find(id);
                db.FacturasVentas.Remove(cat);
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

            FacturasVentas cat = db.FacturasVentas.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
    }
    
}