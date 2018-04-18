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
    public class Alocacao_Aluno_ProfessorController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Alocacao_Aluno_Professor
        public ActionResult Index()
        {
            var alocacao_Aluno_Professor = db.Alocacao_Aluno_Professor.Include(a => a.Aluno).Include(a => a.Classe_Turma).Include(a => a.Disciplina_Professor);
            return View(alocacao_Aluno_Professor.ToList());
        }

        // GET: Alocacao_Aluno_Professor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Aluno_Professor alocacao_Aluno_Professor = db.Alocacao_Aluno_Professor.Find(id);
            if (alocacao_Aluno_Professor == null)
            {
                return HttpNotFound();
            }
            return View(alocacao_Aluno_Professor);
        }

        // GET: Alocacao_Aluno_Professor/Create
        public ActionResult Create()
        {
            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome");
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id");
            ViewBag.disciplinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id");
            return View();
        }

        // POST: Alocacao_Aluno_Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Alocacao_Aluno_Professor_id,alunoFK,disciplinaProfessorFK,classeTurmaFK,anoLectivo")] Alocacao_Aluno_Professor alocacao_Aluno_Professor)
        {
            if (ModelState.IsValid)
            {
                db.Alocacao_Aluno_Professor.Add(alocacao_Aluno_Professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome", alocacao_Aluno_Professor.alunoFK);
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Aluno_Professor.classeTurmaFK);
            ViewBag.disciplinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id", alocacao_Aluno_Professor.disciplinaProfessorFK);
            return View(alocacao_Aluno_Professor);
        }

        // GET: Alocacao_Aluno_Professor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Aluno_Professor alocacao_Aluno_Professor = db.Alocacao_Aluno_Professor.Find(id);
            if (alocacao_Aluno_Professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome", alocacao_Aluno_Professor.alunoFK);
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Aluno_Professor.classeTurmaFK);
            ViewBag.disciplinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id", alocacao_Aluno_Professor.disciplinaProfessorFK);
            return View(alocacao_Aluno_Professor);
        }

        // POST: Alocacao_Aluno_Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Alocacao_Aluno_Professor_id,alunoFK,disciplinaProfessorFK,classeTurmaFK,anoLectivo")] Alocacao_Aluno_Professor alocacao_Aluno_Professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alocacao_Aluno_Professor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome", alocacao_Aluno_Professor.alunoFK);
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Aluno_Professor.classeTurmaFK);
            ViewBag.disciplinaProfessorFK = new SelectList(db.Disciplina_Professor, "DisciplinaProfessor_id", "DisciplinaProfessor_id", alocacao_Aluno_Professor.disciplinaProfessorFK);
            return View(alocacao_Aluno_Professor);
        }

        // GET: Alocacao_Aluno_Professor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Aluno_Professor alocacao_Aluno_Professor = db.Alocacao_Aluno_Professor.Find(id);
            if (alocacao_Aluno_Professor == null)
            {
                return HttpNotFound();
            }
            return View(alocacao_Aluno_Professor);
        }

        // POST: Alocacao_Aluno_Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alocacao_Aluno_Professor alocacao_Aluno_Professor = db.Alocacao_Aluno_Professor.Find(id);
            db.Alocacao_Aluno_Professor.Remove(alocacao_Aluno_Professor);
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
