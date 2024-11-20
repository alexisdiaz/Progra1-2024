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
    public class RegistroController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RegistroController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Registro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registro>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Registro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> GetRegistro(string id)
        {
            var registro = await _context.Usuarios.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        // PUT: api/Registro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro(string id, Registro registro)
        {
            if (id != registro.nombreUsuario)
            {
                return BadRequest();
            }

            _context.Entry(registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(id))
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

        // POST: api/Registro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registro>> PostRegistro(Registro registro)
        {
            _context.Usuarios.Add(registro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistroExists(registro.nombreUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistro", new { id = registro.nombreUsuario }, registro);
        }

        // DELETE: api/Registro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro(string id)
        {
            var registro = await _context.Usuarios.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroExists(string id)
        {
            return _context.Usuarios.Any(e => e.nombreUsuario == id);
        }
    }
}
