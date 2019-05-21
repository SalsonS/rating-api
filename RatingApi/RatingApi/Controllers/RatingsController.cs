using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

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
        public IQueryable<ratingvalue> getStatsForDate(DateTime date)
        {

            IQueryable<ratingvalue> x = db.ratingvalues
                .Include(rv => rv.ratings)
                .Where(rv => rv.ratings.Any(r => r.Date == date));
            return x;
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

            return CreatedAtRoute("Created: ", new { id = value.RatingId }, value);
        }

        // PUT api/ratings/5
        public async Task<IHttpActionResult> Put([FromBody]rating value)
        {
            rating ratingToUpdate = db.ratings.Find(value.RatingId);
            ratingToUpdate.RatingValueId = value.RatingValueId;
            await db.SaveChangesAsync();

            return CreatedAtRoute("Created: ", new { id = value.RatingId }, value);
        }
    }

    class TodaysStats
    {

    }

}
