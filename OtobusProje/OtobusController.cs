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
    public class OtobusController : Controller
    {
        private readonly AppDbContext _context;

        public OtobusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Otobus
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Otobus.Include(o => o.Firma);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Otobus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otobu = await _context.Otobus
                .Include(o => o.Firma)
                .FirstOrDefaultAsync(m => m.OtobusId == id);
            if (otobu == null)
            {
                return NotFound();
            }

            return View(otobu);
        }

        // GET: Otobus/Create
        public IActionResult Create()
        {
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId");
            return View();
        }

        // POST: Otobus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OtobusId,FirmaId,Plaka,Marka,Kapasite")] Otobu otobu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otobu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId", otobu.FirmaId);
            return View(otobu);
        }

        // GET: Otobus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otobu = await _context.Otobus.FindAsync(id);
            if (otobu == null)
            {
                return NotFound();
            }
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId", otobu.FirmaId);
            return View(otobu);
        }

        // POST: Otobus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OtobusId,FirmaId,Plaka,Marka,Kapasite")] Otobu otobu)
        {
            if (id != otobu.OtobusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otobu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtobuExists(otobu.OtobusId))
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
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId", otobu.FirmaId);
            return View(otobu);
        }

        // GET: Otobus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otobu = await _context.Otobus
                .Include(o => o.Firma)
                .FirstOrDefaultAsync(m => m.OtobusId == id);
            if (otobu == null)
            {
                return NotFound();
            }

            return View(otobu);
        }

        // POST: Otobus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otobu = await _context.Otobus.FindAsync(id);
            if (otobu != null)
            {
                _context.Otobus.Remove(otobu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtobuExists(int id)
        {
            return _context.Otobus.Any(e => e.OtobusId == id);
        }
    }
}
