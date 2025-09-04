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
    public class FirmasController : Controller
    {
        private readonly AppDbContext _context;

        public FirmasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Firmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Firmas.ToListAsync());
        }

        // GET: Firmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas
                .FirstOrDefaultAsync(m => m.FirmaId == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // GET: Firmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Firmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirmaId,Ad,Telefon,Email")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firma);
        }

        // GET: Firmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return View(firma);
        }

        // POST: Firmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirmaId,Ad,Telefon,Email")] Firma firma)
        {
            if (id != firma.FirmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmaExists(firma.FirmaId))
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
            return View(firma);
        }

        // GET: Firmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas
                .FirstOrDefaultAsync(m => m.FirmaId == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // POST: Firmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firma = await _context.Firmas.FindAsync(id);
            if (firma != null)
            {
                _context.Firmas.Remove(firma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirmaExists(int id)
        {
            return _context.Firmas.Any(e => e.FirmaId == id);
        }
    }
}
