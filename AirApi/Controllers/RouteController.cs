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
    [System.Web.Http.RoutePrefix("api/route")]
    public class RouteController : ApiController
    {
        private AirportEntities db = new AirportEntities();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getall")]
        [ResponseType(typeof(List<RouteDto>))]
        public IHttpActionResult GetRoute()
        {
            var res = this.db.Routes.ToList();
            var result = res.Select(p => new RouteDto
            {
                Id = p.Id,
                Route = p.Distination.Departure + "-" + p.Distination.Arrive,
                DateStart = p.DateStart,
                Capacity = p.Aircraft.Capacity,
                FreePlaces = p.Aircraft.Capacity - p.Purchases.Count,
                DateEnd = p.DateEnd,
                Train = p.Aircraft.GovId
            });
            return this.Ok(result);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getbydate")]
        [ResponseType(typeof(List<RouteDto>))]
        public IHttpActionResult GetByDate(DateTime? from, DateTime? to)
        {
            var res = this.db.Routes.Where(p => p.DateStart >= from.Value && p.DateEnd <= to.Value).ToList();
            var result = res.Select(p => new RouteDto
            {
                Id = p.Id,
                Route = p.Distination.Departure + "-" + p.Distination.Arrive,
                DateStart = p.DateStart,
                Capacity = p.Aircraft.Capacity,
                FreePlaces = p.Aircraft.Capacity - p.Purchases.Count,
                DateEnd = p.DateEnd,
                Train = p.Aircraft.GovId
            });
            return this.Ok(result);
        }


    }
}
