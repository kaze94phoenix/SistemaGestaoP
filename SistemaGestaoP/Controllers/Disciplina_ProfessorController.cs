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
    public class Disciplina_ProfessorController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Disciplina_Professor
        public ActionResult Index()
        {
            var disciplina_Professor = db.Disciplina_Professor.Include(d => d.Disciplina).Include(d => d.Professor);
            return View(disciplina_Professor.ToList());
        }

        // GET: Disciplina_Professor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina_Professor disciplina_Professor = db.Disciplina_Professor.Find(id);
            if (disciplina_Professor == null)
            {
                return HttpNotFound();
            }
            return View(disciplina_Professor);
        }

        // GET: Disciplina_Professor/Create
        public ActionResult Create()
        {
            ViewBag.disciplinaFK = new SelectList(db.Disciplinas, "Disciplina_id", "designacao");
            ViewBag.professorFK = new SelectList(db.Professors, "Professor_id", "nome");
            return View();
        }

        // POST: Disciplina_Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisciplinaProfessor_id,disciplinaFK,professorFK")] Disciplina_Professor disciplina_Professor)
        {
            if (ModelState.IsValid)
            {
                db.Disciplina_Professor.Add(disciplina_Professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.disciplinaFK = new SelectList(db.Disciplinas, "Disciplina_id", "designacao", disciplina_Professor.disciplinaFK);
            ViewBag.professorFK = new SelectList(db.Professors, "Professor_id", "nome", disciplina_Professor.professorFK);
            return View(disciplina_Professor);
        }

        // GET: Disciplina_Professor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina_Professor disciplina_Professor = db.Disciplina_Professor.Find(id);
            if (disciplina_Professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.disciplinaFK = new SelectList(db.Disciplinas, "Disciplina_id", "designacao", disciplina_Professor.disciplinaFK);
            ViewBag.professorFK = new SelectList(db.Professors, "Professor_id", "nome", disciplina_Professor.professorFK);
            return View(disciplina_Professor);
        }

        // POST: Disciplina_Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisciplinaProfessor_id,disciplinaFK,professorFK")] Disciplina_Professor disciplina_Professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disciplina_Professor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.disciplinaFK = new SelectList(db.Disciplinas, "Disciplina_id", "designacao", disciplina_Professor.disciplinaFK);
            ViewBag.professorFK = new SelectList(db.Professors, "Professor_id", "nome", disciplina_Professor.professorFK);
            return View(disciplina_Professor);
        }

        // GET: Disciplina_Professor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina_Professor disciplina_Professor = db.Disciplina_Professor.Find(id);
            if (disciplina_Professor == null)
            {
                return HttpNotFound();
            }
            return View(disciplina_Professor);
        }

        // POST: Disciplina_Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disciplina_Professor disciplina_Professor = db.Disciplina_Professor.Find(id);
            db.Disciplina_Professor.Remove(disciplina_Professor);
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
