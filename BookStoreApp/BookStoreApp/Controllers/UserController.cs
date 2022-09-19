using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;

namespace BookStoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL iUserBl;

        public UserController(IUserBL iUserBl)
        {
            this.iUserBl = iUserBl;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Registration([FromBody] RegisterModel model)
        {
            try
            {
                var result = this.iUserBl.Registration(model);
                if (result != false)
                {
                    return Ok(new { success = true, message = "User Added Successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Failed to Add User" });
                }
            }
            catch(System.Exception){
                 throw;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin([FromBody]  LoginModel loginModel)
        {
            try
            {
                var result = this.iUserBl.UserLogin(loginModel);
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

        [HttpPost]
        [Route("Forget")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = iUserBl.ForgetPassword(email);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Mail Sent Successfully", data = result});
                }
                else
                {
                    return BadRequest(new { success = false, meaasge = "Email Not Send" });
                }
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Reset")]
        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = iUserBl.ResetPassword(email, password, confirmPassword);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Password Rest Successfull" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Password Rest Failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
