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
    public class AccommodationTypesController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/AccommodationTypes
        [HttpGet]
        [Route("AccommodationTypes", Name ="ATApi")]
        public IQueryable<AccommodationType> m1()
        {
            return db.AccommodationTypes;
        }

        // GET: api/AccommodationTypes/5
        [HttpGet]
        [Route("AccommodationTypes/{id}")]
        public IHttpActionResult m2(int id)
        {
            AccommodationType accommodationType = db.AccommodationTypes.Find(id);
            if (accommodationType == null)
            {
                return NotFound();
            }

            return Ok(accommodationType);
        }

        // PUT: api/AccommodationTypes/5
        [HttpPut]
        [Route("AccommodationType/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult m3(int id, AccommodationType accommodationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accommodationType.Id)
            {
                return BadRequest();
            }

            db.Entry(accommodationType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationTypeExists(id))
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

        // POST: api/AccommodationTypes
        [HttpPost]
        [Route("AccommodationType")]
        [ResponseType(typeof(AccommodationType))]
        public IHttpActionResult m4(AccommodationType accommodationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.AccommodationTypes.Add(accommodationType);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return new ResponseMessageResult(Request.CreateErrorResponse((HttpStatusCode)409, new HttpError("AccommodationType already exist!")));
            }

            return CreatedAtRoute("ATApi", new { id = accommodationType.Id }, accommodationType);
        }

        // DELETE: api/AccommodationTypes/5
        [HttpDelete]
        [Route("AccommodationType/{id}")]
        [ResponseType(typeof(AccommodationType))]
        public IHttpActionResult m5(int id)
        {
            AccommodationType accommodationType = db.AccommodationTypes.Find(id);
            if (accommodationType == null)
            {
                return NotFound();
            }

            db.AccommodationTypes.Remove(accommodationType);
            db.SaveChanges();

            return Ok(accommodationType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccommodationTypeExists(int id)
        {
            return db.AccommodationTypes.Count(e => e.Id == id) > 0;
        }
    }
}