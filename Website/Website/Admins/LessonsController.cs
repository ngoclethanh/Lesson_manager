using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;

        public LessonsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }

        // GET: api/Lessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Baigiang>>> GetBaigiangs()
        {
          if (_context.Baigiangs == null)
          {
              return NotFound();
          }
            return await _context.Baigiangs.ToListAsync();
        }

        // GET: api/Lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Baigiang>> GetBaigiang(long id)
        {
          if (_context.Baigiangs == null)
          {
              return NotFound();
          }
            var baigiang = await _context.Baigiangs.FindAsync(id);

            if (baigiang == null)
            {
                return NotFound();
            }

            return baigiang;
        }

        // PUT: api/Lessons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaigiang(long id, Baigiang baigiang)
        {
            if (id != baigiang.Mabg)
            {
                return BadRequest();
            }

            _context.Entry(baigiang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaigiangExists(id))
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

        // POST: api/Lessons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Baigiang>> PostBaigiang(Baigiang baigiang)
        {
          if (_context.Baigiangs == null)
          {
              return Problem("Entity set 'DA5_QLdayhocContext.Baigiangs'  is null.");
          }
            _context.Baigiangs.Add(baigiang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaigiang", new { id = baigiang.Mabg }, baigiang);
        }

        // DELETE: api/Lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaigiang(long id)
        {
            if (_context.Baigiangs == null)
            {
                return NotFound();
            }
            var baigiang = await _context.Baigiangs.FindAsync(id);
            if (baigiang == null)
            {
                return NotFound();
            }

            _context.Baigiangs.Remove(baigiang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaigiangExists(long id)
        {
            return (_context.Baigiangs?.Any(e => e.Mabg == id)).GetValueOrDefault();
        }
    }
}
