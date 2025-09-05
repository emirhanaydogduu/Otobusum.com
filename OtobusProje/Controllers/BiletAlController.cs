using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtobusProje.Models;

public class BiletAlController : Controller
{
    private readonly AppDbContext _context;

    public BiletAlController(AppDbContext context)
    {
        _context = context;
    }

    // Seferleri listele
    public IActionResult Index()
    {
        var seferler = _context.Sefers
            .Include(s => s.Otobus)
            .ToList();
        return View(seferler);
    }

    // Sefer seçince boş/dolu koltukları göster
    public IActionResult Sec(int id)
    {
        var sefer = _context.Sefers
            .Include(s => s.Otobus)
            .FirstOrDefault(s => s.SeferId == id);

        if (sefer == null) return NotFound();

        var kapasite = sefer.Otobus.Kapasite ?? 0;
        var tumKoltuklar = Enumerable.Range(1, kapasite);

        var doluKoltuklar = _context.Bilets
            .Where(b => b.SeferId == id)
            .Select(b => b.KoltukNo)
            .ToList();

        var bosKoltuklar = tumKoltuklar.Except(doluKoltuklar).ToList();

        ViewBag.Sefer = sefer;
        ViewBag.DoluKoltuklar = doluKoltuklar;
        ViewBag.BosKoltuklar = bosKoltuklar;

        // Yolcular dropdown için
        ViewBag.Yolcular = _context.Yolcus
            .Select(y => new { y.YolcuId, AdSoyad = y.Ad + " " + y.Soyad })
            .ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Sec(Bilet bilet)
    {
        if (ModelState.IsValid)
        {
            bilet.SatisTarihi = DateTime.Now;
            _context.Bilets.Add(bilet);
            _context.SaveChanges();

            // işte buraya yönlendirme kodu
            return RedirectToAction("Index", "Odeme", new { biletId = bilet.BiletId });
        }
        return View(bilet);
    }
    public IActionResult RezerveEt(int id)
    {
        var sefer = _context.Sefers
            .Include(s => s.Otobus)
            .FirstOrDefault(s => s.SeferId == id);

        if (sefer == null) return NotFound();

        // Rezervasyon için boş koltuklar vs. hesaplanacak
        var kapasite = sefer.Otobus.Kapasite ?? 0;
        var tumKoltuklar = Enumerable.Range(1, kapasite);

        var doluKoltuklar = _context.Rezervasyons
            .Where(r => r.SeferId == id)
            .Select(r => r.KoltukNo)
            .ToList();

        var bosKoltuklar = tumKoltuklar.Except(doluKoltuklar).ToList();

        ViewBag.Sefer = sefer;
        ViewBag.DoluKoltuklar = doluKoltuklar;
        ViewBag.BosKoltuklar = bosKoltuklar;

        return View();
    }

}
