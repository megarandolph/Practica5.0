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
    public class integrantesGController : Controller
    {
        private practica5Entities db = new practica5Entities();

        // GET: integrantesG
        public ActionResult Index(String Nombre)
        {
            var busqueda = from s in db.integrantesG select s;


            busqueda = busqueda.Where(s => s.nombre.Contains(Nombre));

            return View(busqueda.ToList());
        }
    

        // GET: integrantesG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            integrantesG integrantesG = db.integrantesG.Find(id);
            if (integrantesG == null)
            {
                return HttpNotFound();
            }
            return View(integrantesG);
        }

        // GET: integrantesG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: integrantesG/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "integrantesId,nombre,asignaturas")] integrantesG integrantesG)
        {
            if (ModelState.IsValid)
            {
                db.integrantesG.Add(integrantesG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(integrantesG);
        }

        // GET: integrantesG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            integrantesG integrantesG = db.integrantesG.Find(id);
            if (integrantesG == null)
            {
                return HttpNotFound();
            }
            return View(integrantesG);
        }

        // POST: integrantesG/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "integrantesId,nombre,asignaturas")] integrantesG integrantesG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integrantesG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(integrantesG);
        }

        // GET: integrantesG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            integrantesG integrantesG = db.integrantesG.Find(id);
            if (integrantesG == null)
            {
                return HttpNotFound();
            }
            return View(integrantesG);
        }

        // POST: integrantesG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            integrantesG integrantesG = db.integrantesG.Find(id);
            db.integrantesG.Remove(integrantesG);
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
