using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IUserBL
    {
        public bool Registration(RegisterModel model);
        public string UserLogin(LoginModel loginModel);
        public string ForgetPassword(string email);
    }
}
