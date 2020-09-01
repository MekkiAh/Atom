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
    public class MatiereController : ControllerBase
    {
        private readonly EcoleContext _context;

        public MatiereController(EcoleContext context)
        {
            _context = context;
        }

        // GET: api/Matiere
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matiere>>> Getmatiere()
        {
            return await _context.matieres.ToListAsync();
        }

        // GET: api/Matiere/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matiere>> GetMatiere(int id)
        {
            var matiere = await _context.matieres.FindAsync(id);

            if (matiere == null)
            {
                return NotFound();
            }

            return matiere;
        }

        // PUT: api/Matiere/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatiere(int id, Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // POST: api/Matiere
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Matiere>> PostMatiere(Matiere matiere)
        {
            _context.matieres.Add(matiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatiere", new { id = matiere.Id }, matiere);
        }

        // DELETE: api/Matiere/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Matiere>> DeleteMatiere(int id)
        {
            var matiere = await _context.matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }

            _context.matieres.Remove(matiere);
            await _context.SaveChangesAsync();

            return matiere;
        }

        private bool MatiereExists(int id)
        {
            return _context.matieres.Any(e => e.Id == id);
        }
    }
}
