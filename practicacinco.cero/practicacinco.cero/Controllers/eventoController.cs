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
    public class eventoController : Controller
    {
        private practica5Entities db = new practica5Entities();

        // GET: evento
        public ActionResult Index(String Evento, String Fecha)
        {
            var busqueda = from s in db.eventos select s;

            if (!String.IsNullOrEmpty(Evento))
            {
                busqueda = busqueda.Where(s => s.descripcion.Contains(Evento));
            }
            else if (!String.IsNullOrEmpty(Fecha))
            {
                busqueda = busqueda.Where(s => s.fecha.Contains(Fecha));
            }
            return View(busqueda.ToList());
        }

        // GET: evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos eventos = db.eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // GET: evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventoId,descripcion,fecha,hora")] eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.eventos.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventos);
        }

        // GET: evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos eventos = db.eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventoId,descripcion,fecha,hora")] eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos);
        }

        // GET: evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos eventos = db.eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventos eventos = db.eventos.Find(id);
            db.eventos.Remove(eventos);
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
