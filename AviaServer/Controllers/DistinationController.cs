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
    public class DistinationController : Controller
    {
        private AirportEntities db = new AirportEntities();

        // GET: Distination/DistinationIndex
        public ActionResult DistinationIndex()
        {
            return View(db.Distinations.ToList());
        }

        /*
        // GET: Distination/DistinationDetails/5
        public ActionResult DistinationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distination distination = db.Distinations.Find(id);
            if (distination == null)
            {
                return HttpNotFound();
            }
            return View(distination);
        }
        */

        // GET: Distination/DistinationCreate
        public ActionResult DistinationCreate()
        {
            return View();
        }

        // POST: Distination/DistinationCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DistinationCreate([Bind(Include = "Id,Price,Departure,Arrive,Distance,Routes")] Distination distination)
        {
            if (ModelState.IsValid)
            {
                db.Distinations.Add(distination);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Distination record");
                return RedirectToAction("DistinationIndex");
            }

            DisplayErrorMessage();
            return View(distination);
        }

        // GET: Distination/DistinationEdit/5
        public ActionResult DistinationEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distination distination = db.Distinations.Find(id);
            if (distination == null)
            {
                return HttpNotFound();
            }
            return View(distination);
        }

        // POST: DistinationDistination/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DistinationEdit([Bind(Include = "Id,Price,Departure,Arrive,Distance,Routes")] Distination distination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distination).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Distination record");
                return RedirectToAction("DistinationIndex");
            }
            DisplayErrorMessage();
            return View(distination);
        }

        // GET: Distination/DistinationDelete/5
        public ActionResult DistinationDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distination distination = db.Distinations.Find(id);
            if (distination == null)
            {
                return HttpNotFound();
            }
            return View(distination);
        }

        // POST: Distination/DistinationDelete/5
        [HttpPost, ActionName("DistinationDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DistinationDeleteConfirmed(int id)
        {
            Distination distination = db.Distinations.Find(id);
            db.Distinations.Remove(distination);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Distination record");
            return RedirectToAction("DistinationIndex");
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
