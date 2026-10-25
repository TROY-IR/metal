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
        public IActionResult AddToCart([FromQuery] long? ProductId, [FromForm]  dorder? dorder)
        {



            if(dorder != null && ProductId == null) {

            dCartItemdto dd = new dCartItemdto()
            {
                imsrc = _upload.UploadFile(dorder.imgsrc).FileNameAddress,
                tozih = dorder.tozih,
                size = dorder.size,
                txchra = dorder.txchra,
                Count = dorder.Count,
            };
            var resultAdd = _cartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext), dd);

                var userId = ClaimUtility.GetUserId(User);

                var resultGetLst = _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);

                return PartialView(viewName: "mdcart", resultGetLst.Data);
            }
            else if(ProductId != null)
            {
                dCartItemdto dn = new dCartItemdto();
                var resultAdd = _cartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext), dn);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

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

        public IActionResult dAdd(long dCartItemId)
        {
            _cartService.dAdd(dCartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult dLowOff(long dCartItemId)
        {
            _cartService.dLowOff(dCartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult size(long? dCartItemId, long? CartItemId,long size)
        {
            _cartService.dsize(dCartItemId, CartItemId,size);
            return RedirectToAction("Index");
        }

        public IActionResult txhra(long? dCartItemId, long? CartItemId, long txhra )
        {
            _cartService.dtxhra(dCartItemId, CartItemId,txhra);
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
