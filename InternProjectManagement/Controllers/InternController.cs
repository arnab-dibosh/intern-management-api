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
    public class InternsController : ControllerBase
    {
        private readonly InternProjectManagementContext _context;

        public InternsController(InternProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Interns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intern>>> GetInterns()
        {
            return await _context.Intern.ToListAsync();
        }

        // GET: api/Interns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intern>> GetInterns(int id)
        {
            var interns = await _context.Intern.FindAsync(id);

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

        // POST: api/Interns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intern>> PostInterns(Intern interns)
        {
            _context.Intern.Add(interns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterns", new { id = interns.id }, interns);
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
