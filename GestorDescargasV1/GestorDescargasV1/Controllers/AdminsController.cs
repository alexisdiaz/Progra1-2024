using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorDescargasV1.Models;

namespace GestorDescargasV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AdminsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admins>>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }


        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admins>> GetAdmins(string id)
        {
            var admins = await _context.Admins.FindAsync(id);

            if (admins == null)
            {
                return NotFound();
            }

            return admins;
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmins(string id, Admins admins)
        {
            if (id != admins.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(admins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminsExists(id))
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

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admins>> PostAdmins(Admins admins)
        {
            _context.Admins.Add(admins);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminsExists(admins.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdmins", new { id = admins.Nombre }, admins);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmins(string id)
        {
            var admins = await _context.Admins.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admins);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminsExists(string id)
        {
            return _context.Admins.Any(e => e.Nombre == id);
        }
    }
}
