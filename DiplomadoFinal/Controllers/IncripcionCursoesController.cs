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
    public class IncripcionCursoesController : Controller
    {
        private pmpvpbd db = new pmpvpbd();

        // GET: IncripcionCursoes
        public ActionResult Index()
        {
            var incripcionCurso = db.IncripcionCurso.Include(i => i.Curso).Include(i => i.Usuario);
            return View(incripcionCurso.ToList());
        }

        // GET: IncripcionCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncripcionCurso incripcionCurso = db.IncripcionCurso.Find(id);
            if (incripcionCurso == null)
            {
                return HttpNotFound();
            }
            return View(incripcionCurso);
        }

        // GET: IncripcionCursoes/Create
        public ActionResult Create()
        {
            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Grado");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Nombres");
            return View();
        }

        // POST: IncripcionCursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncripcionCursoID,CursoID,UsuarioID")] IncripcionCurso incripcionCurso)
        {
            if (ModelState.IsValid)
            {
                db.IncripcionCurso.Add(incripcionCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Grado", incripcionCurso.CursoID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Nombres", incripcionCurso.UsuarioID);
            return View(incripcionCurso);
        }

        // GET: IncripcionCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncripcionCurso incripcionCurso = db.IncripcionCurso.Find(id);
            if (incripcionCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Grado", incripcionCurso.CursoID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Nombres", incripcionCurso.UsuarioID);
            return View(incripcionCurso);
        }

        // POST: IncripcionCursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncripcionCursoID,CursoID,UsuarioID")] IncripcionCurso incripcionCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incripcionCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Grado", incripcionCurso.CursoID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Nombres", incripcionCurso.UsuarioID);
            return View(incripcionCurso);
        }

        // GET: IncripcionCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncripcionCurso incripcionCurso = db.IncripcionCurso.Find(id);
            if (incripcionCurso == null)
            {
                return HttpNotFound();
            }
            return View(incripcionCurso);
        }

        // POST: IncripcionCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncripcionCurso incripcionCurso = db.IncripcionCurso.Find(id);
            db.IncripcionCurso.Remove(incripcionCurso);
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
