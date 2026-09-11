using metal.Application.service.Orders.Commands.Quary.GetUserOrder;
using metal.Application.service.Profile.ProfileDetail.Quarys.GetProfileDetail;
using metal.Utilities;
using metal.wwwroot.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace metal.Controllers
{
    [Authorize(Roles = "Admin,Operator,Customer")]
    public class ProfileController : Controller
    {

  //      private readonly CookiesManeger _cookiesManeger;
        private readonly IGetProfileDetailService _getProfileDetailService;

        public ProfileController(IGetProfileDetailService getProfileDetailService)
        {
            //        _cookiesManeger = new CookiesManeger();
            _getProfileDetailService = getProfileDetailService;
        }
        public IActionResult Index()
        {
            long? userid = ClaimUtility.GetUserId(User);
            var pdet = _getProfileDetailService.Execute(userid).Data;
            var pod = _getProfileDetailService.GetCOrders(userid).Data;

            return View((pdet, pod));
        }


    }
}
