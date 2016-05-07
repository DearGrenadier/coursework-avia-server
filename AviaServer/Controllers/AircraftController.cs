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
    public class AircraftController : Controller
    {
        private AirportEntities db = new AirportEntities();

        // GET: Aircraft/AircraftIndex
        public ActionResult AircraftIndex()
        {
            return View(db.Aircraft.ToList());
        }

        /*
        // GET: Aircraft/AircraftDetails/5
        public ActionResult AircraftDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircraft.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }
        */

        // GET: Aircraft/AircraftCreate
        public ActionResult AircraftCreate()
        {
            return View();
        }

        // POST: Aircraft/AircraftCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AircraftCreate([Bind(Include = "Id,GovId,Capacity,Title,Description,Routes")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Aircraft.Add(aircraft);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Aircraft record");
                return RedirectToAction("AircraftIndex");
            }

            DisplayErrorMessage();
            return View(aircraft);
        }

        // GET: Aircraft/AircraftEdit/5
        public ActionResult AircraftEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircraft.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // POST: AircraftAircraft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AircraftEdit([Bind(Include = "Id,GovId,Capacity,Title,Description,Routes")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraft).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Aircraft record");
                return RedirectToAction("AircraftIndex");
            }
            DisplayErrorMessage();
            return View(aircraft);
        }

        // GET: Aircraft/AircraftDelete/5
        public ActionResult AircraftDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircraft.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // POST: Aircraft/AircraftDelete/5
        [HttpPost, ActionName("AircraftDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AircraftDeleteConfirmed(int id)
        {
            Aircraft aircraft = db.Aircraft.Find(id);
            db.Aircraft.Remove(aircraft);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Aircraft record");
            return RedirectToAction("AircraftIndex");
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
