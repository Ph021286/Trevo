using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto1.Models;

namespace Projeto1.Controllers
{
    public class JogadoresController : Controller
    {
        private readonly TrevoContext _context;

        public JogadoresController(TrevoContext context)
        {
            _context = context;
        }

        // GET: Jogadores1
        public async Task<IActionResult> Index()
        {
              return _context.Jogadores != null ? 
                          View(await _context.Jogadores.ToListAsync()) :
                          Problem("Entity set 'TrevoContext.Jogadores'  is null.");
        }

        // GET: Jogadores1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogadores == null)
            {
                return NotFound();
            }

            var jogadores = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (jogadores == null)
            {
                return NotFound();
            }

            return View(jogadores);
        }

        // GET: Jogadores1/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,Posicao")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogadores);
        }

        // GET: Jogadores1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogadores == null)
            {
                return NotFound();
            }

            var jogadores = await _context.Jogadores.FindAsync(id);
            if (jogadores == null)
            {
                return NotFound();
            }
            return View(jogadores);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Posicao")] Jogadores jogadores)
        {
            if (id != jogadores.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadoresExists(jogadores.Matricula))
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
            return View(jogadores);
        }

        // GET: Jogadores1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogadores == null)
            {
                return NotFound();
            }

            var jogadores = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (jogadores == null)
            {
                return NotFound();
            }

            return View(jogadores);
        }

        // POST: Jogadores1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogadores == null)
            {
                return Problem("Entity set 'TrevoContext.Jogadores'  is null.");
            }
            var jogadores = await _context.Jogadores.FindAsync(id);
            if (jogadores != null)
            {
                _context.Jogadores.Remove(jogadores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadoresExists(int id)
        {
          return (_context.Jogadores?.Any(e => e.Matricula == id)).GetValueOrDefault();
        }
    }
}
