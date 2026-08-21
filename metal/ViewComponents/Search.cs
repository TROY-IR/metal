using metal.Application.service.Common.Quereis.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace metal.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryService _getCategoryService;
        public Search(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getCategoryService.Execute().Data);
        }
    }
}
