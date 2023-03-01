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
    public class FillieresController : Controller
    {
        private Projet_Fin_FormationEntities db = new Projet_Fin_FormationEntities();

        // GET: Fillieres
        public ActionResult Index()
        {
            var fillieres = db.Fillieres.Include(f => f.Secteur);
            return View(fillieres.ToList());
        }

        // GET: Fillieres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filliere filliere = db.Fillieres.Find(id);
            if (filliere == null)
            {
                return HttpNotFound();
            }
            return View(filliere);
        }

        // GET: Fillieres/Create
        public ActionResult Create()
        {
            ViewBag.codeSecteur = new SelectList(db.Secteurs, "codeSecteur", "nomSecteur");
            return View();
        }

        // POST: Fillieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeFil,nomF,codeSecteur")] Filliere filliere)
        {
            if (ModelState.IsValid)
            {
                db.Fillieres.Add(filliere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeSecteur = new SelectList(db.Secteurs, "codeSecteur", "nomSecteur", filliere.codeSecteur);
            return View(filliere);
        }

        // GET: Fillieres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filliere filliere = db.Fillieres.Find(id);
            if (filliere == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeSecteur = new SelectList(db.Secteurs, "codeSecteur", "nomSecteur", filliere.codeSecteur);
            return View(filliere);
        }

        // POST: Fillieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeFil,nomF,codeSecteur")] Filliere filliere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filliere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeSecteur = new SelectList(db.Secteurs, "codeSecteur", "nomSecteur", filliere.codeSecteur);
            return View(filliere);
        }

        // GET: Fillieres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filliere filliere = db.Fillieres.Find(id);
            if (filliere == null)
            {
                return HttpNotFound();
            }
            return View(filliere);
        }

        // POST: Fillieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filliere filliere = db.Fillieres.Find(id);
            db.Fillieres.Remove(filliere);
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
