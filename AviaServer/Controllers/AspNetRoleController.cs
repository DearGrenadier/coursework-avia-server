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
    public class AspNetRoleController : Controller
    {
        private AirportEntities db = new AirportEntities();

        // GET: AspNetRole/AspNetRoleIndex
        public ActionResult AspNetRoleIndex()
        {
            return View(db.AspNetRoles.ToList());
        }

        /*
        // GET: AspNetRole/AspNetRoleDetails/5
        public ActionResult AspNetRoleDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }
        */

        // GET: AspNetRole/AspNetRoleCreate
        public ActionResult AspNetRoleCreate()
        {
            return View();
        }

        // POST: AspNetRole/AspNetRoleCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AspNetRoleCreate([Bind(Include = "Id,Name,AspNetUsers")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                db.AspNetRoles.Add(aspNetRole);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a AspNetRole record");
                return RedirectToAction("AspNetRoleIndex");
            }

            DisplayErrorMessage();
            return View(aspNetRole);
        }

        // GET: AspNetRole/AspNetRoleEdit/5
        public ActionResult AspNetRoleEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // POST: AspNetRoleAspNetRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AspNetRoleEdit([Bind(Include = "Id,Name,AspNetUsers")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetRole).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a AspNetRole record");
                return RedirectToAction("AspNetRoleIndex");
            }
            DisplayErrorMessage();
            return View(aspNetRole);
        }

        // GET: AspNetRole/AspNetRoleDelete/5
        public ActionResult AspNetRoleDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // POST: AspNetRole/AspNetRoleDelete/5
        [HttpPost, ActionName("AspNetRoleDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AspNetRoleDeleteConfirmed(string id)
        {
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            db.AspNetRoles.Remove(aspNetRole);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a AspNetRole record");
            return RedirectToAction("AspNetRoleIndex");
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
