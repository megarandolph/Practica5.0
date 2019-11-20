using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using practicacinco.cero;

namespace practicacinco.cero.Controllers
{
    public class contactoController : Controller
    {
        private practica5Entities db = new practica5Entities();

        // GET: contacto
        public ActionResult Index(String Nombre, String Celular)
        {
            var busqueda = from s in db.contactos select s;

            if (!String.IsNullOrEmpty(Nombre))
            {
                busqueda = busqueda.Where(s => s.nombre.Contains(Nombre));
            }
            else if (!String.IsNullOrEmpty(Celular))
            {
                busqueda = busqueda.Where(s => s.celular.Contains(Celular));
            }
            return View(busqueda.ToList());
        }

        // GET: contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return HttpNotFound();
            }
            return View(contactos);
        }

        // GET: contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "contactoId,nombre,celular,email,direccion")] contactos contactos)
        {
            if (ModelState.IsValid)
            {
                db.contactos.Add(contactos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactos);
        }

        // GET: contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return HttpNotFound();
            }
            return View(contactos);
        }

        // POST: contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "contactoId,nombre,celular,email,direccion")] contactos contactos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactos);
        }

        // GET: contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return HttpNotFound();
            }
            return View(contactos);
        }

        // POST: contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactos contactos = db.contactos.Find(id);
            db.contactos.Remove(contactos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
