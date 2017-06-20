using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookingApp.Models;
using System.Web.Http.Results;

namespace BookingApp.Controllers
{
    [RoutePrefix("api")]
    public class CountriesController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/Countries

        [HttpGet]
        [Route("Countries", Name = "CApi")]
        public IQueryable<Country> GetCountrys()
        {
            return db.Countrys;
        }

        // GET: api/Countries/5
        // [ResponseType(typeof(Country))]
        [HttpGet]
        [Route("Countries/{id}")]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.Countrys.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [HttpPut]
        [Route("Countries/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.Id)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Countries
        [HttpPost]
        [Route("Countries")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.Countrys.Add(country);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return new ResponseMessageResult(Request.CreateErrorResponse((HttpStatusCode)409, new HttpError("Country already exist!")));
            }

            return CreatedAtRoute("CApi", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete]
        [Route("Countries/{id}")]
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            Country country = db.Countrys.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Countrys.Remove(country);
            db.SaveChanges();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(int id)
        {
            return db.Countrys.Count(e => e.Id == id) > 0;
        }
    }
}