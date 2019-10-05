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
    public class ProductsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Products
        public ActionResult Index()
        {
           // var Product = db.Products.Include(m => m.InsertStores).Include(m => m.MetalStores).Include(m => m.Operations);
            return View(db.Products.ToList());
        }
        public ActionResult Partial(MetalStore metalStore)
        {
            var metalStores = db.MetalStores.Include(m => m.MetalName).Include(m => m.MetalType).Include(m => m.Unit).Include(m => m.Unit1).Include(m => m.Unit2);
            // return View();
            //ViewBag.Message = "Это частичное представление.";
            return PartialView(metalStores.ToList());
        }




        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Product product = db.Products.Where(e => e.id == id).Include(e => e.InsertStores).FirstOrDefault();
            
                SelectList insertstores = new SelectList(db.InsertStores, "id", "InsMat", "FacetingType");
                ViewBag.InsertStores = insertstores;
                //return View();
            
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
           // ViewBag.InsertStore = new SelectList(db.InsertStores, "id", "InsMat");
            
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,Name,Photo,Cost,OtherInfo,InsertStore")] Product product)
        public ActionResult Create([Bind(Include = "id,Name,Photo,Cost,OtherInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.InsertStore = new SelectList(db.InsertStores, "id", "InsMat", Product.);
            //ViewBag.FacType = new SelectList(db.FacetingTypes, "id", "FacName", insertStore.FacType);
            return View(product);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Photo,Cost,OtherInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
