using metal.Application.service.UI.DaynamicUi.Command.AddMediaUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace metal.Areas.troy.Controllers
{
 //   [Authorize(Roles = "Admin")]
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
        public IActionResult HomeUi(AddMedia request, List<AddMediaText>? Atext, List<AddMediaImage>? Aimages, List<AddMediaProduct>? Aproduct)
        {

            List<AddMediaImage> images = new List<AddMediaImage>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                AddMediaImage im = new AddMediaImage()
                {
                    IName = Aimages[i].IName,
                    Images = Request.Form.Files[i]
                };

                images.Add(im);
            }

            request.MImages = images;
            request.MTexts = Atext;
            request.MProducts = Aproduct;



            return Json(_addMediaUiService.AddUi(request));
        }




        public IActionResult getcat(int catid)
        {

            return PartialView("getcat",_addMediaUiService.CatProducts(catid));
        }
    }
}
