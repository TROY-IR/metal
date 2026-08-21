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
        public CategoryController(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }
        public IActionResult Sercat()
        {
            return PartialView(viewName: "Search", _getCategoryService.Execute().Data);
        }
    }
}
