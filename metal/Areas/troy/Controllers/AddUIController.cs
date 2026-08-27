using metal.Application.service.UI.DaynamicUi.Command.AddMediaUi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace metal.Areas.troy.Controllers
{
    [Area("troy")]
    public class AddUIController : Controller
    {
        private readonly IAddMediaUiService _addMediaUiService;
        public AddUIController(IAddMediaUiService addMediaUiService)
        {
            _addMediaUiService = addMediaUiService;
        }
        public IActionResult HomeUi()
        {
            ViewBag.Categories = new SelectList(_addMediaUiService.Execute(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult HomeUi()
        {
            ViewBag.Categories = new SelectList(_addMediaUiService.Execute(), "Id", "Name");
            return View();
        }
    }
}
