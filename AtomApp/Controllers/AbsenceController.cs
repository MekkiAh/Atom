using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtomApp.Models;

namespace AtomApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private readonly EcoleContext _context;

        public AbsenceController(EcoleContext context)
        {
            _context = context;
        }

        // GET: api/Absence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Absence>>> Getabsences()
        {
            return await _context.absences.ToListAsync();
        }

        // GET: api/Absence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Absence>> GetAbsence(int id)
        {
            var absence = await _context.absences.FindAsync(id);

            if (absence == null)
            {
                return NotFound();
            }

            return absence;
        }

        // PUT: api/Absence/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbsence(int id, Absence absence)
        {
            if (id != absence.etudiantId)
            {
                return BadRequest();
            }

            _context.Entry(absence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbsenceExists(id))
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

        // POST: api/Absence
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Absence>> PostAbsence(Absence absence)
        {
            _context.absences.Add(absence);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AbsenceExists(absence.etudiantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAbsence", new { id = absence.etudiantId }, absence);
        }

        // DELETE: api/Absence/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Absence>> DeleteAbsence(int id)
        {
            var absence = await _context.absences.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }

            _context.absences.Remove(absence);
            await _context.SaveChangesAsync();

            return absence;
        }

        private bool AbsenceExists(int id)
        {
            return _context.absences.Any(e => e.etudiantId == id);
        }
    }
}
