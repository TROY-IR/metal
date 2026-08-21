using metal.Application.service.HomePages;
using metal.Application.service.HomePages.AddHomePageImages;
using Microsoft.AspNetCore.Mvc;

namespace metal.Areas.troy.Controllers
{
    [Area("troy")]
    public class SliderController : Controller
    {
        private readonly IAddNewSliderService _addNewSliderService;

        public SliderController(IAddNewSliderService addNewSliderService)
        {
            _addNewSliderService = addNewSliderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile vfile, IFormFile imfile, string link)
        {
            _addNewSliderService.Execute(imfile,vfile, link);
            return View();
        }
    }

}

