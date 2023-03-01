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
    public class AffeModulesController : Controller
    {
        private Projet_Fin_FormationEntities db = new Projet_Fin_FormationEntities();

        // GET: AffeModules
        public ActionResult Index()
        {
            var affeModules = db.AffeModules.Include(a => a.Module).Include(a => a.Formateur);
            return View(affeModules.ToList());
        }

        // GET: AffeModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AffeModule affeModule = db.AffeModules.Find(id);
            if (affeModule == null)
            {
                return HttpNotFound();
            }
            return View(affeModule);
        }

        // GET: AffeModules/Create
        public ActionResult Create()
        {
            ViewBag.codeM = new SelectList(db.Modules, "codeM", "nomM");
            ViewBag.numFormateur = new SelectList(db.Formateurs, "numFormateur", "nom");
            return View();
        }

        // POST: AffeModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numAff,numFormateur,codeM")] AffeModule affeModule)
        {
            if (ModelState.IsValid)
            {
                db.AffeModules.Add(affeModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeM = new SelectList(db.Modules, "codeM", "nomM", affeModule.codeM);
            ViewBag.numFormateur = new SelectList(db.Formateurs, "numFormateur", "nom", affeModule.numFormateur);
            return View(affeModule);
        }

        // GET: AffeModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AffeModule affeModule = db.AffeModules.Find(id);
            if (affeModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeM = new SelectList(db.Modules, "codeM", "nomM", affeModule.codeM);
            ViewBag.numFormateur = new SelectList(db.Formateurs, "numFormateur", "nom", affeModule.numFormateur);
            return View(affeModule);
        }

        // POST: AffeModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numAff,numFormateur,codeM")] AffeModule affeModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(affeModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeM = new SelectList(db.Modules, "codeM", "nomM", affeModule.codeM);
            ViewBag.numFormateur = new SelectList(db.Formateurs, "numFormateur", "nom", affeModule.numFormateur);
            return View(affeModule);
        }

        // GET: AffeModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AffeModule affeModule = db.AffeModules.Find(id);
            if (affeModule == null)
            {
                return HttpNotFound();
            }
            return View(affeModule);
        }

        // POST: AffeModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AffeModule affeModule = db.AffeModules.Find(id);
            db.AffeModules.Remove(affeModule);
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
