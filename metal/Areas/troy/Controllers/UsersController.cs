using Microsoft.AspNetCore.Mvc;

namespace metal.Areas.troy.Controllers
{
    public class UsersController : Controller
    {
        [Area("troy")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
