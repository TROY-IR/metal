using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.Common.Quereis.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    public class CategoryController : Controller
    {
        /// <summary>
        /// ////////
        /// </summary>
        private readonly IGetCategoryService _getCategoryService;
        private readonly IProductFacad _productFacad;
        public CategoryController(
            IGetCategoryService getCategoryService,
            IProductFacad productFacad
            )
        {
            _getCategoryService = getCategoryService;
            _productFacad = productFacad;
        }
        public IActionResult Sercat()
        {
            return PartialView(viewName: "Search", _getCategoryService.Execute().Data);
        }
        public IActionResult mcat()
        {
            return PartialView(_productFacad.GetMenuItemService.Execute().Data);
        }
    }
}
