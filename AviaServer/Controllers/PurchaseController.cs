using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AviaServer.Database;

namespace AviaServer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PurchaseController : Controller
    {
        private AirportEntities db = new AirportEntities();

        // GET: Purchase/PurchaseIndex
        public ActionResult PurchaseIndex()
        {
            var purchase = db.Purchases.Include(p => p.AspNetUser).Include(p => p.Route);
            return View(purchase.ToList());
        }

        /*
        // GET: Purchase/PurchaseDetails/5
        public ActionResult PurchaseDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        */

        // GET: Purchase/PurchaseCreate
        public ActionResult PurchaseCreate()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Id");
            return View();
        }

        // POST: Purchase/PurchaseCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseCreate([Bind(Include = "Id,UserId,RouteId,DatePurchased,AspNetUser,Route")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Purchase record");
                return RedirectToAction("PurchaseIndex");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", purchase.UserId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Id", purchase.RouteId);
            DisplayErrorMessage();
            return View(purchase);
        }

        // GET: Purchase/PurchaseEdit/5
        public ActionResult PurchaseEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", purchase.UserId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Id", purchase.RouteId);
            return View(purchase);
        }

        // POST: PurchasePurchase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseEdit([Bind(Include = "Id,UserId,RouteId,DatePurchased,AspNetUser,Route")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Purchase record");
                return RedirectToAction("PurchaseIndex");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", purchase.UserId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Id", purchase.RouteId);
            DisplayErrorMessage();
            return View(purchase);
        }

        // GET: Purchase/PurchaseDelete/5
        public ActionResult PurchaseDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchase/PurchaseDelete/5
        [HttpPost, ActionName("PurchaseDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseDeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Purchase record");
            return RedirectToAction("PurchaseIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
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
