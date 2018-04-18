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
    public class Tipo_AvaliacaoController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Tipo_Avaliacao
        public ActionResult Index()
        {
            return View(db.Tipo_Avaliacao.ToList());
        }

        // GET: Tipo_Avaliacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Avaliacao tipo_Avaliacao = db.Tipo_Avaliacao.Find(id);
            if (tipo_Avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Avaliacao);
        }

        // GET: Tipo_Avaliacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Avaliacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoAvaliacao_id,designacao")] Tipo_Avaliacao tipo_Avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Avaliacao.Add(tipo_Avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Avaliacao);
        }

        // GET: Tipo_Avaliacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Avaliacao tipo_Avaliacao = db.Tipo_Avaliacao.Find(id);
            if (tipo_Avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Avaliacao);
        }

        // POST: Tipo_Avaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoAvaliacao_id,designacao")] Tipo_Avaliacao tipo_Avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Avaliacao);
        }

        // GET: Tipo_Avaliacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Avaliacao tipo_Avaliacao = db.Tipo_Avaliacao.Find(id);
            if (tipo_Avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Avaliacao);
        }

        // POST: Tipo_Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Avaliacao tipo_Avaliacao = db.Tipo_Avaliacao.Find(id);
            db.Tipo_Avaliacao.Remove(tipo_Avaliacao);
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
