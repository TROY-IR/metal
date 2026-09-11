
using metal.Application.service.users.command;
using metal.Application.service.users.command.EditUser;
using metal.Application.service.users.command.removeuser;
using metal.Application.service.users.command.UserStatusChange;
using metal.Application.service.users.quary.get;
using metal.Application.service.users.quary.getrole;
using metal.Application.Services.Users.Commands.RgegisterUser;
using metal.Common.Bugeto_Store.Common.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace metal.Areas.troy.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("troy")]
    public class UsersController : Controller
    {
        private readonly Igetuserservice _getUsersService;
        private readonly igetroleservice _getRolesService;
        private readonly IRgegisterUserService _rgegisterUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(
            Igetuserservice getUsersService,
            igetroleservice getRolesService,
            IRgegisterUserService rgegisterUserService,
            IRemoveUserService removeUserService,
            IUserSatusChangeService userSatusChangeService,
            IEditUserService editUserService
            )
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _rgegisterUserService = rgegisterUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }


        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(serchkey = serchkey, page = page));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();

        }

        public IActionResult signin()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(string Email, string password, int RoleId, string fullname, string repassword)
        {
            var result = _rgegisterUserService.Execute(new RequestRgegisterUserDto
            {
                Email = Email,
                FullName = fullname,
                Password = password,
                RePasword = repassword,
                roles = new List<RolesInRgegisterUserDto>()
                   {
                        new RolesInRgegisterUserDto
                        {
                             Id= RoleId
                        }
                   }

            }
                );
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }
    }
}
