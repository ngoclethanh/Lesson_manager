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
    public class DocumentsController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;

        public DocumentsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tailieu>>> GetTailieus()
        {
          if (_context.Tailieus == null)
          {
              return NotFound();
          }
            return await _context.Tailieus.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tailieu>> GetTailieu(long id)
        {
          if (_context.Tailieus == null)
          {
              return NotFound();
          }
            var tailieu = await _context.Tailieus.FindAsync(id);

            if (tailieu == null)
            {
                return NotFound();
            }

            return tailieu;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTailieu(long id, Tailieu tailieu)
        {
            if (id != tailieu.Matailieu)
            {
                return BadRequest();
            }

            _context.Entry(tailieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TailieuExists(id))
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

        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tailieu>> PostTailieu(Tailieu tailieu)
        {
          if (_context.Tailieus == null)
          {
              return Problem("Entity set 'DA5_QLdayhocContext.Tailieus'  is null.");
          }
            _context.Tailieus.Add(tailieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTailieu", new { id = tailieu.Matailieu }, tailieu);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTailieu(long id)
        {
            if (_context.Tailieus == null)
            {
                return NotFound();
            }
            var tailieu = await _context.Tailieus.FindAsync(id);
            if (tailieu == null)
            {
                return NotFound();
            }

            _context.Tailieus.Remove(tailieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TailieuExists(long id)
        {
            return (_context.Tailieus?.Any(e => e.Matailieu == id)).GetValueOrDefault();
        }
    }
}
