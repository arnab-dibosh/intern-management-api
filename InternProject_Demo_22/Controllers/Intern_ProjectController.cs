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
    public class Intern_ProjectController : ApiController
    {
        private TrainingDBEntities1 db = new TrainingDBEntities1();

        // GET: api/Intern_Project
        public IQueryable<Intern_Project> GetIntern_Project()
        {
            return db.Intern_Project;
        }

        // GET: api/Intern_Project/5
        [ResponseType(typeof(Intern_Project))]
        public IHttpActionResult GetIntern_Project(int id)
        {
            Intern_Project intern_Project = db.Intern_Project.Find(id);
            if (intern_Project == null)
            {
                return NotFound();
            }

            return Ok(intern_Project);
        }

        // PUT: api/Intern_Project/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntern_Project(int id, Intern_Project intern_Project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intern_Project.id)
            {
                return BadRequest();
            }

            db.Entry(intern_Project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Intern_ProjectExists(id))
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

        // POST: api/Intern_Project
        [ResponseType(typeof(Intern_Project))]
        public IHttpActionResult PostIntern_Project(Intern_Project intern_Project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Intern_Project.Add(intern_Project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = intern_Project.id }, intern_Project);
        }

        // DELETE: api/Intern_Project/5
        [ResponseType(typeof(Intern_Project))]
        public IHttpActionResult DeleteIntern_Project(int id)
        {
            Intern_Project intern_Project = db.Intern_Project.Find(id);
            if (intern_Project == null)
            {
                return NotFound();
            }

            db.Intern_Project.Remove(intern_Project);
            db.SaveChanges();

            return Ok(intern_Project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Intern_ProjectExists(int id)
        {
            return db.Intern_Project.Count(e => e.id == id) > 0;
        }
    }
}