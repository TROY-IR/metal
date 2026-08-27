using metal.Application.service.UI.DaynamicUi.Quary.Getmedia;
using Microsoft.AspNetCore.Mvc;

namespace metal.ViewComponents
{
    public class HomeUI : ViewComponent
    {
        private readonly IGetMedia _getMedia;

        public HomeUI(IGetMedia getMedia)
        {
            _getMedia = getMedia;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "HomeUI", _getMedia.Execute("Home"));
        }
    }
}
