
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using metal.Application.service.users.quary.get;
using metal.Application.service.users.quary.getrole;
using metal.Application.Services.Users.Commands.RgegisterUser;

namespace metal.Areas.troy.Controllers
{
    [Area("troy")]
    public class UsersController : Controller
    {
        private readonly Igetuserservice _getUsersService;
        private readonly igetroleservice _getRolesService;
        public UsersController(Igetuserservice getUsersService, igetroleservice getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
        }


        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(serchkey=serchkey,page=page));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }
    }
    }
