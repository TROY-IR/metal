
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using metal.Application.service.users.quary.get;
using metal.Application.service.users.quary.getrole;
using metal.Application.Services.Users.Commands.RgegisterUser;
using metal.Application.service.users.command;
using metal.Common.Bugeto_Store.Common.Roles;

namespace metal.Areas.troy.Controllers
{
    [Area("troy")]
    public class UsersController : Controller
    {
        private readonly Igetuserservice _getUsersService;
        private readonly igetroleservice _getRolesService;
        private readonly IRgegisterUserService _rgegisterUserService;
        public UsersController(Igetuserservice getUsersService, igetroleservice getRolesService, IRgegisterUserService rgegisterUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _rgegisterUserService = rgegisterUserService;
        }


        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(serchkey = serchkey, page = page));
        }

        [HttpGet]
        public IActionResult Create()
        {
        
            return View();
    
        }

        [HttpPost]
        public IActionResult Create(string Email,string password,int RoleId,string fullname,string repassword)
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
    }
    }
