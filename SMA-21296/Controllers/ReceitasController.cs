﻿using System;
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
    public class ReceitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Receitas.Include(r => r.Medico).Include(r => r.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receitas == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            ViewData["MedicoFK"] = new SelectList(_context.Utentes, "Id", "Nome");
            ViewData["PacienteFK"] = new SelectList(_context.Utentes, "Id", "Nome");
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,MedicoFK,PacienteFK")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoFK"] = new SelectList(_context.Utentes, "Id", "Nome", receita.MedicoFK);
            ViewData["PacienteFK"] = new SelectList(_context.Utentes, "Id", "Nome", receita.PacienteFK);
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receitas == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            ViewData["MedicoFK"] = new SelectList(_context.Utentes, "Id", "Nome", receita.MedicoFK);
            ViewData["PacienteFK"] = new SelectList(_context.Utentes, "Id", "Nome", receita.PacienteFK);
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,MedicoFK,PacienteFK")] Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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
            ViewData["MedicoFK"] = new SelectList(_context.Utentes, "Id", "Nome", receita.MedicoFK);
            ViewData["PacienteFK"] = new SelectList(_context.Utentes, "Id", "Nome", receita.PacienteFK);
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receitas == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receitas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Receitas'  is null.");
            }
            var receita = await _context.Receitas.FindAsync(id);
            if (receita != null)
            {
                _context.Receitas.Remove(receita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
          return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
