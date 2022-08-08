using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SMA_21296.Data;
using SMA_21296.Models;



namespace SMA_21296.Controllers.API {
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosAPIController : ControllerBase {
        
        private readonly ApplicationDbContext _context;

        public MedicamentosAPIController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: api/<MedicamentosAPIController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicamentosViewModel>>> GetMedicamentos() {
            return await _context.Medicamentos
                .OrderByDescending(a => a.Id)
                .Select(a => new MedicamentosViewModel { 
                    Id = a.Id,
                    Nome = a.Nome,
                    Laboratorio = a.Laboratorio,
                    Observacoes = a.Observacoes,
                    Foto = a.Foto
                })
                .ToListAsync();
        }

        // GET api/<MedicamentosAPIController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicamento>> GetMedicamentos(int id) {
            var medicamentos = await _context.Medicamentos.FindAsync(id);

            if (medicamentos == null) {
                return NotFound();
            }

            return medicamentos;
        }

        // POST api/<MedicamentosAPIController>
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento([FromForm] Medicamento medicamento, IFormFile uploadFotoMedicamento) {
            medicamento.Foto = "default.png";

            try {
                _context.Medicamentos.Add(medicamento);
                await _context.SaveChangesAsync();
            } catch (Exception) {
                throw;
            }

            return CreatedAtAction("GetMedicamentos", new { id = medicamento.Id }, medicamento);
        }

        // PUT api/<MedicamentosAPIController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamentos(int id, Medicamento medicamento) {
            if (id != medicamento.Id) {
                return BadRequest();
            }

            _context.Entry(medicamento).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!MedicamentoExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<MedicamentosAPIController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(int id) {
            var medicamento = await _context.Medicamentos.FindAsync(id);

            if (medicamento == null) { return NotFound(); }

            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicamentoExists(int id) { 
            return _context.Medicamentos.Any(o => o.Id == id);
        }

    }
}
