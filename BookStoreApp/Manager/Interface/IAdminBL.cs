using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IAdminBL
    {
        public string AdminLogin(LoginModel loginModel);
    }
}
