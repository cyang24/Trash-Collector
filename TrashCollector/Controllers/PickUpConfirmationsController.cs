using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickUpConfirmationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickUpConfirmations
        public ActionResult Index()
        {
            return View(db.PickUpConfirmations.ToList());
        }

        // GET: PickUpConfirmations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpConfirmation pickUpConfirmation = db.PickUpConfirmations.Find(id);
            if (pickUpConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(pickUpConfirmation);
        }

        // GET: PickUpConfirmations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PickUpConfirmations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickUpStatus")] PickUpConfirmation pickUpConfirmation)
        {
            if (ModelState.IsValid)
            {
                db.PickUpConfirmations.Add(pickUpConfirmation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pickUpConfirmation);
        }

        // GET: PickUpConfirmations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpConfirmation pickUpConfirmation = db.PickUpConfirmations.Find(id);
            if (pickUpConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(pickUpConfirmation);
        }

        // POST: PickUpConfirmations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickUpStatus")] PickUpConfirmation pickUpConfirmation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickUpConfirmation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pickUpConfirmation);
        }

        // GET: PickUpConfirmations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpConfirmation pickUpConfirmation = db.PickUpConfirmations.Find(id);
            if (pickUpConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(pickUpConfirmation);
        }

        // POST: PickUpConfirmations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PickUpConfirmation pickUpConfirmation = db.PickUpConfirmations.Find(id);
            db.PickUpConfirmations.Remove(pickUpConfirmation);
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
