using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JuvekSoft.Models;

namespace JuvekSoft.Controllers
{
    public class FacetingTypesController : Controller
    {
        private Model1 db = new Model1();

        // GET: FacetingTypes
        public ActionResult Index()
        {
            return View(db.FacetingTypes.ToList());
        }

        // GET: FacetingTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacetingType facetingType = db.FacetingTypes.Find(id);
            if (facetingType == null)
            {
                return HttpNotFound();
            }
            return View(facetingType);
        }

        // GET: FacetingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacetingTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FacName")] FacetingType facetingType)
        {
            if (ModelState.IsValid)
            {
                db.FacetingTypes.Add(facetingType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facetingType);
        }

        // GET: FacetingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacetingType facetingType = db.FacetingTypes.Find(id);
            if (facetingType == null)
            {
                return HttpNotFound();
            }
            return View(facetingType);
        }

        // POST: FacetingTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FacName")] FacetingType facetingType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facetingType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facetingType);
        }

        // GET: FacetingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacetingType facetingType = db.FacetingTypes.Find(id);
            if (facetingType == null)
            {
                return HttpNotFound();
            }
            return View(facetingType);
        }

        // POST: FacetingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacetingType facetingType = db.FacetingTypes.Find(id);
            db.FacetingTypes.Remove(facetingType);
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
