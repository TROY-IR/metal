using metal.Application.service.like.Commands.addlike;
using metal.Application.service.like.Quarys.getlike;
using metal.Models.like;
using metal.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace metal.Controllers
{
    [Authorize]
    public class likeController : Controller
    {
        private readonly IAddLikeService _addLikeService;
        private readonly IGetLikeService _getLikeService;
        private readonly IGetLike _getLike;
        public likeController(
            IAddLikeService addLikeService,
            IGetLikeService getLikeService,
            IGetLike getLike) 
        {
            _addLikeService = addLikeService;
            _getLikeService = getLikeService;
            _getLike = getLike;
        }
        public IActionResult Addlikelist(string name)
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var r = _addLikeService.addlikelist(false, UserId, name).IsSuccess;
            return Ok() ;
        }
        public IActionResult Addlike([FromBody] like f)
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var r = _addLikeService.addlike(false, UserId, long.Parse(f.id),f.name).IsSuccess;
            return Ok();
        }
        public IActionResult remlikelist(string name)
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var r = _addLikeService.addlikelist(false, UserId, name).IsSuccess;
            return Ok();
        }
        public IActionResult remlike([FromBody] long lid, long pid,string name)
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var r = _addLikeService.addlike(true, UserId, pid, name).IsSuccess;
            return View();
        }
        public IActionResult getlikelist()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var r = _getLikeService.getlikelist(UserId).Data;
            return PartialView(viewName: "llike",r);
        }
        public IActionResult getlike()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var r = _getLike.getlike(UserId).Data;
            return PartialView(viewName: "mlike", r);
        }
    }
}
