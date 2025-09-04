using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtobusProje.Models;

namespace OtobusProje
{
    public class SefersController : Controller
    {
        private readonly AppDbContext _context;

        public SefersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sefers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sefers.Include(s => s.Otobus).Include(s => s.Personel).Include(s => s.Rota).Include(s => s.Sofor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sefers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sefer = await _context.Sefers
                .Include(s => s.Otobus)
                .Include(s => s.Personel)
                .Include(s => s.Rota)
                .Include(s => s.Sofor)
                .FirstOrDefaultAsync(m => m.SeferId == id);
            if (sefer == null)
            {
                return NotFound();
            }

            return View(sefer);
        }

        // GET: Sefers/Create
        public IActionResult Create()
        {
            ViewData["OtobusId"] = new SelectList(_context.Otobus, "OtobusId", "OtobusId");
            ViewData["PersonelId"] = new SelectList(_context.Personels, "PersonelId", "PersonelId");
            ViewData["RotaId"] = new SelectList(_context.Rota, "RotaId", "RotaId");
            ViewData["SoforId"] = new SelectList(_context.Sofors, "SoforId", "SoforId");
            return View();
        }

        // POST: Sefers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeferId,Kalkis,Varis,Tarih,Saat,Fiyat,OtobusId,SoforId,PersonelId,RotaId")] Sefer sefer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sefer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OtobusId"] = new SelectList(_context.Otobus, "OtobusId", "OtobusId", sefer.OtobusId);
            ViewData["PersonelId"] = new SelectList(_context.Personels, "PersonelId", "PersonelId", sefer.PersonelId);
            ViewData["RotaId"] = new SelectList(_context.Rota, "RotaId", "RotaId", sefer.RotaId);
            ViewData["SoforId"] = new SelectList(_context.Sofors, "SoforId", "SoforId", sefer.SoforId);
            return View(sefer);
        }

        // GET: Sefers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sefer = await _context.Sefers.FindAsync(id);
            if (sefer == null)
            {
                return NotFound();
            }
            ViewData["OtobusId"] = new SelectList(_context.Otobus, "OtobusId", "OtobusId", sefer.OtobusId);
            ViewData["PersonelId"] = new SelectList(_context.Personels, "PersonelId", "PersonelId", sefer.PersonelId);
            ViewData["RotaId"] = new SelectList(_context.Rota, "RotaId", "RotaId", sefer.RotaId);
            ViewData["SoforId"] = new SelectList(_context.Sofors, "SoforId", "SoforId", sefer.SoforId);
            return View(sefer);
        }

        // POST: Sefers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeferId,Kalkis,Varis,Tarih,Saat,Fiyat,OtobusId,SoforId,PersonelId,RotaId")] Sefer sefer)
        {
            if (id != sefer.SeferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sefer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeferExists(sefer.SeferId))
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
            ViewData["OtobusId"] = new SelectList(_context.Otobus, "OtobusId", "OtobusId", sefer.OtobusId);
            ViewData["PersonelId"] = new SelectList(_context.Personels, "PersonelId", "PersonelId", sefer.PersonelId);
            ViewData["RotaId"] = new SelectList(_context.Rota, "RotaId", "RotaId", sefer.RotaId);
            ViewData["SoforId"] = new SelectList(_context.Sofors, "SoforId", "SoforId", sefer.SoforId);
            return View(sefer);
        }

        // GET: Sefers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sefer = await _context.Sefers
                .Include(s => s.Otobus)
                .Include(s => s.Personel)
                .Include(s => s.Rota)
                .Include(s => s.Sofor)
                .FirstOrDefaultAsync(m => m.SeferId == id);
            if (sefer == null)
            {
                return NotFound();
            }

            return View(sefer);
        }

        // POST: Sefers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sefer = await _context.Sefers.FindAsync(id);
            if (sefer != null)
            {
                _context.Sefers.Remove(sefer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeferExists(int id)
        {
            return _context.Sefers.Any(e => e.SeferId == id);
        }
    }
}
