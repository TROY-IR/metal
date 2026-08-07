using metal.Application.InterFace.FacadPaerns;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_productFacad.GetProductForSiteService.Execute(page).Data);
        }



        [HttpGet]
        public IActionResult getp(long id)
        {
            return PartialView("_PMContent", _productFacad.GetProductDetailForSiteService.Execute(id).Data);
        }
        //     public IActionResult Detail(long Id)
        //     {
        //        return View(_productFacad.GetProductDetailForSiteService.Execute(Id).Data);
        //    }
    }
}
