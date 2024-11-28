﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorDescargasV1.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Microsoft.IdentityModel.Tokens;

namespace GestorDescargasV1.Controllers
{
    namespace GestorDescargasV1.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ExplorarController : ControllerBase
        {
            private readonly MyDbContext _context;

            public ExplorarController(MyDbContext context)
            {
                _context = context;
            }

            // GET: api/Explorar
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Explorar>>> GetProgramas()
            {
                return await _context.Programas.ToListAsync();
            }
            // GET: api/Explorar/5
            [HttpGet("{id:int}")]
            public async Task<ActionResult<Explorar>> GetExplorar(int id)
            {
                var explorar = await _context.Programas.FindAsync(id);

                if (explorar == null)
                {
                    return NotFound();
                }

                return explorar;
            }
            // GET: api/Explorar/buscar
            [HttpGet("buscar/{buscar}")]
            public async Task<ActionResult<IEnumerable<Explorar>>> BuscarProgramas(string buscar)
            {
                var consulta = _context.Programas.AsQueryable();

                if (!string.IsNullOrWhiteSpace(buscar))
                {
                    consulta = consulta.Where(d => d.nombre.Contains(buscar));
                }

                return await consulta.ToListAsync();
            }





            // PUT: api/Explorar/5
            [HttpGet("{id:int}")]
            public async Task<ActionResult<Explorar>> GetProgramaById(int id)
            {
                var programa = await _context.Programas.FindAsync(id);
                if (programa == null)
                {
                    return NotFound();
                }

                return programa;
            }

            // POST: api/Explorar
            [HttpPost]
            public async Task<ActionResult<Explorar>> PostExplorar(Explorar explorar)
            {
                _context.Programas.Add(explorar);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetExplorar", new { id = explorar.idPrograma }, explorar);
            }

            // DELETE: api/Explorar/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteExplorar(int id)
            {
                var explorar = await _context.Programas.FindAsync(id);
                if (explorar == null)
                {
                    return NotFound();
                }

                _context.Programas.Remove(explorar);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ExplorarExists(int id)
            {
                return _context.Programas.Any(e => e.idPrograma == id);
            }
        }
    }

}
