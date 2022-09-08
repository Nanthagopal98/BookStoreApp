using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iUserRl;

        public UserBL(IUserRL iUserRl)
        {
            this.iUserRl = iUserRl;
        }

        public bool Registration(RegisterModel model)
        {
            try
            {
                return iUserRl.Registration(model);
            }
            catch
            {
                throw;
            }
        }
        public string UserLogin(LoginModel loginModel)
        {
            try
            {
                return iUserRl.UserLogin(loginModel);
            }
            catch
            {
                throw;
            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                return iUserRl.ForgetPassword(email);
            }
            catch
            {
                throw;
            }
        }
        public bool ResetPassword(string email, string password, string confirmPassword)
        {
            try
            {
                return iUserRl.ResetPassword(email, password, confirmPassword);
            }
            catch
            {
                throw;
            }
        }
    }
}
