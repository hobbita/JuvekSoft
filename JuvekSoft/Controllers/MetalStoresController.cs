using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JuvekSoft.Models;

namespace JuvekSoft.Controllers
{
    public class MetalStoresController : Controller
    {
        private Model1 db = new Model1();

        // GET: MetalStores
        public ActionResult Index()
        {
            var metalStores = db.MetalStores.Include(m => m.MetalName).Include(m => m.MetalType).Include(m => m.Unit).Include(m => m.Unit1).Include(m => m.Unit2);
            return View(metalStores.ToList());
        }

        // GET: MetalStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalStore metalStore = db.MetalStores.Find(id);
            if (metalStore == null)
            {
                return HttpNotFound();
            }
            return View(metalStore);
        }

        // GET: MetalStores/Create
        public ActionResult Create()
        {
            ViewBag.MetName = new SelectList(db.MetalNames, "id", "MetalName1");
            ViewBag.MetType = new SelectList(db.MetalTypes, "id", "MetTypeName");
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName");
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName");
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName");
            return View();
        }

        // POST: MetalStores/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Photo,MetType,MetName,Size1,Size2,Size3,SizeUnits,Quantity,QuantityUnits,Cost,CostUnits,OtherInfo,InUse")] MetalStore metalStore)
        {
            if (ModelState.IsValid)
            {
                db.MetalStores.Add(metalStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MetName = new SelectList(db.MetalNames, "id", "MetalName1", metalStore.MetName);
            ViewBag.MetType = new SelectList(db.MetalTypes, "id", "MetTypeName", metalStore.MetType);
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName", metalStore.CostUnits);
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName", metalStore.QuantityUnits);
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName", metalStore.SizeUnits);
            return View(metalStore);
        }

        // GET: MetalStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalStore metalStore = db.MetalStores.Find(id);
            if (metalStore == null)
            {
                return HttpNotFound();
            }
            ViewBag.MetName = new SelectList(db.MetalNames, "id", "MetalName1", metalStore.MetName);
            ViewBag.MetType = new SelectList(db.MetalTypes, "id", "MetTypeName", metalStore.MetType);
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName", metalStore.CostUnits);
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName", metalStore.QuantityUnits);
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName", metalStore.SizeUnits);
            return View(metalStore);
        }

        // POST: MetalStores/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Photo,MetType,MetName,Size1,Size2,Size3,SizeUnits,Quantity,QuantityUnits,Cost,CostUnits,OtherInfo,InUse")] MetalStore metalStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metalStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MetName = new SelectList(db.MetalNames, "id", "MetalName1", metalStore.MetName);
            ViewBag.MetType = new SelectList(db.MetalTypes, "id", "MetTypeName", metalStore.MetType);
            ViewBag.CostUnits = new SelectList(db.Units, "id", "UnitName", metalStore.CostUnits);
            ViewBag.QuantityUnits = new SelectList(db.Units, "id", "UnitName", metalStore.QuantityUnits);
            ViewBag.SizeUnits = new SelectList(db.Units, "id", "UnitName", metalStore.SizeUnits);
            return View(metalStore);
        }

        // GET: MetalStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalStore metalStore = db.MetalStores.Find(id);
            if (metalStore == null)
            {
                return HttpNotFound();
            }
            return View(metalStore);
        }

        // POST: MetalStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetalStore metalStore = db.MetalStores.Find(id);
            db.MetalStores.Remove(metalStore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddPicture()
        {
           return View();
        }
        [HttpPost, ActionName("AddPicture")]
        public ActionResult AddPicture(MetalStore metalStore, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                metalStore.Photo = imageData;

                db.MetalStores.Add(metalStore);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(metalStore);
        }
        public ActionResult MSPart()
        {
            var metalStores = db.MetalStores.Include(m => m.MetalName).Include(m => m.MetalType).Include(m => m.Unit).Include(m => m.Unit1).Include(m => m.Unit2);
            return View(metalStores.ToList());
        }
        //public ActionResult Partial()
        //{
        //    var metalStores = db.MetalStores.Include(m => m.MetalName).Include(m => m.MetalType).Include(m => m.Unit).Include(m => m.Unit1).Include(m => m.Unit2);
        //   // return View();
        //    //ViewBag.Message = "Это частичное представление.";
        //    return PartialView(metalStores.ToList());
        //}
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
