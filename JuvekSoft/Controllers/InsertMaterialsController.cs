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
    public class InsertMaterialsController : Controller
    {
        private Model1 db = new Model1();

        // GET: InsertMaterials
        public ActionResult Index()
        {
            return View(db.InsertMaterials.ToList());
        }

        // GET: InsertMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsertMaterial insertMaterial = db.InsertMaterials.Find(id);
            if (insertMaterial == null)
            {
                return HttpNotFound();
            }
            return View(insertMaterial);
        }

        // GET: InsertMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsertMaterials/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,InsMatName")] InsertMaterial insertMaterial)
        {
            if (ModelState.IsValid)
            {
                db.InsertMaterials.Add(insertMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insertMaterial);
        }

        // GET: InsertMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsertMaterial insertMaterial = db.InsertMaterials.Find(id);
            if (insertMaterial == null)
            {
                return HttpNotFound();
            }
            return View(insertMaterial);
        }

        // POST: InsertMaterials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,InsMatName")] InsertMaterial insertMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insertMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insertMaterial);
        }

        // GET: InsertMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsertMaterial insertMaterial = db.InsertMaterials.Find(id);
            if (insertMaterial == null)
            {
                return HttpNotFound();
            }
            return View(insertMaterial);
        }

        // POST: InsertMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsertMaterial insertMaterial = db.InsertMaterials.Find(id);
            db.InsertMaterials.Remove(insertMaterial);
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
