using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestamoLisbrosAPI.Models;

namespace PrestamoLisbrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PrestamosController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Prestamos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamo()
        {
            return await _context.Prestamo
                .Include(i=> i.Lector)
                .Include(i=> i.Libro)
                 .ToListAsync();
        }

        // GET: api/Prestamos/5
        [HttpGet("{IdLibro}/{IdLector}/{FechaPrestamo}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int IdLibro, int IdLector, DateTime FechaPrestamo)
        {
            var prestamo = await _context.Prestamo.FindAsync(IdLector,IdLibro,FechaPrestamo);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        // PUT: api/Prestamos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            if (id != prestamo.IdLector)
            {
                return BadRequest();
            }

            _context.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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

        // POST: api/Prestamos
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
            _context.Prestamo.Add(prestamo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrestamoExists(prestamo.IdLector))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrestamo", new { id = prestamo.IdLector }, prestamo);
        }

        // DELETE: api/Prestamos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prestamo>> DeletePrestamo(int id)
        {
            var prestamo = await _context.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            _context.Prestamo.Remove(prestamo);
            await _context.SaveChangesAsync();

            return prestamo;
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamo.Any(e => e.IdLector == id);
        }
    }
}
