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
    public class StudentsController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;

        public StudentsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sinhvien>>> GetSinhviens()
        {
          if (_context.Sinhviens == null)
          {
              return NotFound();
          }
            return await _context.Sinhviens.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sinhvien>> GetSinhvien(long id)
        {
          if (_context.Sinhviens == null)
          {
              return NotFound();
          }
            var sinhvien = await _context.Sinhviens.FindAsync(id);

            if (sinhvien == null)
            {
                return NotFound();
            }

            return sinhvien;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhvien(long id, Sinhvien sinhvien)
        {
            if (id != sinhvien.Masv)
            {
                return BadRequest();
            }

            _context.Entry(sinhvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhvienExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sinhvien>> PostSinhvien(Sinhvien sinhvien)
        {
          if (_context.Sinhviens == null)
          {
              return Problem("Entity set 'DA5_QLdayhocContext.Sinhviens'  is null.");
          }
            _context.Sinhviens.Add(sinhvien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SinhvienExists(sinhvien.Masv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSinhvien", new { id = sinhvien.Masv }, sinhvien);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhvien(long id)
        {
            if (_context.Sinhviens == null)
            {
                return NotFound();
            }
            var sinhvien = await _context.Sinhviens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            _context.Sinhviens.Remove(sinhvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinhvienExists(long id)
        {
            return (_context.Sinhviens?.Any(e => e.Masv == id)).GetValueOrDefault();
        }
    }
}
