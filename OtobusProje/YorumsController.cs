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
    public class YorumsController : Controller
    {
        private readonly AppDbContext _context;

        public YorumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Yorums
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Yorums.Include(y => y.Yolcu);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Yorums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorums
                .Include(y => y.Yolcu)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: Yorums/Create
        public IActionResult Create()
        {
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId");
            return View();
        }

        // POST: Yorums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YorumId,YolcuId,Puan,Yorum1,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId", yorum.YolcuId);
            return View(yorum);
        }

        // GET: Yorums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorums.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId", yorum.YolcuId);
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YorumId,YolcuId,Puan,Yorum1,Tarih")] Yorum yorum)
        {
            if (id != yorum.YorumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.YorumId))
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
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId", yorum.YolcuId);
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorums
                .Include(y => y.Yolcu)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yorum = await _context.Yorums.FindAsync(id);
            if (yorum != null)
            {
                _context.Yorums.Remove(yorum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumExists(int id)
        {
            return _context.Yorums.Any(e => e.YorumId == id);
        }
    }
}
