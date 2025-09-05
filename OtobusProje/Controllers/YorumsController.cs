using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtobusProje.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OtobusProje.Controllers
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
            var vm = new YorumlarViewModel
            {
                FirmaYorumlari = await _context.FirmaYorums
                    .Include(f => f.Firma)
                    .Include(f => f.Yorum)
                    .ThenInclude(y => y.Yolcu)
                    .ToListAsync(),

                OtobusYorumlari = await _context.OtobusYorums
                    .Include(o => o.Otobus)
                    .Include(o => o.Yorum)
                    .ThenInclude(y => y.Yolcu)
                    .ToListAsync(),

                SeferYorumlari = await _context.SeferYorums
                    .Include(s => s.Sefer)
                    .Include(s => s.Yorum)
                    .ThenInclude(y => y.Yolcu)
                    .ToListAsync(),

                SoforYorumlari = await _context.SoforYorums
                    .Include(s => s.Sofor)
                    .Include(s => s.Yorum)
                    .ThenInclude(y => y.Yolcu)
                    .ToListAsync()
            };

            return View(vm);
        }

        private bool YorumExists(int id)
        {
            return _context.Yorums.Any(e => e.YorumId == id);
        }
    }
}

