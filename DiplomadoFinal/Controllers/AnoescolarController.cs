using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomadoFinal.Models;

namespace DiplomadoFinal.Controllers
{
    public class AnoescolarController : Controller
    {
        private pmpvpbd db = new pmpvpbd();

        // GET: Anoescolar
        public ActionResult Index()
        {
            return View(db.Anoescolar.ToList());
        }

        // GET: Anoescolar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anoescolar anoescolar = db.Anoescolar.Find(id);
            if (anoescolar == null)
            {
                return HttpNotFound();
            }
            return View(anoescolar);
        }

        // GET: Anoescolar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anoescolar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ano_EscolarID,Descripcion")] Anoescolar anoescolar)
        {
            if (ModelState.IsValid)
            {
                db.Anoescolar.Add(anoescolar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anoescolar);
        }

        // GET: Anoescolar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anoescolar anoescolar = db.Anoescolar.Find(id);
            if (anoescolar == null)
            {
                return HttpNotFound();
            }
            return View(anoescolar);
        }

        // POST: Anoescolar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ano_EscolarID,Descripcion")] Anoescolar anoescolar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anoescolar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anoescolar);
        }

        // GET: Anoescolar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anoescolar anoescolar = db.Anoescolar.Find(id);
            if (anoescolar == null)
            {
                return HttpNotFound();
            }
            return View(anoescolar);
        }

        // POST: Anoescolar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anoescolar anoescolar = db.Anoescolar.Find(id);
            db.Anoescolar.Remove(anoescolar);
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
