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
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginRequest>>> GetLoginRequest()
        {
            return await _context.LoginRequest.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginRequest>> GetLoginRequest(string id)
        {
            var loginRequest = await _context.LoginRequest.FindAsync(id);

            if (loginRequest == null)
            {
                return NotFound();
            }

            return loginRequest;
        }

        // PUT: api/Login/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginRequest(string id, LoginRequest loginRequest)
        {
            if (id != loginRequest.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(loginRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginRequestExists(id))
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Nombre) || string.IsNullOrWhiteSpace(loginRequest.Pass))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
            }

            // Verificar si es administrador
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Nombre == loginRequest.Nombre && a.Pass == loginRequest.Pass);
            if (admin != null)
            {
                return Ok(new { Rol = "Admin", Nombre = admin.Nombre });
            }

            // Verificar si es usuario normal
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.nombreUsuario == loginRequest.Nombre && u.Pass == loginRequest.Pass);
            if (usuario != null)
            {
                return Ok(new { Rol = "Usuario", Nombre = usuario.nombreUsuario });
            }

            return Unauthorized("Usuario o contraseña incorrectos.");
        }

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginRequest>> PostLoginRequest(LoginRequest loginRequest)
        {
            _context.LoginRequest.Add(loginRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginRequestExists(loginRequest.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginRequest", new { id = loginRequest.Nombre }, loginRequest);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginRequest(string id)
        {
            var loginRequest = await _context.LoginRequest.FindAsync(id);
            if (loginRequest == null)
            {
                return NotFound();
            }

            _context.LoginRequest.Remove(loginRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginRequestExists(string id)
        {
            return _context.LoginRequest.Any(e => e.Nombre == id);
        }
    }
}
