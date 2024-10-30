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
    namespace GestorDescargasV1.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ErroresDController : ControllerBase
        {
            private readonly MyDbContext _context;

            public ErroresDController(MyDbContext context)
            {
                _context = context;
            }

            // GET: api/ErroresD
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ErroresD>>> GetErrores()
            {
                return await _context.Errores.ToListAsync();
            }

            // GET: api/ErroresD/5
            [HttpGet("{id}")]
            public async Task<ActionResult<ErroresD>> GetErroresD(int id)
            {
                var erroresD = await _context.Errores.FindAsync(id);

                if (erroresD == null)
                {
                    return NotFound();
                }

                return erroresD;
            }

            // PUT: api/ErroresD/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutErroresD(int id, ErroresD erroresD)
            {
                if (id != erroresD.IdErrores)
                {
                    return BadRequest();
                }

                _context.Entry(erroresD).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErroresDExists(id))
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

            // POST: api/ErroresD
            [HttpPost]
            public async Task<ActionResult<ErroresD>> PostErroresD(ErroresD erroresD)
            {
                _context.Errores.Add(erroresD);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetErroresD", new { id = erroresD.IdErrores }, erroresD);
            }

            // DELETE: api/ErroresD/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteErroresD(int id)
            {
                var erroresD = await _context.Errores.FindAsync(id);
                if (erroresD == null)
                {
                    return NotFound();
                }

                _context.Errores.Remove(erroresD);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ErroresDExists(int id)
            {
                return _context.Errores.Any(e => e.IdErrores == id);
            }
        }
    }
}
