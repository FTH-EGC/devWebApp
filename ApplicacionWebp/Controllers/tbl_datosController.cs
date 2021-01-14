using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicacionWebp.Models;

namespace ApplicacionWebp.Controllers
{
    public class tbl_datosController : Controller
    {
        private usuariosEntities db = new usuariosEntities();

        // GET: tbl_datos
        public ActionResult Index()
        {
            return View(db.tbl_datos.ToList());
        }

        // GET: tbl_datos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_datos tbl_datos = db.tbl_datos.Find(id);
            if (tbl_datos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_datos);
        }

        // GET: tbl_datos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_datos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellido_paterno,apellido_materno,edad,isactve")] tbl_datos tbl_datos)
        {
            if (ModelState.IsValid)
            {
                db.tbl_datos.Add(tbl_datos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_datos);
        }

        // GET: tbl_datos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_datos tbl_datos = db.tbl_datos.Find(id);
            if (tbl_datos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_datos);
        }

        // POST: tbl_datos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido_paterno,apellido_materno,edad,isactve")] tbl_datos tbl_datos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_datos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_datos);
        }

        // GET: tbl_datos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_datos tbl_datos = db.tbl_datos.Find(id);
            if (tbl_datos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_datos);
        }

        // POST: tbl_datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_datos tbl_datos = db.tbl_datos.Find(id);
            db.tbl_datos.Remove(tbl_datos);
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
