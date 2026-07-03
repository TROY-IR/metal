using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace metal.Application.service.users.quary.get
{
    public interface Igetuserservice
    {
        ReslutGetUserDto Execute(string searchkey, int page = 1);
    }
}
