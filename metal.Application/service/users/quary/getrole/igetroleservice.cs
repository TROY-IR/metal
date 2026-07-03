using metal.Application.InterFace.Contexts;
using metal.Application.service.users.quary.getrole;
using metal.Common;
using metal.Domain.Entities.users;
using System;
using System.Collections.Generic;
using System.Text;


namespace metal.Application.Services.Users.Commands.RgegisterUser
{
    public interface igetroleservice
    {
        ResultDto<List<RolesDto>> Execute();
    }

}
