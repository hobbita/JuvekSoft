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
    public class InsertStores1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: InsertStores1
        public ActionResult Index()
        {
            var insertStores = db.InsertStores.Include(i => i.FacetingType).Include(i => i.InsertMaterial).Include(i => i.Unit).Include(i => i.Unit1).Include(i => i.Unit2);
            return View(insertStores.ToList());
        }

        // GET: InsertStores1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsertStore insertStore = db.InsertStores.Find(id);
            if (insertStore == null)
            {
                return HttpNotFound();
            }
            return View(insertStore);
        }

        // GET: InsertStores1/Create
        public ActionResult Create()
        {
            ViewBag.FacType = new SelectList(db.FacetingTypes, "id", "FacName");
            ViewBag.InsMat = new SelectList(db.InsertMaterials, "id", "InsMatName");
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName");
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName");
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName");
            return View();
        }

        // POST: InsertStores1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,InsMat,FacType,Size1,Size2,Size3,SizeUnits,Quantity,QuantityUnits,Cost,CostUnits,OtherInfo,InUse")] InsertStore insertStore, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                
                insertStore.Photo = new byte[image1.ContentLength];
                image1.InputStream.Read(insertStore.Photo, 0, image1.ContentLength);

                db.InsertStores.Add(insertStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacType = new SelectList(db.FacetingTypes, "id", "FacName", insertStore.FacType);
            ViewBag.InsMat = new SelectList(db.InsertMaterials, "id", "InsMatName", insertStore.InsMat);
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName", insertStore.QuantityUnits);
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName", insertStore.SizeUnits);
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName", insertStore.CostUnits);
            return View(insertStore);
        }

        // GET: InsertStores1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsertStore insertStore = db.InsertStores.Find(id);
            if (insertStore == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacType = new SelectList(db.FacetingTypes, "id", "FacName", insertStore.FacType);
            ViewBag.InsMat = new SelectList(db.InsertMaterials, "id", "InsMatName", insertStore.InsMat);
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName", insertStore.QuantityUnits);
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName", insertStore.SizeUnits);
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName", insertStore.CostUnits);
            return View(insertStore);
        }

        // POST: InsertStores1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Photo,InsMat,FacType,Size1,Size2,Size3,SizeUnits,Quantity,QuantityUnits,Cost,CostUnits,OtherInfo,InUse")] InsertStore insertStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insertStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacType = new SelectList(db.FacetingTypes, "id", "FacName", insertStore.FacType);
            ViewBag.InsMat = new SelectList(db.InsertMaterials, "id", "InsMatName", insertStore.InsMat);
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName", insertStore.QuantityUnits);
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName", insertStore.SizeUnits);
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName", insertStore.CostUnits);
            return View(insertStore);
        }

        // GET: InsertStores1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsertStore insertStore = db.InsertStores.Find(id);
            if (insertStore == null)
            {
                return HttpNotFound();
            }
            return View(insertStore);
        }

        // POST: InsertStores1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsertStore insertStore = db.InsertStores.Find(id);
            db.InsertStores.Remove(insertStore);
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
