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
    public class AlunoesController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Alunoes
        public ActionResult Index()
        {
            var alunoes = db.Alunoes.Include(a => a.Utilizador);
            return View(alunoes.ToList());
        }

        // GET: Alunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunoes/Create
        public ActionResult Create()
        {
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome");
            return View();
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Aluno_id,nome,nomepai,nomemae,bi,datanascimento,utilizadorFK")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", aluno.utilizadorFK);
            return View(aluno);
        }





        // GET: Alunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", aluno.utilizadorFK);
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Aluno_id,nome,nomepai,nomemae,bi,datanascimento,utilizadorFK")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", aluno.utilizadorFK);
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunoes.Find(id);
            db.Alunoes.Remove(aluno);
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



        public ActionResult CriarAluno
            ()
        {
           // ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarAluno([Bind(Include = "Aluno_id,nome,bi,utilizadorFK")] Aluno aluno)
        {
            var dbT = db.Database.BeginTransaction();
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                var username = aluno.nome.Split(' ');

                Utilizador user = new Utilizador();
                user.nome = aluno.nome;
                user.nomeUtilizador = username[0].ToLower() + "." + username[username.Length - 1].ToLower();
                user.papelFK = 3;
                db.Utilizadors.Add(user);
                db.SaveChanges();

                aluno.utilizadorFK = user.Utilizador_id;
                db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                dbT.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", aluno.utilizadorFK);
            return View();
        }


        public ActionResult actualizarUtilizadorAluno()
        {
            var dbT = db.Database.BeginTransaction();
            List<int> ids = new List<int>();
            int idAlt = 0;

            foreach (var upUP in db.Alunoes)
            {

                if (upUP.utilizadorFK == null)
                {

                    var username = upUP.nome.Split(' ');

                    Utilizador user = new Utilizador();
                    user.nome = upUP.nome;
                    user.nomeUtilizador = username[0].ToLower() + "." + username[username.Length - 1].ToLower();
                    user.papelFK = 3;
                    db.Utilizadors.Add(user);
                    idAlt++;


                }
            }
            db.SaveChanges();

            for (int i = idAlt - 1; i >= 0; i--)
            {
                ids.Add(db.Utilizadors.ToList().Last().Utilizador_id - i);
            }


            foreach (var upUP in db.Alunoes)
            {

                if (upUP.utilizadorFK == null)
                {
                    upUP.utilizadorFK = ids.ElementAt(0);
                    db.Entry(upUP).State = System.Data.Entity.EntityState.Modified;
                    ids.RemoveAt(0);
                }
            }
            db.SaveChanges();

            dbT.Commit();
            return RedirectToAction("CriarAluno");
        }

    }
}
