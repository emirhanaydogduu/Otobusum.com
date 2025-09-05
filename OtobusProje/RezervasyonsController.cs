using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtobusProje.Models;

namespace Otobusum.com
{
    public class RezervasyonsController : Controller
    {
        private readonly AppDbContext _context;

        public RezervasyonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rezervasyons
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Rezervasyons
                .Include(r => r.Sefer)
                .Include(r => r.Yolcu);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Rezervasyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var rezervasyon = await _context.Rezervasyons
                .Include(r => r.Sefer)
                .Include(r => r.Yolcu)
                .FirstOrDefaultAsync(m => m.RezervasyonId == id);

            if (rezervasyon == null) return NotFound();

            return View(rezervasyon);
        }

        // GET: Rezervasyons/Create
        public IActionResult Create()
        {
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId");
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId");
            return View();
        }

        // POST: Rezervasyons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervasyonId,YolcuId,SeferId,KoltukNo,RezervasyonTarihi,Durum")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervasyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId", rezervasyon.SeferId);
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId", rezervasyon.YolcuId);
            return View(rezervasyon);
        }

        // GET: Rezervasyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var rezervasyon = await _context.Rezervasyons.FindAsync(id);
            if (rezervasyon == null) return NotFound();

            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId", rezervasyon.SeferId);
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId", rezervasyon.YolcuId);
            return View(rezervasyon);
        }

        // POST: Rezervasyons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervasyonId,YolcuId,SeferId,KoltukNo,RezervasyonTarihi,Durum")] Rezervasyon rezervasyon)
        {
            if (id != rezervasyon.RezervasyonId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervasyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervasyonExists(rezervasyon.RezervasyonId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId", rezervasyon.SeferId);
            ViewData["YolcuId"] = new SelectList(_context.Yolcus, "YolcuId", "YolcuId", rezervasyon.YolcuId);
            return View(rezervasyon);
        }

        // GET: Rezervasyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var rezervasyon = await _context.Rezervasyons
                .Include(r => r.Sefer)
                .Include(r => r.Yolcu)
                .FirstOrDefaultAsync(m => m.RezervasyonId == id);

            if (rezervasyon == null) return NotFound();

            return View(rezervasyon);
        }

        // POST: Rezervasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyon = await _context.Rezervasyons.FindAsync(id);
            if (rezervasyon != null)
            {
                _context.Rezervasyons.Remove(rezervasyon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervasyonExists(int id)
        {
            return _context.Rezervasyons.Any(e => e.RezervasyonId == id);
        }

        // =====================
        //  GET: Rezervasyons/RezerveEt
        // =====================
        public IActionResult RezerveEt(int seferId)
        {
            var sefer = _context.Sefers
                .Include(s => s.Otobus)
                .FirstOrDefault(s => s.SeferId == seferId);

            if (sefer == null) return NotFound();

            var kapasite = sefer.Otobus.Kapasite ?? 0;
            var tumKoltuklar = Enumerable.Range(1, kapasite);

            var doluKoltuklar = _context.Rezervasyons
                .Where(r => r.SeferId == seferId)
                .Select(r => r.KoltukNo)
                .ToList();

            var bosKoltuklar = tumKoltuklar.Except(doluKoltuklar).ToList();

            var vm = new RezerveEtViewModel
            {
                Sefer = sefer,
                BosKoltuklar = bosKoltuklar,
                DoluKoltuklar = doluKoltuklar,
                Yolcular = _context.Yolcus.ToList(),
                Rezervasyon = new Rezervasyon { SeferId = seferId, RezervasyonTarihi = DateTime.Now, Durum = "Aktif" }
            };

            return View(vm);
        }

        // =====================
        //  POST: Rezervasyons/RezerveEt
        // =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RezerveEt(RezerveEtViewModel vm, int KoltukNo, int YolcuId)
        {
            if (ModelState.IsValid)
            {
                var rezervasyon = new Rezervasyon
                {
                    SeferId = vm.Rezervasyon.SeferId,
                    YolcuId = YolcuId,
                    KoltukNo = KoltukNo,
                    RezervasyonTarihi = DateTime.Now,
                    Durum = "Aktif"
                };

                _context.Rezervasyons.Add(rezervasyon);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}
