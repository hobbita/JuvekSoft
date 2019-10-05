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
    public class MetalTypesController : Controller
    {
        private Model1 db = new Model1();

        // GET: MetalTypes
        public ActionResult Index()
        {
            return View(db.MetalTypes.ToList());
        }

        // GET: MetalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalType metalType = db.MetalTypes.Find(id);
            if (metalType == null)
            {
                return HttpNotFound();
            }
            return View(metalType);
        }

        // GET: MetalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetalTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MetTypeName")] MetalType metalType)
        {
            if (ModelState.IsValid)
            {
                db.MetalTypes.Add(metalType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metalType);
        }

        // GET: MetalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalType metalType = db.MetalTypes.Find(id);
            if (metalType == null)
            {
                return HttpNotFound();
            }
            return View(metalType);
        }

        // POST: MetalTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MetTypeName")] MetalType metalType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metalType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metalType);
        }

        // GET: MetalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalType metalType = db.MetalTypes.Find(id);
            if (metalType == null)
            {
                return HttpNotFound();
            }
            return View(metalType);
        }

        // POST: MetalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetalType metalType = db.MetalTypes.Find(id);
            db.MetalTypes.Remove(metalType);
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
