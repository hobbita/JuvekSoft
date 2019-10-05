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
    public class MetalNamesController : Controller
    {
        private Model1 db = new Model1();

        // GET: MetalNames
        public ActionResult Index()
        {
            return View(db.MetalNames.ToList());
        }

        // GET: MetalNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalName metalName = db.MetalNames.Find(id);
            if (metalName == null)
            {
                return HttpNotFound();
            }
            return View(metalName);
        }

        // GET: MetalNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetalNames/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MetalName1")] MetalName metalName)
        {
            if (ModelState.IsValid)
            {
                db.MetalNames.Add(metalName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metalName);
        }

        // GET: MetalNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalName metalName = db.MetalNames.Find(id);
            if (metalName == null)
            {
                return HttpNotFound();
            }
            return View(metalName);
        }

        // POST: MetalNames/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MetalName1")] MetalName metalName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metalName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metalName);
        }

        // GET: MetalNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalName metalName = db.MetalNames.Find(id);
            if (metalName == null)
            {
                return HttpNotFound();
            }
            return View(metalName);
        }

        // POST: MetalNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetalName metalName = db.MetalNames.Find(id);
            db.MetalNames.Remove(metalName);
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
