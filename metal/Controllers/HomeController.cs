using metal.Models;
using metal.persistance.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace metal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly DataBaseContext _context;

        public HomeController(DataBaseContext context)
        {
            _context = context;

        }

        
        public async Task<IActionResult> Db()
        {
            var dt = new
            {
                elemen1 = await _context.element1.ToListAsync(),
                elemen2 = await _context.element2.ToListAsync()
            };
            Console.WriteLine(dt);

            return Json(dt);
        }
    }
}
