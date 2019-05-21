using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RatingApi.Controllers
{
    public class RatingValuesController : ApiController
    {
        private ratingevaluationEntities db = new ratingevaluationEntities();

        public RatingValuesController() { }

        public RatingValuesController(ratingevaluationEntities context)
        {
            db = context;
        }

        // GET api/ratingvalues
        public IQueryable<ratingvalue> Get()
        {
            return db.ratingvalues;
        }

    }
}
