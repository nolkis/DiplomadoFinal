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
    public class CursoController : Controller
    {
        private pmpvpbd db = new pmpvpbd();

        // GET: Curso
        public ActionResult Index()
        {
            var curso = db.Curso.Include(c => c.Anoescolar).Include(c => c.Seccion);
            return View(curso.ToList());
        }

        // GET: Curso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            ViewBag.Ano_EscolarID = new SelectList(db.Anoescolar, "Ano_EscolarID", "Descripcion");
            ViewBag.SeccionID = new SelectList(db.Seccion, "SeccionID", "Descripcion");
            return View();
        }

        // POST: Curso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CursoID,Grado,SeccionID,Ano_EscolarID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ano_EscolarID = new SelectList(db.Anoescolar, "Ano_EscolarID", "Descripcion", curso.Ano_EscolarID);
            ViewBag.SeccionID = new SelectList(db.Seccion, "SeccionID", "Descripcion", curso.SeccionID);
            return View(curso);
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ano_EscolarID = new SelectList(db.Anoescolar, "Ano_EscolarID", "Descripcion", curso.Ano_EscolarID);
            ViewBag.SeccionID = new SelectList(db.Seccion, "SeccionID", "Descripcion", curso.SeccionID);
            return View(curso);
        }

        // POST: Curso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoID,Grado,SeccionID,Ano_EscolarID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ano_EscolarID = new SelectList(db.Anoescolar, "Ano_EscolarID", "Descripcion", curso.Ano_EscolarID);
            ViewBag.SeccionID = new SelectList(db.Seccion, "SeccionID", "Descripcion", curso.SeccionID);
            return View(curso);
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Curso.Find(id);
            db.Curso.Remove(curso);
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
