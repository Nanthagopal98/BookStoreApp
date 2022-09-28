using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL iAdminRL;

        public AdminBL(IAdminRL iAdminRL)
        {
            this.iAdminRL = iAdminRL;
        }
        public string AdminLogin(LoginModel loginModel)
        {
            try
            {
                return iAdminRL.AdminLogin(loginModel);
            }
            catch
            {
                throw;
            }
        }

        public GetAdminModel GetAdmin()
        {
            try
            {
                return iAdminRL.GetAdmin();
            }
            catch
            {
                throw;
            }
        }
    }
}
