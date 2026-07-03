using metal.Application.service.users.quary.get;
using metal.Areas.troy.Controllers;
using metal.Domain.Entities.posters;
using metal.Models;
using metal.persistance.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace metal.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataBaseContext _context;

        public HomeController(DataBaseContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var dt = new AppDbContext
            {
                Element1s = await _context.element1.ToListAsync()
            };

         //   var dt = new
         //    {
         //       elemen1 = 
         //        elemen2 = await _context.element2.ToListAsync()
         //    };
            foreach (var dd in dt.Element1s)
            {
                Console.WriteLine(dd);
            }
            //         Console.WriteLine(dt);
            return View(new AppDbContext
            {
                Element1s=await _context.element1.ToListAsync()
            });


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
        
    //    public async Task<IActionResult> Db()
     //   {

      //  }
    }
}
