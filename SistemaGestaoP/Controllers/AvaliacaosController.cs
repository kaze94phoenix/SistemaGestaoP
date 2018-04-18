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
    public class AvaliacaosController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Avaliacaos
        public ActionResult Index()
        {
            var avaliacaos = db.Avaliacaos.Include(a => a.Alocacao_Aluno_Professor).Include(a => a.Tipo_Avaliacao).Include(a => a.Trimestre);
            return View(avaliacaos.ToList());
        }

        // GET: Avaliacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacaos.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public ActionResult Create()
        {
            ViewBag.alocacaoAlunoProfessorFK = new SelectList(db.Alocacao_Aluno_Professor, "Alocacao_Aluno_Professor_id", "Alocacao_Aluno_Professor_id");
            ViewBag.tipoAvaliacaoFK = new SelectList(db.Tipo_Avaliacao, "TipoAvaliacao_id", "TipoAvaliacao_id");
            ViewBag.trimestreFK = new SelectList(db.Trimestres, "Trimestre_id", "designacao");
            return View();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Avaliacao_id,tipoAvaliacaoFK,trimestreFK,alocacaoAlunoProfessorFK,nota")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacaos.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alocacaoAlunoProfessorFK = new SelectList(db.Alocacao_Aluno_Professor, "Alocacao_Aluno_Professor_id", "Alocacao_Aluno_Professor_id", avaliacao.alocacaoAlunoProfessorFK);
            ViewBag.tipoAvaliacaoFK = new SelectList(db.Tipo_Avaliacao, "TipoAvaliacao_id", "TipoAvaliacao_id", avaliacao.tipoAvaliacaoFK);
            ViewBag.trimestreFK = new SelectList(db.Trimestres, "Trimestre_id", "designacao", avaliacao.trimestreFK);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacaos.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.alocacaoAlunoProfessorFK = new SelectList(db.Alocacao_Aluno_Professor, "Alocacao_Aluno_Professor_id", "Alocacao_Aluno_Professor_id", avaliacao.alocacaoAlunoProfessorFK);
            ViewBag.tipoAvaliacaoFK = new SelectList(db.Tipo_Avaliacao, "TipoAvaliacao_id", "TipoAvaliacao_id", avaliacao.tipoAvaliacaoFK);
            ViewBag.trimestreFK = new SelectList(db.Trimestres, "Trimestre_id", "designacao", avaliacao.trimestreFK);
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Avaliacao_id,tipoAvaliacaoFK,trimestreFK,alocacaoAlunoProfessorFK,nota")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alocacaoAlunoProfessorFK = new SelectList(db.Alocacao_Aluno_Professor, "Alocacao_Aluno_Professor_id", "Alocacao_Aluno_Professor_id", avaliacao.alocacaoAlunoProfessorFK);
            ViewBag.tipoAvaliacaoFK = new SelectList(db.Tipo_Avaliacao, "TipoAvaliacao_id", "TipoAvaliacao_id", avaliacao.tipoAvaliacaoFK);
            ViewBag.trimestreFK = new SelectList(db.Trimestres, "Trimestre_id", "designacao", avaliacao.trimestreFK);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacaos.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        public void gerarAvaliacao(int idTrimestre, int idTipoAvaliacao, int disciplinaProf, int classeTurma, int anoLectivo)
        {
            //List<int> aAP = new List<int>();
            foreach (Alocacao_Aluno_Professor a in db.Alocacao_Aluno_Professor)
            {
                if(a.disciplinaProfessorFK == disciplinaProf && a.classeTurmaFK==classeTurma && a.anoLectivo == anoLectivo)
                {
                    Avaliacao avali = new Avaliacao();
                    avali.tipoAvaliacaoFK = idTipoAvaliacao;
                    avali.trimestreFK = idTrimestre;
                    avali.alocacaoAlunoProfessorFK = a.Alocacao_Aluno_Professor_id;
                    db.Avaliacaos.Add(avali);
                    
                }
            }
            db.SaveChanges();
        }
        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacaos.Find(id);
            db.Avaliacaos.Remove(avaliacao);
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
