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
    public class Alocacao_Aluno_TurmaController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Alocacao_Aluno_Turma
        public ActionResult Index()
        {
            var alocacao_Aluno_Turma = db.Alocacao_Aluno_Turma.Include(a => a.Aluno).Include(a => a.Classe_Turma);
            return View(alocacao_Aluno_Turma.ToList());
        }

        // GET: Alocacao_Aluno_Turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Aluno_Turma alocacao_Aluno_Turma = db.Alocacao_Aluno_Turma.Find(id);
            if (alocacao_Aluno_Turma == null)
            {
                return HttpNotFound();
            }
            return View(alocacao_Aluno_Turma);
        }

        // GET: Alocacao_Aluno_Turma/Create
        public ActionResult Create()
        {
            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome");
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id");
            return View();
        }

        // POST: Alocacao_Aluno_Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlocacaoAlunoTurma_id,alunoFK,classeTurmaFK,anoLectivo")] Alocacao_Aluno_Turma alocacao_Aluno_Turma)
        {
            if (ModelState.IsValid)
            {
                db.Alocacao_Aluno_Turma.Add(alocacao_Aluno_Turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome", alocacao_Aluno_Turma.alunoFK);
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Aluno_Turma.classeTurmaFK);
            return View(alocacao_Aluno_Turma);
        }

        // GET: Alocacao_Aluno_Turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Aluno_Turma alocacao_Aluno_Turma = db.Alocacao_Aluno_Turma.Find(id);
            if (alocacao_Aluno_Turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome", alocacao_Aluno_Turma.alunoFK);
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Aluno_Turma.classeTurmaFK);
            return View(alocacao_Aluno_Turma);
        }

        // POST: Alocacao_Aluno_Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlocacaoAlunoTurma_id,alunoFK,classeTurmaFK,anoLectivo")] Alocacao_Aluno_Turma alocacao_Aluno_Turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alocacao_Aluno_Turma).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alunoFK = new SelectList(db.Alunoes, "Aluno_id", "nome", alocacao_Aluno_Turma.alunoFK);
            ViewBag.classeTurmaFK = new SelectList(db.Classe_Turma, "ClasseTurma_id", "ClasseTurma_id", alocacao_Aluno_Turma.classeTurmaFK);
            return View(alocacao_Aluno_Turma);
        }

        // GET: Alocacao_Aluno_Turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alocacao_Aluno_Turma alocacao_Aluno_Turma = db.Alocacao_Aluno_Turma.Find(id);
            if (alocacao_Aluno_Turma == null)
            {
                return HttpNotFound();
            }
            return View(alocacao_Aluno_Turma);
        }

        // POST: Alocacao_Aluno_Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alocacao_Aluno_Turma alocacao_Aluno_Turma = db.Alocacao_Aluno_Turma.Find(id);
            db.Alocacao_Aluno_Turma.Remove(alocacao_Aluno_Turma);
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
