using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtobusProje.Models; // AppDbContext tanımlı namespace

namespace OtobusProje.Controllers
{
    public class FirmaYorumsController : Controller
    {
        private readonly AppDbContext _context; 

        public FirmaYorumsController(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FirmaYorums
                .Include(f => f.Firma)
                .Include(f => f.Yorum)
                .ThenInclude(y => y.Yolcu);

            return View(await appDbContext.ToListAsync());
        }
    }
}
