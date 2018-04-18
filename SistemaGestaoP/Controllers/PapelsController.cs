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
    public class PapelsController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Papels
        public ActionResult Index()
        {
            return View(db.Papels.ToList());
        }

        // GET: Papels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papel papel = db.Papels.Find(id);
            if (papel == null)
            {
                return HttpNotFound();
            }
            return View(papel);
        }

        // GET: Papels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Papel_id,designacao")] Papel papel)
        {
            if (ModelState.IsValid)
            {
                db.Papels.Add(papel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(papel);
        }

        // GET: Papels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papel papel = db.Papels.Find(id);
            if (papel == null)
            {
                return HttpNotFound();
            }
            return View(papel);
        }

        // POST: Papels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Papel_id,designacao")] Papel papel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(papel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(papel);
        }

        // GET: Papels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papel papel = db.Papels.Find(id);
            if (papel == null)
            {
                return HttpNotFound();
            }
            return View(papel);
        }

        // POST: Papels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Papel papel = db.Papels.Find(id);
            db.Papels.Remove(papel);
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
