using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectCofetarie;
using ProiectCofetarie.WebAPI.Data;

namespace ProiectCofetarie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstoricComenzisController : ControllerBase
    {
        private readonly ProiectCofetarieWebAPIContext _context;

        public IstoricComenzisController(ProiectCofetarieWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/IstoricComenzis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IstoricComenzi>>> GetIstoricComenzi()
        {
          if (_context.IstoricComenzis == null)
          {
              return NotFound();
          }
            return await _context.IstoricComenzis.ToListAsync();
        }

        // GET: api/IstoricComenzis/5
        [HttpGet("{email}")]
        public async Task<ActionResult<IstoricComenzi>> GetIstoricComenzi(string email)
        {
          if (_context.IstoricComenzis == null)
          {
              return NotFound();
          }
            var istoricComenzi = _context.IstoricComenzis.Where(c=>c.Emailclient == email).FirstOrDefault();

            if (istoricComenzi == null)
            {
                return NotFound();
            }

            return istoricComenzi;
        }

        // PUT: api/IstoricComenzis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIstoricComenzi(int id, IstoricComenzi istoricComenzi)
        {
            if (id != istoricComenzi.Id)
            {
                return BadRequest();
            }

            _context.Entry(istoricComenzi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IstoricComenziExists(id))
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

        // POST: api/IstoricComenzis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IstoricComenzi>> PostIstoricComenzi(IstoricComenzi istoricComenzi)
        {
          if (_context.IstoricComenzis == null)
          {
              return Problem("Entity set 'ProiectCofetarieWebAPIContext.IstoricComenzi'  is null.");
          }
            _context.IstoricComenzis.Add(istoricComenzi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIstoricComenzi", new { id = istoricComenzi.Id }, istoricComenzi);
        }

        // DELETE: api/IstoricComenzis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIstoricComenzi(int id)
        {
            if (_context.IstoricComenzis == null)
            {
                return NotFound();
            }
            var istoricComenzi = await _context.IstoricComenzis.FindAsync(id);
            if (istoricComenzi == null)
            {
                return NotFound();
            }

            _context.IstoricComenzis.Remove(istoricComenzi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IstoricComenziExists(int id)
        {
            return (_context.IstoricComenzis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
