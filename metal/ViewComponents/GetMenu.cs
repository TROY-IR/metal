using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.Common.Quereis.GetMenuItem;
using metal.Application.service.Products.Facadpatern;
using Microsoft.AspNetCore.Mvc;

namespace metal.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IProductFacad _productFacad;
        public GetMenu(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }


        public IViewComponentResult Invoke()
        {
            var menuItem = _productFacad.GetMenuItemService.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }

    }
}
