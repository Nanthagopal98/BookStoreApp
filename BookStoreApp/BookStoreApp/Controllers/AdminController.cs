﻿using Manager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL iAdminBL;

        public AdminController(IAdminBL iAdminBL)
        {
            this.iAdminBL = iAdminBL;
        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult UserLogin([FromBody] LoginModel loginModel)
        {
            try
            {
                var result = this.iAdminBL.AdminLogin(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "User Logged in", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Failed to login" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
