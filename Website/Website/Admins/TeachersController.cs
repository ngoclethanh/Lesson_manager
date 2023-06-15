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
    public class TeachersController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;

        public TeachersController(DA5_QLdayhocContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giaovien>>> GetGiaoviens()
        {
          if (_context.Giaoviens == null)
          {
              return NotFound();
          }
            return await _context.Giaoviens.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giaovien>> GetGiaovien(long id)
        {
          if (_context.Giaoviens == null)
          {
              return NotFound();
          }
            var giaovien = await _context.Giaoviens.FindAsync(id);

            if (giaovien == null)
            {
                return NotFound();
            }

            return giaovien;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiaovien(long id, Giaovien giaovien)
        {
            if (id != giaovien.Magv)
            {
                return BadRequest();
            }

            _context.Entry(giaovien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaovienExists(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giaovien>> PostGiaovien(Giaovien giaovien)
        {
          if (_context.Giaoviens == null)
          {
              return Problem("Entity set 'DA5_QLdayhocContext.Giaoviens'  is null.");
          }
            _context.Giaoviens.Add(giaovien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiaovienExists(giaovien.Magv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiaovien", new { id = giaovien.Magv }, giaovien);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiaovien(long id)
        {
            if (_context.Giaoviens == null)
            {
                return NotFound();
            }
            var giaovien = await _context.Giaoviens.FindAsync(id);
            if (giaovien == null)
            {
                return NotFound();
            }

            _context.Giaoviens.Remove(giaovien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaovienExists(long id)
        {
            return (_context.Giaoviens?.Any(e => e.Magv == id)).GetValueOrDefault();
        }
    }
}
