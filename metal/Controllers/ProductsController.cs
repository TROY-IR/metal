using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.AiSearch.n8n;
using metal.Application.service.Products.Quary.GetProductForSearch;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IGetProductForSearch _getProductForSearch;
        private readonly IRequestGetResultSearchService _requestGetResultSearchService;

        public ProductsController(
            IProductFacad productFacad,
            IGetProductForSearch getProductForSearch,
            IRequestGetResultSearchService requestGetResultSearchService)
        {
            _productFacad = productFacad;
            _getProductForSearch = getProductForSearch;
            _requestGetResultSearchService = requestGetResultSearchService;
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
        
        public async Task<IActionResult> SearchAi(long? catid,string? Stext, IFormFile img,CancellationToken cancellationToken)
        {
            var res = _requestGetResultSearchService.n8nrequest(catid,Stext, img, cancellationToken);

        //    Console.WriteLine(res.Result.Data);
            return View(viewName: "SearchResult", res.Result.Data);
        }

    }


}
