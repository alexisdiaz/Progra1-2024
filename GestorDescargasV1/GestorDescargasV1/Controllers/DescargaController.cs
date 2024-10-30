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
        public class DescargaController : ControllerBase
        {
            private readonly MyDbContext _context;

            public DescargaController(MyDbContext context)
            {
                _context = context;
            }

            // GET: api/Descarga
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Descarga>>> GetDescargas()
            {
                return await _context.Descargas.ToListAsync();
            }

            // GET: api/Descarga/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Descarga>> GetDescarga(int id)
            {
                var descarga = await _context.Descargas.FindAsync(id);

                if (descarga == null)
                {
                    return NotFound();
                }

                return descarga;
            }

            // PUT: api/Descarga/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutDescarga(int id, Descarga descarga)
            {
                if (id != descarga.idDescargas)
                {
                    return BadRequest();
                }

                _context.Entry(descarga).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescargaExists(id))
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

            // POST: api/Descarga
            [HttpPost]
            public async Task<ActionResult<Descarga>> PostDescarga(Descarga descarga)
            {
                _context.Descargas.Add(descarga);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDescarga", new { id = descarga.idDescargas }, descarga);
            }

            // DELETE: api/Descarga/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDescarga(int id)
            {
                var descarga = await _context.Descargas.FindAsync(id);
                if (descarga == null)
                {
                    return NotFound();
                }

                _context.Descargas.Remove(descarga);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool DescargaExists(int id)
            {
                return _context.Descargas.Any(e => e.idDescargas == id);
            }
        }
    }

}
