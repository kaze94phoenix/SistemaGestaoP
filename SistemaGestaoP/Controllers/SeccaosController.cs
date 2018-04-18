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
    public class SeccaosController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Seccaos
        public ActionResult Index()
        {
            return View(db.Seccaos.ToList());
        }

        // GET: Seccaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccao seccao = db.Seccaos.Find(id);
            if (seccao == null)
            {
                return HttpNotFound();
            }
            return View(seccao);
        }

        // GET: Seccaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seccaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Seccao_id,designacao")] Seccao seccao)
        {
            if (ModelState.IsValid)
            {
                db.Seccaos.Add(seccao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seccao);
        }

        // GET: Seccaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccao seccao = db.Seccaos.Find(id);
            if (seccao == null)
            {
                return HttpNotFound();
            }
            return View(seccao);
        }

        // POST: Seccaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Seccao_id,designacao")] Seccao seccao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seccao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seccao);
        }

        // GET: Seccaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccao seccao = db.Seccaos.Find(id);
            if (seccao == null)
            {
                return HttpNotFound();
            }
            return View(seccao);
        }

        // POST: Seccaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seccao seccao = db.Seccaos.Find(id);
            db.Seccaos.Remove(seccao);
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
