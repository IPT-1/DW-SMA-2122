using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMA_21296.Data;
using SMA_21296.Models;

namespace SMA_21296.Controllers.API {
    [Route("api/[controller]")]
    [ApiController]
    public class UtentesAPIController : ControllerBase {

        private readonly ApplicationDbContext _context;

        public UtentesAPIController(ApplicationDbContext context) {
            _context = context;
        }



        // GET: api/<UtentesAPIController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtentesViewModel>>> GetUtentes() {
            return await _context.Utentes
                .Select(a => new UtentesViewModel {
                    Id = a.Id,
                    Nome = a.Nome,
                    Telemovel = a.Telemovel,
                    NumeroUtenteSaude = a.NumeroUtenteSaude,
                    Sexo = a.Sexo,
                    Funcao = a.Funcao
                })
                .ToListAsync();
        }

        // GET api/<UtentesAPIController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utente>> GetUtente(int id) {
            var utente = await _context.Utentes.FindAsync(id);

            if (utente == null) { return NotFound(); }

            return utente;
        }

        // POST api/<UtentesAPIController>
        [HttpPost]
        public async Task<ActionResult<Utente>> PostUtente([FromForm] Utente utente) {

            try {
                _context.Utentes.Add(utente);
                await _context.SaveChangesAsync();
            } catch (Exception) {
                throw;
            }

            return CreatedAtAction("GetUtentes", new { id = utente.Id }, utente);

        }

        // PUT api/<UtentesAPIController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtentes(int id, Utente utente) {

            if (id != utente.Id) { return BadRequest(); }

            _context.Entry(utente).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) { 
                if (!UtenteExists(id)) { return NotFound(); }
                else { throw; }
            }

            return NoContent();
        }

        // DELETE api/<UtentesAPIController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtente(int id) {
            var utente = await _context.Utentes.FindAsync(id);
            if (utente == null) { return NotFound(); }

            _context.Utentes.Remove(utente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtenteExists(int id) { 
            return _context.Utentes.Any(u => u.Id == id);
        }

    }
}
