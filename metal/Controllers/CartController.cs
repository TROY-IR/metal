using metal.Application.service.Carts;
using metal.Application.service.NewFolder;
using metal.Models.dorder;
using metal.Utilities;
using metal.wwwroot.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger cookiesManeger;
        private readonly IuploadService _upload;

        public CartController(ICartService cartService, IuploadService upload)
        {
            _cartService = cartService;
            cookiesManeger = new CookiesManeger();
            _upload = upload;
        }

        public IActionResult Index()
        {
            var userId = ClaimUtility.GetUserId(User);

            var resultGetLst = _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);

            return View(resultGetLst.Data);
        }
        public IActionResult mdcart()
        {
            var userId = ClaimUtility.GetUserId(User);

            var resultGetLst = _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);

            return PartialView(viewName:"mdcart",resultGetLst.Data);
        }
        public IActionResult AddToCart([FromForm] long? ProductId, [FromForm]  dorder? dorder)
        {

            dCartItemdto dd = new dCartItemdto()
            {
                imsrc = _upload.UploadFile(dorder.imgsrc).FileNameAddress,
                tozih = dorder.tozih,
                size = dorder.size,
                txchra = dorder.txchra,
                Count = dorder.Count,
            };
            var resultAdd = _cartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext), dd);

            return RedirectToAction("Index");
        }


        public IActionResult Add(long CartItemId)
        {
            _cartService.Add(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(long CartItemId)
        {
            _cartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long ProductId)
        {
            _cartService.RemoveFromCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");

        }


        public IActionResult CartUi()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return PartialView(viewName: "Cart", _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
