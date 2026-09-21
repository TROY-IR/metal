using Dto.Payment;
using metal.Application.service.Carts;
using metal.Application.service.Finance.Command.AddRequestPay;
using metal.Application.service.Finance.httpRequast;
using metal.Application.service.Finance.Quary.GetRequestPay;
using metal.Application.service.Orders.Commands.AddNewOrder;
using metal.Areas.troy.Models.Authen;
using metal.Domain.Entities.users;
using metal.persistance.Migrations;
using metal.Utilities;
using metal.wwwroot.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZarinPal.Class;

namespace metal.Controllers
{
        [Authorize]
        public class PayController : Controller
        {
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetRequestPayService _getRequestPayService;
        private readonly IAddNewOrderService _addNewOrderService;
        private readonly IZarinPalService _zarinPalService;
        private readonly bool _isSandbox = true; // بر اساس کانفیگ

        public PayController(
            IAddRequestPayService addRequestPayService,
            ICartService cartService,
            IGetRequestPayService getRequestPayService,
            IZarinPalService zarinPalService
                            )
        {
            _addRequestPayService = addRequestPayService;
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _getRequestPayService = getRequestPayService;
            _zarinPalService = zarinPalService;

        }
        public async Task<IActionResult> Index([FromBody] peydto pay)
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);
            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _addRequestPayService.Execute(cart.Data.SumAmount, UserId.Value,pay.peytype,pay.stype,pay.amuntf,pay.cuntry);
                // ارسال در گاه پرداخت



                string callbackUrl = $"https://localhost:7016/Pay/Verify?guid={requestPay.Data.guid}";

                var result = await _zarinPalService.RequestPaymentAsync(
                    amount: cart.Data.SumAmount,
                    description: "description",
                    callbackUrl: callbackUrl,
                    mobile: "09120000000",
                    email: "test@example.com"
                );

                if (result?.Data?.Code == 100)
                {
                    // آدرس درگاه برای هدایت کاربر
                    string gatewayUrl = _isSandbox
                        ? $"https://sandbox.zarinpal.com/pg/StartPay/{result.Data.Authority}"
                        : $"https://payment.zarinpal.com/pg/StartPay/{result.Data.Authority}";

                    return Ok(new
                    {
                        issuccess = true,
                        redier = gatewayUrl
                    });
                }
                else
                {
                return BadRequest(new { Message = "خطا در ایجاد تراکنش", Errors = result?.Errors });
                }



            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }

        }

        public async Task<IActionResult> Verify([FromQuery] Guid guid,[FromQuery] string Authority, [FromQuery] string Status)
        {

            var requestPay = _getRequestPayService.Execute(guid);

            if (Status != "OK")
            {
                return BadRequest("پرداخت توسط کاربر لغو شد یا ناموفق بود.");
            }

            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            var verifyResult = await _zarinPalService.VerifyPaymentAsync(cart.Data.SumAmount, Authority);

            if (verifyResult?.Data?.Code == 100)
            {

                _addNewOrderService.Execute(new RequestAddNewOrderSericeDto
                {
                    CartId = cart.Data.CartId,
                    UserId = UserId.Value,
                    RequestPayId = requestPay.Data.Id,
                    authority = Authority,
                    
                });

                //redirect to orders
                return RedirectToAction("Index", "Orders");
            }
            else if (verifyResult?.Data?.Code == 101)
            {
                return Ok("این تراکنش قبلاً تأیید شده است.");
            }

            return View();
        }
    }
}
    
