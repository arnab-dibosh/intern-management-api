using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternProjectManagement.Models;

namespace InternProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly InternProjectManagementContext _context;

        public ProjectsController(InternProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Project.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjects(int id)
        {
            var projects = await _context.Project.FindAsync(id);

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjects(int id, Project projects)
        {
            if (id != projects.id)
            {
                return BadRequest();
            }

            _context.Entry(projects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProjects(Project projects)
        {
            _context.Project.Add(projects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjects", new { id = projects.id }, projects);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            var projects = await _context.Project.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            _context.Project.Remove(projects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectsExists(int id)
        {
            return _context.Project.Any(e => e.id == id);
        }
    }
}
