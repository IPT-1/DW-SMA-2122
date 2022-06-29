using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMA_21296.Data;
using SMA_21296.Models;

namespace SMA_21296.Controllers
{

    [Authorize]
    public class ReceitaMedicamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceitaMedicamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReceitaMedicamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReceitasMedicamento.Include(r => r.Medicamento).Include(r => r.Receita);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReceitaMedicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReceitasMedicamento == null)
            {
                return NotFound();
            }

            var receitaMedicamento = await _context.ReceitasMedicamento
                .Include(r => r.Medicamento)
                .Include(r => r.Receita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receitaMedicamento == null)
            {
                return NotFound();
            }

            return View(receitaMedicamento);
        }

        // GET: ReceitaMedicamentos/Create
        public IActionResult Create()
        {
            ViewData["MedicamentoFK"] = new SelectList(_context.Medicamentos, "Id", "Laboratorio");
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "Id", "Id");
            return View();
        }

        // POST: ReceitaMedicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicamentoFK,ReceitaFK,Dosagem")] ReceitaMedicamento receitaMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receitaMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicamentoFK"] = new SelectList(_context.Medicamentos, "Id", "Laboratorio", receitaMedicamento.MedicamentoFK);
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "Id", "Id", receitaMedicamento.ReceitaFK);
            return View(receitaMedicamento);
        }

        // GET: ReceitaMedicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReceitasMedicamento == null)
            {
                return NotFound();
            }

            var receitaMedicamento = await _context.ReceitasMedicamento.FindAsync(id);
            if (receitaMedicamento == null)
            {
                return NotFound();
            }
            ViewData["MedicamentoFK"] = new SelectList(_context.Medicamentos, "Id", "Laboratorio", receitaMedicamento.MedicamentoFK);
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "Id", "Id", receitaMedicamento.ReceitaFK);
            return View(receitaMedicamento);
        }

        // POST: ReceitaMedicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicamentoFK,ReceitaFK,Dosagem")] ReceitaMedicamento receitaMedicamento)
        {
            if (id != receitaMedicamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receitaMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaMedicamentoExists(receitaMedicamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicamentoFK"] = new SelectList(_context.Medicamentos, "Id", "Laboratorio", receitaMedicamento.MedicamentoFK);
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "Id", "Id", receitaMedicamento.ReceitaFK);
            return View(receitaMedicamento);
        }

        // GET: ReceitaMedicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReceitasMedicamento == null)
            {
                return NotFound();
            }

            var receitaMedicamento = await _context.ReceitasMedicamento
                .Include(r => r.Medicamento)
                .Include(r => r.Receita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receitaMedicamento == null)
            {
                return NotFound();
            }

            return View(receitaMedicamento);
        }

        // POST: ReceitaMedicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReceitasMedicamento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ReceitasMedicamento'  is null.");
            }
            var receitaMedicamento = await _context.ReceitasMedicamento.FindAsync(id);
            if (receitaMedicamento != null)
            {
                _context.ReceitasMedicamento.Remove(receitaMedicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaMedicamentoExists(int id)
        {
          return _context.ReceitasMedicamento.Any(e => e.Id == id);
        }
    }
}
