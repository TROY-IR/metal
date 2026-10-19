using metal.Application.service.Orders.Commands.Quary.GetUserOrder;
using metal.Application.service.Profile.ProfileDetail.Quarys.GetProfileDetail;
using metal.Utilities;
using metal.wwwroot.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [AllowAnonymous]
        public IActionResult mprof(long us)
        {
            if(us != 0)
            {
       //     long? userid = ClaimUtility.GetUserId(User);
            var pdet = _getProfileDetailService.Execute(us).Data;
            return PartialView(viewName:"mprof",pdet);
            }
            else
            {
                return PartialView(viewName: "signbt");
            }



        }
        public IActionResult favprof([FromBody] List<string> fav)
        {


            long? userid = ClaimUtility.GetUserId(User);
            var pdet = _getProfileDetailService.GetCfav(userid,fav).IsSuccess;

            return PartialView();
        }
        public IActionResult compprof(string? adr, string? adrid, int? post, IFormFile? psrc)
        {
            long? userid = ClaimUtility.GetUserId(User);
            if (psrc != null && psrc?.Length != 0)
            {
                psrc = Request.Form.Files[0];
            }
            var pdet = _getProfileDetailService.compprof(userid,adrid:adrid,adr,post,psrc).IsSuccess;

            return PartialView( pdet);
        }
        public IActionResult compprofimg(string? adr, string? adrid, int? post, IFormFile psrc)
        {
            long? userid = ClaimUtility.GetUserId(User);
            psrc = Request.Form.Files[0];
            
            var pdet = _getProfileDetailService.compprof(userid, adrid: adrid, adr, post,psrc).IsSuccess;

            return PartialView(pdet);
        }


    }
}
