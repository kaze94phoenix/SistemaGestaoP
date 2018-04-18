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
    public class Classe_TurmaController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Classe_Turma
        public ActionResult Index()
        {
            var classe_Turma = db.Classe_Turma.Include(c => c.Classe).Include(c => c.Seccao).Include(c => c.Turma).Include(c => c.Turno);
            return View(classe_Turma.ToList());
        }

        // GET: Classe_Turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe_Turma classe_Turma = db.Classe_Turma.Find(id);
            if (classe_Turma == null)
            {
                return HttpNotFound();
            }
            return View(classe_Turma);
        }

        // GET: Classe_Turma/Create
        public ActionResult Create()
        {
            ViewBag.classeFK = new SelectList(db.Classes, "Classe_id", "designacao");
            ViewBag.seccaoFK = new SelectList(db.Seccaos, "Seccao_id", "designacao");
            ViewBag.turmaFK = new SelectList(db.Turmas, "Turma_id", "designacao");
            ViewBag.turnoFK = new SelectList(db.Turnoes, "Turno_id", "designacao");
            return View();
        }

        // POST: Classe_Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClasseTurma_id,classeFK,turmaFK,turnoFK,seccaoFK")] Classe_Turma classe_Turma)
        {
            if (ModelState.IsValid)
            {
                db.Classe_Turma.Add(classe_Turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.classeFK = new SelectList(db.Classes, "Classe_id", "designacao", classe_Turma.classeFK);
            ViewBag.seccaoFK = new SelectList(db.Seccaos, "Seccao_id", "designacao", classe_Turma.seccaoFK);
            ViewBag.turmaFK = new SelectList(db.Turmas, "Turma_id", "designacao", classe_Turma.turmaFK);
            ViewBag.turnoFK = new SelectList(db.Turnoes, "Turno_id", "designacao", classe_Turma.turnoFK);
            return View(classe_Turma);
        }

        // GET: Classe_Turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe_Turma classe_Turma = db.Classe_Turma.Find(id);
            if (classe_Turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.classeFK = new SelectList(db.Classes, "Classe_id", "designacao", classe_Turma.classeFK);
            ViewBag.seccaoFK = new SelectList(db.Seccaos, "Seccao_id", "designacao", classe_Turma.seccaoFK);
            ViewBag.turmaFK = new SelectList(db.Turmas, "Turma_id", "designacao", classe_Turma.turmaFK);
            ViewBag.turnoFK = new SelectList(db.Turnoes, "Turno_id", "designacao", classe_Turma.turnoFK);
            return View(classe_Turma);
        }

        // POST: Classe_Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClasseTurma_id,classeFK,turmaFK,turnoFK,seccaoFK")] Classe_Turma classe_Turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classe_Turma).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.classeFK = new SelectList(db.Classes, "Classe_id", "designacao", classe_Turma.classeFK);
            ViewBag.seccaoFK = new SelectList(db.Seccaos, "Seccao_id", "designacao", classe_Turma.seccaoFK);
            ViewBag.turmaFK = new SelectList(db.Turmas, "Turma_id", "designacao", classe_Turma.turmaFK);
            ViewBag.turnoFK = new SelectList(db.Turnoes, "Turno_id", "designacao", classe_Turma.turnoFK);
            return View(classe_Turma);
        }

        // GET: Classe_Turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe_Turma classe_Turma = db.Classe_Turma.Find(id);
            if (classe_Turma == null)
            {
                return HttpNotFound();
            }
            return View(classe_Turma);
        }

        // POST: Classe_Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classe_Turma classe_Turma = db.Classe_Turma.Find(id);
            db.Classe_Turma.Remove(classe_Turma);
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
