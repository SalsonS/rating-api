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
    public class SettingsController : ApiController
    {
        private ratingevaluationEntities db = new ratingevaluationEntities();

        public SettingsController() { }

        public SettingsController(ratingevaluationEntities context)
        {
            db = context;
        }


        // GET api/settings
        public IQueryable<ratingsetting> Get()
        {
            return db.ratingsettings;
        }

        // GET api/settings/5
        public ratingsetting Get(int id)
        {
            return db.ratingsettings.Find(id);
        }

        // POST api/settings
        public async Task<IHttpActionResult> Post([FromBody]ratingsetting value)
        {
            db.ratingsettings.Add(value);
            await db.SaveChangesAsync();

            return Ok(value);
        }

        // PUT api/settings/5
        public async Task<IHttpActionResult> Put([FromBody]ratingsetting value)
        {
            ratingsetting settingToUpdate = db.ratingsettings.Find(value.RatingSeetingId);
            settingToUpdate.RatingSeetingId = value.RatingSeetingId;
            await db.SaveChangesAsync();

            return Ok(value);
        }
    }


}
