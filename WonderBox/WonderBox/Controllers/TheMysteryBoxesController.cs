using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WonderBox.Models;

namespace WonderBox.Controllers
{
    public class TheMysteryBoxesController : Controller
    {
        private MasterBoxDBContext db = new MasterBoxDBContext();

        // GET: TheMysteryBoxes
        public ActionResult Index()
        {
            return View(db.BoxOfMystery.ToList());
        }

        // GET: TheMysteryBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheMysteryBox theMysteryBox = db.BoxOfMystery.Find(id);
            if (theMysteryBox == null)
            {
                return HttpNotFound();
            }
            return View(theMysteryBox);
        }

        // GET: TheMysteryBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TheMysteryBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] TheMysteryBox theMysteryBox)
        {
            if (ModelState.IsValid)
            {
                db.BoxOfMystery.Add(theMysteryBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theMysteryBox);
        }

        // GET: TheMysteryBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheMysteryBox theMysteryBox = db.BoxOfMystery.Find(id);
            if (theMysteryBox == null)
            {
                return HttpNotFound();
            }
            return View(theMysteryBox);
        }

        // POST: TheMysteryBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] TheMysteryBox theMysteryBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theMysteryBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theMysteryBox);
        }

        // GET: TheMysteryBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheMysteryBox theMysteryBox = db.BoxOfMystery.Find(id);
            if (theMysteryBox == null)
            {
                return HttpNotFound();
            }
            return View(theMysteryBox);
        }

        // POST: TheMysteryBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheMysteryBox theMysteryBox = db.BoxOfMystery.Find(id);
            db.BoxOfMystery.Remove(theMysteryBox);
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
