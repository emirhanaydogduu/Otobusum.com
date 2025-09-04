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
    public class SoforsController : Controller
    {
        private readonly AppDbContext _context;

        public SoforsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sofors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sofors.ToListAsync());
        }

        // GET: Sofors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Sofors
                .FirstOrDefaultAsync(m => m.SoforId == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // GET: Sofors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sofors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoforId,Ad,Soyad,EhliyetNo,Telefon")] Sofor sofor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sofor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sofor);
        }

        // GET: Sofors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Sofors.FindAsync(id);
            if (sofor == null)
            {
                return NotFound();
            }
            return View(sofor);
        }

        // POST: Sofors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoforId,Ad,Soyad,EhliyetNo,Telefon")] Sofor sofor)
        {
            if (id != sofor.SoforId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sofor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoforExists(sofor.SoforId))
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
            return View(sofor);
        }

        // GET: Sofors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Sofors
                .FirstOrDefaultAsync(m => m.SoforId == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // POST: Sofors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sofor = await _context.Sofors.FindAsync(id);
            if (sofor != null)
            {
                _context.Sofors.Remove(sofor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoforExists(int id)
        {
            return _context.Sofors.Any(e => e.SoforId == id);
        }
    }
}
