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
    public class CalificacionController : Controller
    {
        private pmpvpbd db = new pmpvpbd();

        // GET: Calificacion
        public ActionResult Index()
        {
            var calificacion = db.Calificacion.Include(c => c.Asignatura).Include(c => c.IncripcionCurso);
            return View(calificacion.ToList());
        }

        // GET: Calificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // GET: Calificacion/Create
        public ActionResult Create()
        {
            ViewBag.AsignaturaID = new SelectList(db.Asignatura, "AsignaturaID", "Nombre");
            ViewBag.IncripcionCursoID = new SelectList(db.IncripcionCurso, "IncripcionCursoID", "IncripcionCursoID");
            return View();
        }

        // POST: Calificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalificacionID,Calificacion1,Calificacion2,Calificacion3,Calificacion4,Calificacion_Final,IncripcionCursoID,AsignaturaID")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Calificacion.Add(calificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsignaturaID = new SelectList(db.Asignatura, "AsignaturaID", "Nombre", calificacion.AsignaturaID);
            ViewBag.IncripcionCursoID = new SelectList(db.IncripcionCurso, "IncripcionCursoID", "IncripcionCursoID", calificacion.IncripcionCursoID);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsignaturaID = new SelectList(db.Asignatura, "AsignaturaID", "Nombre", calificacion.AsignaturaID);
            ViewBag.IncripcionCursoID = new SelectList(db.IncripcionCurso, "IncripcionCursoID", "IncripcionCursoID", calificacion.IncripcionCursoID);
            return View(calificacion);
        }

        // POST: Calificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalificacionID,Calificacion1,Calificacion2,Calificacion3,Calificacion4,Calificacion_Final,IncripcionCursoID,AsignaturaID")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsignaturaID = new SelectList(db.Asignatura, "AsignaturaID", "Nombre", calificacion.AsignaturaID);
            ViewBag.IncripcionCursoID = new SelectList(db.IncripcionCurso, "IncripcionCursoID", "IncripcionCursoID", calificacion.IncripcionCursoID);
            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacion calificacion = db.Calificacion.Find(id);
            db.Calificacion.Remove(calificacion);
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
