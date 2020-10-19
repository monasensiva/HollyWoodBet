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
    public class TournamentsController : ApiController
    {
        private HWAPIContext db = new HWAPIContext();

        // GET: api/Tournaments
        public IQueryable<Tournament> Gettournaments()
        {
            return db.tournaments;
        }

        // GET: api/Tournaments/5
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult GetTournament(int id)
        {
            Tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        // PUT: api/Tournaments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTournament(int id, Tournament tournament)
        {
   

            if (id != tournament.TournamentId)
            {
                return BadRequest();
            }

            db.Entry(tournament).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: api/Tournaments
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult PostTournament(Tournament tournament)
        {

            db.tournaments.Add(tournament);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tournament.TournamentId }, tournament);
        }

        // DELETE: api/Tournaments/5
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult DeleteTournament(int id)
        {
            Tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return NotFound();
            }

            db.tournaments.Remove(tournament);
            db.SaveChanges();

            return Ok(tournament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TournamentExists(int id)
        {
            return db.tournaments.Count(e => e.TournamentId == id) > 0;
        }
    }
}