using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestor_Descargas.Models;

namespace Gestor_Descargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ArchivosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Archivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivos>>> GetArchivos()
        {
            return await _context.Archivos.ToListAsync();
        }

        // GET: api/Archivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivos>> GetArchivos(int id)
        {
            var archivos = await _context.Archivos.FindAsync(id);

            if (archivos == null)
            {
                return NotFound();
            }

            return archivos;
        }

        // PUT: api/Archivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivos(int id, Archivos archivos)
        {
            if (id != archivos.idArchivos)
            {
                return BadRequest();
            }

            _context.Entry(archivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivosExists(id))
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

        // POST: api/Archivos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Archivos>> PostArchivos(Archivos archivos)
        {
            _context.Archivos.Add(archivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchivos", new { id = archivos.idArchivos }, archivos);
        }

        // DELETE: api/Archivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivos(int id)
        {
            var archivos = await _context.Archivos.FindAsync(id);
            if (archivos == null)
            {
                return NotFound();
            }

            _context.Archivos.Remove(archivos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchivosExists(int id)
        {
            return _context.Archivos.Any(e => e.idArchivos == id);
        }
    }
}
