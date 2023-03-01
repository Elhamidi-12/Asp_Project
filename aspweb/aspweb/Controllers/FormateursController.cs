using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aspweb.Models;

namespace aspweb.Controllers
{
    public class FormateursController : Controller
    {
        private Projet_Fin_FormationEntities db = new Projet_Fin_FormationEntities();

        // GET: Formateurs
        public ActionResult Index()
        {
            return View(db.Formateurs.ToList());
        }

        // GET: Formateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return HttpNotFound();
            }
            return View(formateur);
        }

        // GET: Formateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numFormateur,nom,prenom")] Formateur formateur)
        {
            if (ModelState.IsValid)
            {
                db.Formateurs.Add(formateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formateur);
        }

        // GET: Formateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return HttpNotFound();
            }
            return View(formateur);
        }

        // POST: Formateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numFormateur,nom,prenom")] Formateur formateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formateur);
        }

        // GET: Formateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return HttpNotFound();
            }
            return View(formateur);
        }

        // POST: Formateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formateur formateur = db.Formateurs.Find(id);
            db.Formateurs.Remove(formateur);
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
