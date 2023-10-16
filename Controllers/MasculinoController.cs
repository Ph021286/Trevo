using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto1.Data;
using Projeto1.Models;

namespace Projeto1.Controllers
{
    public class MasculinoController : Controller
    {
        private readonly Context _context;

        public MasculinoController(Context context)
        {
            _context = context;
        }

        // GET: Masculino
        public async Task<IActionResult> Index()
        {
              return _context.Jogadores != null ? 
                          View(await _context.Jogadores.ToListAsync()) :
                          Problem("Entity set 'Context.Jogadores'  is null.");
        }

        // GET: Masculino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogadores == null)
            {
                return NotFound();
            }

            var elencoMasculino = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (elencoMasculino == null)
            {
                return NotFound();
            }

            return View(elencoMasculino);
        }

        // GET: Masculino/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,Posicao")] ElencoMasculino elencoMasculino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elencoMasculino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elencoMasculino);
        }

        // GET: Masculino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogadores == null)
            {
                return NotFound();
            }

            var elencoMasculino = await _context.Jogadores.FindAsync(id);
            if (elencoMasculino == null)
            {
                return NotFound();
            }
            return View(elencoMasculino);
        }

        // POST: Masculino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Posicao")] ElencoMasculino elencoMasculino)
        {
            if (id != elencoMasculino.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elencoMasculino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElencoMasculinoExists(elencoMasculino.Matricula))
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
            return View(elencoMasculino);
        }

        // GET: Masculino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogadores == null)
            {
                return NotFound();
            }

            var elencoMasculino = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (elencoMasculino == null)
            {
                return NotFound();
            }

            return View(elencoMasculino);
        }

        // POST: Masculino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogadores == null)
            {
                return Problem("Entity set 'Context.Jogadores'  is null.");
            }
            var elencoMasculino = await _context.Jogadores.FindAsync(id);
            if (elencoMasculino != null)
            {
                _context.Jogadores.Remove(elencoMasculino);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElencoMasculinoExists(int id)
        {
          return (_context.Jogadores?.Any(e => e.Matricula == id)).GetValueOrDefault();
        }
    }
}
