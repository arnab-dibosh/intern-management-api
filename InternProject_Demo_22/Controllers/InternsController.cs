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
using InternProject_Demo_22;

namespace InternProject_Demo_22.Controllers
{
    public class InternsController : ApiController
    {
        private TrainingDBEntities1 db = new TrainingDBEntities1();

        // GET: api/Interns
        public IQueryable<Intern> GetInterns()
        {
            return db.Interns;
        }

        // GET: api/Interns/5
        [ResponseType(typeof(Intern))]
        public IHttpActionResult GetIntern(int id)
        {
            Intern intern = db.Interns.Find(id);
            if (intern == null)
            {
                return NotFound();
            }

            return Ok(intern);
        }

        // PUT: api/Interns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntern(int id, Intern intern)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intern.id)
            {
                return BadRequest();
            }

            db.Entry(intern).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternExists(id))
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

        // POST: api/Interns
        [ResponseType(typeof(Intern))]
        public IHttpActionResult PostIntern(Intern intern)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Interns.Add(intern);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = intern.id }, intern);
        }

        // DELETE: api/Interns/5
        [ResponseType(typeof(Intern))]
        public IHttpActionResult DeleteIntern(int id)
        {
            Intern intern = db.Interns.Find(id);
            if (intern == null)
            {
                return NotFound();
            }

            db.Interns.Remove(intern);
            db.SaveChanges();

            return Ok(intern);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InternExists(int id)
        {
            return db.Interns.Count(e => e.id == id) > 0;
        }
    }
}