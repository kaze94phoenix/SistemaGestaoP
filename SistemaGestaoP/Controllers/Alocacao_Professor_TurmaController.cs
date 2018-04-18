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
    public class Alocacao_Professor_TurmaController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Alocacao_Professor_Turma
        public ActionResult Index()
        {
            var alocacao_Professor_Turma = db.Alocacao_Professor_Turma.Include(a => a.Classe_Turma).Include(a => a.Disciplina_Professor);
            return View(alocacao_Professor_Turma.ToList());
        }

        // GET: Alocacao_Professor_Turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Professor_Turma alocacao_Professor_Turma = db.Alocacao_Professor_Turma.Find(id);
            if (alocacao_Professor_Turma == null)
            {
                return HttpNotFound();
            }
            return View(alocacao_Professor_Turma);
        }

        // GET: Alocacao_Professor_Turma/Create
        public ActionResult Create()
        {
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id");
            ViewBag.displinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id");
            return View();
        }

        // POST: Alocacao_Professor_Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlocacaoProfessorTurma_id,displinaProfessorFK,classeTurmaFK,anoLectivo")] Alocacao_Professor_Turma alocacao_Professor_Turma)
        {
            if (ModelState.IsValid)
            {
                db.Alocacao_Professor_Turma.Add(alocacao_Professor_Turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Professor_Turma.classeTurmaFK);
            ViewBag.displinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id", alocacao_Professor_Turma.displinaProfessorFK);
            return View(alocacao_Professor_Turma);
        }

        // GET: Alocacao_Professor_Turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Professor_Turma alocacao_Professor_Turma = db.Alocacao_Professor_Turma.Find(id);
            if (alocacao_Professor_Turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Professor_Turma.classeTurmaFK);
            ViewBag.displinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id", alocacao_Professor_Turma.displinaProfessorFK);
            return View(alocacao_Professor_Turma);
        }

        // POST: Alocacao_Professor_Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlocacaoProfessorTurma_id,displinaProfessorFK,classeTurmaFK,anoLectivo")] Alocacao_Professor_Turma alocacao_Professor_Turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alocacao_Professor_Turma).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Professor_Turma.classeTurmaFK);
            ViewBag.displinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id", alocacao_Professor_Turma.displinaProfessorFK);
            return View(alocacao_Professor_Turma);
        }

        // GET: Alocacao_Professor_Turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Professor_Turma alocacao_Professor_Turma = db.Alocacao_Professor_Turma.Find(id);
            if (alocacao_Professor_Turma == null)
            {
                return HttpNotFound();
            }
            return View(alocacao_Professor_Turma);
        }

        // POST: Alocacao_Professor_Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alocacao_Professor_Turma alocacao_Professor_Turma = db.Alocacao_Professor_Turma.Find(id);
            db.Alocacao_Professor_Turma.Remove(alocacao_Professor_Turma);
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
