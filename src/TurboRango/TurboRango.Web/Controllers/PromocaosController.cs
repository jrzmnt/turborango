using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurboRango.Dominio;
using TurboRango.Web.Models;

namespace TurboRango.Web
{
    public class PromocaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Promocaos
        public ActionResult Index()
        {
            return View(db.Promocaos.Include(x => x.Restaurante).ToList());
        }

        // GET: Promocaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocaos.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // GET: Promocaos/Create
        public ActionResult Create()
        {
            ViewBag.Restaurantes = db.Restaurantes.ToList();
            return View();
        }

        // POST: Promocaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestauranteId,ValorPromocao,TerminoPromocao")] CriarPromocaoViewModel criarPromocao)
        {
            if (ModelState.IsValid)
            {
                var restaurante = db.Restaurantes.Find(criarPromocao.RestauranteId);

                var promocao = new Promocao
                {
                    Restaurante = restaurante,
                    TerminoPromocao = criarPromocao.TerminoPromocao,
                    ValorPromocao = criarPromocao.ValorPromocao
                };

                db.Promocaos.Add(promocao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Promocaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocaos.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // POST: Promocaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ValorPromocao,TerminoPromocao")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocao);
        }

        // GET: Promocaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocaos.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // POST: Promocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocao promocao = db.Promocaos.Find(id);
            db.Promocaos.Remove(promocao);
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
