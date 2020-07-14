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
    public class UtilizadorsController : Controller
    {
        private SGPEntities db = new SGPEntities();

        // GET: Utilizadors
        public ActionResult Index()
        {
            var utilizadors = db.Utilizadors.Include(u => u.Endereco).Include(u => u.Genero).Include(u => u.Papel);
            return View(utilizadors.ToList());
        }

        // GET: Utilizadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // GET: Utilizadors/Create
        public ActionResult Create()
        {
            ViewBag.enderecoFK = new SelectList(db.Enderecoes, "Endereco_id", "rua");
            ViewBag.generoFK = new SelectList(db.Generoes, "Genero_id", "designacao");
            ViewBag.papelFK = new SelectList(db.Papels, "Papel_id", "designacao");
            return View();
        }

        // POST: Utilizadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Utilizador_id,nome,palavra_passe,nomeUtilizador,enderecoFK,generoFK,celular,papelFK")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.enderecoFK = new SelectList(db.Enderecoes, "Endereco_id", "rua", utilizador.enderecoFK);
            ViewBag.generoFK = new SelectList(db.Generoes, "Genero_id", "designacao", utilizador.generoFK);
            ViewBag.papelFK = new SelectList(db.Papels, "Papel_id", "designacao", utilizador.papelFK);
            return View(utilizador);
        }

        // GET: Utilizadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.enderecoFK = new SelectList(db.Enderecoes, "Endereco_id", "rua", utilizador.enderecoFK);
            ViewBag.generoFK = new SelectList(db.Generoes, "Genero_id", "designacao", utilizador.generoFK);
            ViewBag.papelFK = new SelectList(db.Papels, "Papel_id", "designacao", utilizador.papelFK);
            return View(utilizador);
        }

        // POST: Utilizadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Utilizador_id,nome,palavra_passe,nomeUtilizador,enderecoFK,generoFK,celular,papelFK")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.enderecoFK = new SelectList(db.Enderecoes, "Endereco_id", "rua", utilizador.enderecoFK);
            ViewBag.generoFK = new SelectList(db.Generoes, "Genero_id", "designacao", utilizador.generoFK);
            ViewBag.papelFK = new SelectList(db.Papels, "Papel_id", "designacao", utilizador.papelFK);
            return View(utilizador);
        }

        // GET: Utilizadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            db.Utilizadors.Remove(utilizador);
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



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utilizador utilizador)
        {
            var user = db.Utilizadors.Where(x => x.nomeUtilizador == utilizador.nomeUtilizador && x.palavra_passe == utilizador.palavra_passe).FirstOrDefault();
            if (user == null)
            {
                utilizador.ErroLogin = "Nome de utilizador e/ou senha incorrectos";
                return View("Login",utilizador);
            }else
            {
                Session["id"] = user.Utilizador_id;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Utilizadors");
        }
    }
}
