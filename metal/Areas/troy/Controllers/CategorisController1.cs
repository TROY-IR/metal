using metal.Application.InterFace.FacadPaerns;
using metal.Application.service.Products.Command.AddNewProduct;
using Microsoft.AspNetCore.Mvc;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;

namespace metal.Areas.troy.Controllers
{
    [Area("troy")]
    public class CategoriesController : Controller
    {

        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }


        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(RequestAddNewCategoryDto request)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;

            return Json(_productFacad.AddNewCategoryService.Execute(request));
        }
    }
































































































































































}
