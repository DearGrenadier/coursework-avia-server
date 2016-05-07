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
    public static class MCVExtentions
    {
        public static List<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> enumerable,
            Func<T, string> text,
            Func<T, string> value,
            string defaultOption)
        {
            var items = enumerable.Select(f => new SelectListItem()
            {
                Text = text(f),
                Value = value(f)
            }).ToList();
            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = "-1"
            });
            return items;
        }
    }
    [Authorize(Roles = "Admin")]
    public class RouteController : Controller
    {
        private AirportEntities db = new AirportEntities();

        // GET: Route/RouteIndex
        public ActionResult RouteIndex()
        {
            var route = db.Routes.Include(r => r.Aircraft).Include(r => r.Distination);
            return View(route.ToList());
        }

        /*
        // GET: Route/RouteDetails/5
        public ActionResult RouteDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }
        */

        // GET: Route/RouteCreate
        public ActionResult RouteCreate()
        {
            ViewBag.DestinationId = db.Distinations.ToSelectList(p => p.Departure + "-" + p.Arrive, p => p.Id.ToString(),
          "-");
            ViewBag.AircraftId = new SelectList(db.Aircraft, "Id", "GovId");
            //ViewBag.DestinationId = new SelectList(db.Distinations, "Id", "Departure");
            return View();
        }

        // POST: Route/RouteCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RouteCreate([Bind(Include = "Id,AircraftId,DestinationId,DateStart,DateEnd,Aircraft,Distination,Purchases")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Route record");
                return RedirectToAction("RouteIndex");
            }

            ViewBag.AircraftId = new SelectList(db.Aircraft, "Id", "GovId", route.AircraftId);
            ViewBag.DestinationId = db.Distinations.ToSelectList(p => p.Departure + "-" + p.Arrive, p => p.Id.ToString(),
           "-");
            DisplayErrorMessage();
            return View(route);
        }

        // GET: Route/RouteEdit/5
        public ActionResult RouteEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.AircraftId = new SelectList(db.Aircraft, "Id", "GovId", route.AircraftId);
            ViewBag.DestinationId = db.Distinations.ToSelectList(p => p.Departure + "-" + p.Arrive, p => p.Id.ToString(),
           "-");
            return View(route);
        }

        // POST: RouteRoute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RouteEdit([Bind(Include = "Id,AircraftId,DestinationId,DateStart,DateEnd,Aircraft,Distination,Purchases")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Route record");
                return RedirectToAction("RouteIndex");
            }
            ViewBag.AircraftId = new SelectList(db.Aircraft, "Id", "GovId", route.AircraftId);
            ViewBag.DestinationId = db.Distinations.ToSelectList(p => p.Departure + "-" + p.Arrive, p => p.Id.ToString(),
           "-");
            DisplayErrorMessage();
            return View(route);
        }

        // GET: Route/RouteDelete/5
        public ActionResult RouteDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Route/RouteDelete/5
        [HttpPost, ActionName("RouteDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RouteDeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);
            db.Routes.Remove(route);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Route record");
            return RedirectToAction("RouteIndex");
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
