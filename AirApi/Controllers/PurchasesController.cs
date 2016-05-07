using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AirApi.Database;
using AirApi.Models;

namespace AirApi.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/purchase")]
    public class PurchaseController : ApiController
    {
        private AirportEntities db = new AirportEntities();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getall")]
        [ResponseType(typeof(List<PurchaseDto>))]
        public IHttpActionResult GetPurchase()
        {
            var firstOrDefault = this.db.AspNetUsers.FirstOrDefault(p => p.UserName.Equals(this.User.Identity.Name));
            if (firstOrDefault != null)
            {
                var res = firstOrDefault.Purchases.ToList();
                var result = res.Select(p => new PurchaseDto
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    User = p.AspNetUser.UserName,
                    DatePurchased = p.DatePurchased,
                    RouteId = p.RouteId,
                    Marshrut = p.Route.Distination.Departure + "-" + p.Route.Distination.Arrive,
                    DateStart = p.Route.DateStart,
                    DateEnd = p.Route.DateEnd
                }).ToList();
                return this.Ok(result);
            }
            return this.Ok("");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("add")]
        [ResponseType(typeof(List<PurchaseDto>))]
        public IHttpActionResult Add(int id)    
        {
            var firstOrDefault = this.db.AspNetUsers.FirstOrDefault(p => p.UserName.Equals(this.User.Identity.Name));
            var route = this.db.Routes.FirstOrDefault(p => p.Id.Equals(id)); 
            if (firstOrDefault != null)
            {
                firstOrDefault.Purchases.Add(new Purchase
                {
                    Route = route,
                    AspNetUser = firstOrDefault,
                    DatePurchased = DateTime.Now
                });
                this.db.SaveChangesAsync();
            }
            return this.Ok("");
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("delete")]
        [ResponseType(typeof(List<PurchaseDto>))]
        public IHttpActionResult DeletePurchase(int id)
        {
            var purchase = this.db.Purchases.FirstOrDefault(p => p.Id.Equals(id));
            if (purchase != null)
            {
                this.db.Purchases.Remove(purchase);
                this.db.SaveChanges();
            }
            return this.Ok("Deleted");
        }

        //// DELETE: api/Purchases/5
        //[ResponseType(typeof(Purchase))]
        //public async Task<IHttpActionResult> DeletePurchase(int id)
        //{
        //    Purchase purchase = await db.Purchases.FindAsync(id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Purchases.Remove(purchase);
        //    await db.SaveChangesAsync();

        //    return Ok(purchase);
        //}

    }
}