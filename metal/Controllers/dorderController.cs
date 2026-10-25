using metal.Application.service.Carts;
using metal.Utilities;
using metal.wwwroot.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    public class dorderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger cookiesManeger;
        public dorderController(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManeger = new CookiesManeger();
        }

        public IActionResult dorder()
        {
            var userId = ClaimUtility.GetUserId(User);

            var resultGetLst = _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);
            return View(resultGetLst.Data);
        }
    }
}
