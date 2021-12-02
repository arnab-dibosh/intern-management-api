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
    public class Intern_ProjectController : ControllerBase
    {
        private readonly InternProjectManagementContext _context;

        public Intern_ProjectController(InternProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Intern_Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intern_Project>>> GetIntern_Project()
        {
            return await _context.Intern_Project.ToListAsync();
        }

        // GET: api/Intern_Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intern_Project>> GetIntern_Project(int id)
        {
            var interns = await _context.Intern_Project.FindAsync(id);

            if (interns == null)
            {
                return NotFound();
            }

            return interns;
        }

        // PUT: api/Interns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterns(int id, Intern interns)
        {
            if (id != interns.id)
            {
                return BadRequest();
            }

            _context.Entry(interns).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternsExists(id))
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

        // POST: api/Intern_Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        
        [HttpPost]
        public async Task<ActionResult<Intern>> PostIntern_Project(Intern_Project interns)
        {
            _context.Intern_Project.Add(interns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntern_Project", new { id = interns.ID }, interns);
        }



       

        // DELETE: api/Interns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterns(int id)
        {
            var interns = await _context.Intern.FindAsync(id);
            if (interns == null)
            {
                return NotFound();
            }

            _context.Intern.Remove(interns);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternsExists(int id)
        {
            return _context.Intern.Any(e => e.id == id);
        }
    }
}
