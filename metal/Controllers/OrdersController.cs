using metal.Application.service.Orders.Commands.Quary.GetUserOrder;
using metal.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace metal.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IGetUserOrdersService _getUserOrdersService;
        public OrdersController(IGetUserOrdersService getUserOrdersService)
        {
            _getUserOrdersService = getUserOrdersService;
        }
        public IActionResult Index()
        {
            long userId = ClaimUtility.GetUserId(User).Value;
            return View(_getUserOrdersService.Execute(userId).Data);
        }
        public IActionResult Addctozih(long id,string tozih)
        {
            return View(_getUserOrdersService.AddOrderimg(ordId:id, tozih:tozih,psrc:null).IsSuccess);
        }
        public IActionResult Addcimg( IFormFile psrc)
        {
            long userId = ClaimUtility.GetUserId(User).Value;
            psrc = Request.Form.Files[0];
            return View(_getUserOrdersService.AddOrderimg(ordId: userId, psrc:psrc,tozih:null).IsSuccess);
        }
    }
}
