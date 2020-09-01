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
    public class EtudiantController : ControllerBase
    {
        private readonly EcoleContext _context;

        public EtudiantController(EcoleContext context)
        {
            _context = context;
        }

        // GET: api/Etudiant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> Getetudiants()
        {
            return await _context.etudiants.ToListAsync();
        }

        // GET: api/Etudiant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetEtudiant(int id)
        {
            var etudiant = await _context.etudiants.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return etudiant;
        }

        // PUT: api/Etudiant/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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

        // POST: api/Etudiant
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Etudiant>> PostEtudiant(Etudiant etudiant)
        {
            _context.etudiants.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.Id }, etudiant);
        }

        // DELETE: api/Etudiant/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Etudiant>> DeleteEtudiant(int id)
        {
            var etudiant = await _context.etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();

            return etudiant;
        }



        private bool EtudiantExists(int id)
        {
            return _context.etudiants.Any(e => e.Id == id);
        }
    }
}
