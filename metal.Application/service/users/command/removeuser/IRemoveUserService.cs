using metal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.users.command.removeuser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserId);
    }
}
