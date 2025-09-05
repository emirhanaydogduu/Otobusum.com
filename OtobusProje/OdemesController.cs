using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtobusProje.Models;
using System.Threading.Tasks;

namespace OtobusProje.Controllers
{
    public class OdemeController : Controller
    {
        private readonly AppDbContext _context;

        public OdemeController(AppDbContext context)
        {
            _context = context;
        }

        // Ödeme ekranı açma
        public async Task<IActionResult> Index(int biletId)
        {
            var bilet = await _context.Bilets
                .Include(b => b.Sefer)
                .ThenInclude(s => s.Otobus)
                .FirstOrDefaultAsync(b => b.BiletId == biletId);

            if (bilet == null) return NotFound();

            ViewBag.Bilet = bilet;
            return View();
        }

        // Ödeme işlemi
        [HttpPost]
        public async Task<IActionResult> Index(int biletId, string odemeTipi)
        {
            var bilet = await _context.Bilets.FindAsync(biletId);
            if (bilet == null) return NotFound();

            var odeme = new Odeme
            {
                BiletId = biletId,
                OdemeTutari = bilet.Sefer.Fiyat,
                OdemeTarihi = DateTime.Now,
                OdemeTipi = odemeTipi
            };

            _context.Odemes.Add(odeme);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success"); // başarılı sayfasına yönlendir
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
