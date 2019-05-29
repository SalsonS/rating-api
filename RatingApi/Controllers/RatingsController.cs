using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace RatingApi.Controllers
{
    public class RatingsController : ApiController
    {
        private ratingevaluationEntities db = new ratingevaluationEntities();

        public RatingsController() { }

        public RatingsController(ratingevaluationEntities context)
        {
            db = context;
        }

        [Route("api/stats")]
        public async Task<IHttpActionResult> getStatsForDate(DateTime date)
        {
            try { 
                var start = date.Date;
                var end = date.Date.AddDays(1).AddTicks(-1);

                IQueryable<ratingvalue> x = db.ratingvalues
                    .Include(rv => rv.ratings)
                    .Where(rv => rv.ratings.Any(r => r.Date >= start && r.Date < end));

                return Ok(x);
            } catch
            {
                return BadRequest();
            }
        }

        // GET api/ratings
        public IQueryable<rating> Get()
        {
            return db.ratings;
        }

        // GET api/ratisngs/5
        public rating Get(int id)
        {
            return db.ratings.Find(id);
        }

        // POST api/ratings
        public async Task<IHttpActionResult> Post([FromBody]rating value)
        {
            db.ratings.Add(value);
            await db.SaveChangesAsync();

            return Ok(value);
        }

        // PUT api/ratings/5
        public async Task<IHttpActionResult> Put([FromBody]rating value)
        {
            rating ratingToUpdate = db.ratings.Find(value.RatingId);
            ratingToUpdate.RatingValueId = value.RatingValueId;
            await db.SaveChangesAsync();

            return Ok(value);
        }
    }

}
