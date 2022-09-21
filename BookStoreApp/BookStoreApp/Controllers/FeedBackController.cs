using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;
using System;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedBackController : ControllerBase
    {

        public IFeedBackBL feedBackBL;
        public FeedBackController(IFeedBackBL feedBackBL)
        {
            this.feedBackBL = feedBackBL;
        }


        [HttpPost]
        [Route("AddFeedBack")]
        public IActionResult AddFeedBack(FeedBackModel feedBackModel)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = feedBackBL.AddFeedBack(feedBackModel,UserId);
                if (result != false)
                {
                    return Ok(new { success = true, message = "Added To Cart" });
                }
                return BadRequest(new { success = false, meassage = "Failed To add To Cart" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
