using metal.Application.InterFace.FacadPaerns;
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

        private readonly IProductFacad _productFacad;

        public HomeController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_productFacad.GetProductForSiteService.Execute(page).Data);
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
