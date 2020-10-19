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
using API.Context;
using API.Models;

namespace API.Controllers
{
    public class EventDetailsController : ApiController
    {
        private HWAPIContext db = new HWAPIContext();

        // GET: api/EventDetails
        public IQueryable<EventDetail> GeteventDetails()
        {
            return db.eventDetails;
        }

        // GET: api/EventDetails/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult GetEventDetail(int id)
        {
            EventDetail eventDetail = db.eventDetails.Find(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return Ok(eventDetail);
        }

        // PUT: api/EventDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventDetail(int id, EventDetail eventDetail)
        {
            if (id != eventDetail.EventDetailId)
            {
                return BadRequest();
            }

            db.Entry(eventDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDetailExists(id))
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

        // POST: api/EventDetails
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult PostEventDetail(EventDetail eventDetail)
        {
            db.eventDetails.Add(eventDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventDetail.EventDetailId }, eventDetail);
        }

        // DELETE: api/EventDetails/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult DeleteEventDetail(int id)
        {
            EventDetail eventDetail = db.eventDetails.Find(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            db.eventDetails.Remove(eventDetail);
            db.SaveChanges();

            return Ok(eventDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventDetailExists(int id)
        {
            return db.eventDetails.Count(e => e.EventDetailId == id) > 0;
        }
    }
}