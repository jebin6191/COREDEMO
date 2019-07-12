using System;
using System.Collections.Generic;
using System.Text;
using ZILDING_CORE.Models;

namespace ZILDING_CORE
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
