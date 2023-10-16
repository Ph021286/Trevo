using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto1.Data;
using Projeto1.Models;

namespace Projeto1.Controllers
{
    public class FemininoController : Controller
    {
        private readonly Context _context;

        public FemininoController(Context context)
        {
            _context = context;
        }
       
        // GET: Feminino
        public async Task<IActionResult> IndexFeminino()
        {
              return _context.Feminino != null ? 
                          View(await _context.Feminino.ToListAsync()) :
                          Problem("Entity set 'FemininoProjeto1Context.ElencoFeminino'  is null.");
        }

        // GET: Feminino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feminino == null)
            {
                return NotFound();
            }

            var elencoFeminino = await _context.Feminino
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (elencoFeminino == null)
            {
                return NotFound();
            }

            return View(elencoFeminino);
        }

        // GET: Feminino/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,Posicao")] ElencoFeminino elencoFeminino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elencoFeminino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexFeminino));
            }
            return View(elencoFeminino);
        }

        // GET: Feminino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feminino == null)
            {
                return NotFound();
            }

            var elencoFeminino = await _context.Feminino.FindAsync(id);
            if (elencoFeminino == null)
            {
                return NotFound();
            }
            return View(elencoFeminino);
        }

        // POST: Feminino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Posicao")] ElencoFeminino elencoFeminino)
        {
            if (id != elencoFeminino.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elencoFeminino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElencoFemininoExists(elencoFeminino.Matricula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexFeminino));
            }
            return View(elencoFeminino);
        }

        // GET: Feminino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feminino == null)
            {
                return NotFound();
            }

            var elencoFeminino = await _context.Feminino
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (elencoFeminino == null)
            {
                return NotFound();
            }

            return View(elencoFeminino);
        }

        // POST: Feminino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feminino == null)
            {
                return Problem("Entity set 'FemininoProjeto1Context.ElencoFeminino'  is null.");
            }
            var elencoFeminino = await _context.Feminino.FindAsync(id);
            if (elencoFeminino != null)
            {
                _context.Feminino.Remove(elencoFeminino);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexFeminino));
        }

        private bool ElencoFemininoExists(int id)
        {
          return (_context.Feminino?.Any(e => e.Matricula == id)).GetValueOrDefault();
        }
        
    }
}
