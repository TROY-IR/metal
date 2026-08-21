using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.Common.Quereis.GetSlider;
using metal.Application.service.users.quary.get;
using metal.Areas.troy.Controllers;
using metal.Domain.Entities.posters;
using metal.Models;
using metal.Models.ViewModels;
using metal.persistance.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace metal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IProductFacad _productFacad;

        public HomeController(IProductFacad productFacad
            ,ILogger<HomeController> logger
            ,IGetSliderService getSliderService)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _productFacad = productFacad;
        }



        public IActionResult Index(int page = 1)
        {
            return View(_productFacad.GetProductForSiteService.Execute(page).Data);
        }

        public IActionResult Slider(int page = 1)
        {

            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
       //         PageImages = _homePageImagesService.Execute().Data,
         //       Camera = _productFacad.GetProductForSiteService.Execute(Ordering.theNewest
        //        , null, 1, 6, 25).Data.Products,
            };
            return Ok(homePage.Sliders);
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
