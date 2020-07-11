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
    public class ProfessorsController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Professors
        public ActionResult Index()
        {
            var professors = db.Professors.Include(p => p.Utilizador);
            return View(professors.ToList());
        }

        // GET: Professors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professors/Create
        public ActionResult Create()
        {
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome");
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Professor_id,nome,bi")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome");
            return View(professor);
        }

        // GET: Professors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", professor.utilizadorFK);
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Professor_id,nome,bi,utilizadorFK")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", professor.utilizadorFK);
            return View(professor);
        }

        // GET: Professors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
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

        public ActionResult CriarProfessor()
        {
            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome");
            return View();
        }




        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarProfessor([Bind(Include = "Professor_id,nome,bi,utilizadorFK")] Professor professor)
        {
            var dbT = db.Database.BeginTransaction();
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();
                var username = professor.nome.Split(' ');

                Utilizador user = new Utilizador();
                user.nome = professor.nome;
                user.nomeUtilizador = username[0].ToLower() + "." + username[username.Length - 1].ToLower();
                user.papelFK = 2;
                db.Utilizadors.Add(user);
                db.SaveChanges();

                professor.utilizadorFK = user.Utilizador_id;
                db.Entry(professor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                dbT.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.utilizadorFK = new SelectList(db.Utilizadors, "Utilizador_id", "nome", professor.utilizadorFK);
            return View(professor);
        }

        public ActionResult actualizarUtilizadorProf()
        {
            var dbT = db.Database.BeginTransaction();
            List<int> ids = new List<int>();
            int idAlt = 0;

                foreach (var upUP in db.Professors)
                {

                    if (upUP.utilizadorFK == null)
                    {

                        var username = upUP.nome.Split(' ');

                        Utilizador user = new Utilizador();
                        user.nome = upUP.nome;
                        user.nomeUtilizador = username[0].ToLower() + "." + username[username.Length - 1].ToLower();
                        user.papelFK = 2;
                        db.Utilizadors.Add(user);
                        idAlt++;


                    }
                }
                db.SaveChanges();

            for(int i=idAlt-1; i>=0; i--)
            {
                ids.Add(db.Utilizadors.ToList().Last().Utilizador_id - i);
            }


            foreach (var upUP in db.Professors)
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
            return RedirectToAction("CriarProfessor");
        }
    }
}
