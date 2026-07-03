
using metal.Application.InterFace.Contexts;
using metal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using metal.Application.service.users.quary.getrole;
using metal.Application.Services.Users.Commands.RgegisterUser;

namespace metal.Application.service.users.quary.getrole
{
    public class GetRolesService : igetroleservice
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new RolesDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
