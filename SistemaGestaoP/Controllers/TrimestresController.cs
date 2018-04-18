using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaGestaoP.Models;

namespace SistemaGestaoP.Controllers
{
    public class TrimestresController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Trimestres
        public ActionResult Index()
        {
            return View(db.Trimestres.ToList());
        }

        // GET: Trimestres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = db.Trimestres.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // GET: Trimestres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trimestres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trimestre_id,designacao")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Trimestres.Add(trimestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trimestre);
        }

        // GET: Trimestres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = db.Trimestres.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trimestre_id,designacao")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimestre).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trimestre);
        }

        // GET: Trimestres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = db.Trimestres.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trimestre trimestre = db.Trimestres.Find(id);
            db.Trimestres.Remove(trimestre);
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
