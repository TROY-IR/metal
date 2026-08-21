using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.Products.Quary.GetProductForSearch;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IGetProductForSearch _getProductForSearch;

        public ProductsController(IProductFacad productFacad, IGetProductForSearch getProductForSearch)
        {
            _productFacad = productFacad;
            _getProductForSearch = getProductForSearch;
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


        [HttpGet]
        public IActionResult SearchResult(string name,int catid)
        {
            return View(_getProductForSearch.Execute(name,catid));
        }


    }


}
