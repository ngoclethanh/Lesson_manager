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
    public class LophocsController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;

        public LophocsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }

        // GET: api/Lophocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lophoc>>> GetLophocs()
        {
          if (_context.Lophocs == null)
          {
              return NotFound();
          }
            return await _context.Lophocs.ToListAsync();
        }

        // GET: api/Lophocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lophoc>> GetLophoc(long? id)
        {
          if (_context.Lophocs == null)
          {
              return NotFound();
          }
            var lophoc = await _context.Lophocs.FindAsync(id);

            if (lophoc == null)
            {
                return NotFound();
            }

            return lophoc;
        }

        // PUT: api/Lophocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLophoc(long? id, Lophoc lophoc)
        {
            if (id != lophoc.Malop)
            {
                return BadRequest();
            }

            _context.Entry(lophoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LophocExists(id))
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

        // POST: api/Lophocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lophoc>> PostLophoc(Lophoc lophoc)
        {
          if (_context.Lophocs == null)
          {
              return Problem("Entity set 'DA5_QLdayhocContext.Lophocs'  is null.");
          }
            _context.Lophocs.Add(lophoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LophocExists(lophoc.Malop))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLophoc", new { id = lophoc.Malop }, lophoc);
        }

        // DELETE: api/Lophocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLophoc(long? id)
        {
            if (_context.Lophocs == null)
            {
                return NotFound();
            }
            var lophoc = await _context.Lophocs.FindAsync(id);
            if (lophoc == null)
            {
                return NotFound();
            }

            _context.Lophocs.Remove(lophoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LophocExists(long? id)
        {
            return (_context.Lophocs?.Any(e => e.Malop == id)).GetValueOrDefault();
        }
    }
}
