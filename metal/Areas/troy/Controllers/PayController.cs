using Dto.Payment;
using metal.Application.service.Carts;
using metal.Application.service.Finance.Command.AddRequestPay;
using metal.Application.service.Finance.Quary.GetRequestPay;
using metal.Application.service.Finance.Quary.GetRequsetPeyForAdmin;
using metal.Application.service.Orders.Commands.AddNewOrder;
using metal.Utilities;
using metal.wwwroot.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZarinPal.Class;

namespace metal.Areas.troy.Controllers
{
    [Area("troy")]
    public class RequestPayController : Controller
    {
        private readonly IGetRequestPayForAdminService _getRequestPayForAdminService;
        public RequestPayController(IGetRequestPayForAdminService getRequestPayForAdminService)
        {
            _getRequestPayForAdminService = getRequestPayForAdminService;
        }
        public IActionResult Index()
        {
            return View(_getRequestPayForAdminService.Execute().Data);
        }
    }
}
