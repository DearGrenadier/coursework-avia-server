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
    public class AspNetUserController : Controller
    {
        private AirportEntities db = new AirportEntities();

        // GET: AspNetUser/AspNetUserIndex
        public ActionResult AspNetUserIndex()
        {
            return View(db.AspNetUsers.ToList());
        }

        /*
        // GET: AspNetUser/AspNetUserDetails/5
        public ActionResult AspNetUserDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }
        */

        // GET: AspNetUser/AspNetUserCreate
        public ActionResult AspNetUserCreate()
        {
            return View();
        }

        // POST: AspNetUser/AspNetUserCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AspNetUserCreate([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,AspNetUserClaims,AspNetUserLogins,Purchases,AspNetRoles")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspNetUser);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a AspNetUser record");
                return RedirectToAction("AspNetUserIndex");
            }

            DisplayErrorMessage();
            return View(aspNetUser);
        }

        // GET: AspNetUser/AspNetUserEdit/5
        public ActionResult AspNetUserEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUserAspNetUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AspNetUserEdit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,AspNetUserClaims,AspNetUserLogins,Purchases,AspNetRoles")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a AspNetUser record");
                return RedirectToAction("AspNetUserIndex");
            }
            DisplayErrorMessage();
            return View(aspNetUser);
        }

        // GET: AspNetUser/AspNetUserDelete/5
        public ActionResult AspNetUserDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUser/AspNetUserDelete/5
        [HttpPost, ActionName("AspNetUserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AspNetUserDeleteConfirmed(string id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a AspNetUser record");
            return RedirectToAction("AspNetUserIndex");
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
