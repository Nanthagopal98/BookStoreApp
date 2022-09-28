using Manager.Interface;
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
                    return Ok(new { success = true, message = "Admin Logged in", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Admin login Failed"});
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("getAdmin")]
        public IActionResult GetAdmin()
        {
            try
            {
                var result = this.iAdminBL.GetAdmin();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get Admin Successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Get Admin Failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
