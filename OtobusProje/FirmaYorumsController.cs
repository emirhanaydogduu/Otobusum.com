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
    public class FirmaYorumsController : Controller
    {
        private readonly AppDbContext _context;

        public FirmaYorumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FirmaYorums
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FirmaYorums.Include(f => f.Firma).Include(f => f.Yorum);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FirmaYorums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firmaYorum = await _context.FirmaYorums
                .Include(f => f.Firma)
                .Include(f => f.Yorum)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (firmaYorum == null)
            {
                return NotFound();
            }

            return View(firmaYorum);
        }

        // GET: FirmaYorums/Create
        public IActionResult Create()
        {
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId");
            ViewData["YorumId"] = new SelectList(_context.Yorums, "YorumId", "YorumId");
            return View();
        }

        // POST: FirmaYorums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YorumId,FirmaId")] FirmaYorum firmaYorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firmaYorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId", firmaYorum.FirmaId);
            ViewData["YorumId"] = new SelectList(_context.Yorums, "YorumId", "YorumId", firmaYorum.YorumId);
            return View(firmaYorum);
        }

        // GET: FirmaYorums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firmaYorum = await _context.FirmaYorums.FindAsync(id);
            if (firmaYorum == null)
            {
                return NotFound();
            }
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId", firmaYorum.FirmaId);
            ViewData["YorumId"] = new SelectList(_context.Yorums, "YorumId", "YorumId", firmaYorum.YorumId);
            return View(firmaYorum);
        }

        // POST: FirmaYorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YorumId,FirmaId")] FirmaYorum firmaYorum)
        {
            if (id != firmaYorum.YorumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firmaYorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmaYorumExists(firmaYorum.YorumId))
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
            ViewData["FirmaId"] = new SelectList(_context.Firmas, "FirmaId", "FirmaId", firmaYorum.FirmaId);
            ViewData["YorumId"] = new SelectList(_context.Yorums, "YorumId", "YorumId", firmaYorum.YorumId);
            return View(firmaYorum);
        }

        // GET: FirmaYorums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firmaYorum = await _context.FirmaYorums
                .Include(f => f.Firma)
                .Include(f => f.Yorum)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (firmaYorum == null)
            {
                return NotFound();
            }

            return View(firmaYorum);
        }

        // POST: FirmaYorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firmaYorum = await _context.FirmaYorums.FindAsync(id);
            if (firmaYorum != null)
            {
                _context.FirmaYorums.Remove(firmaYorum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirmaYorumExists(int id)
        {
            return _context.FirmaYorums.Any(e => e.YorumId == id);
        }
    }
}
