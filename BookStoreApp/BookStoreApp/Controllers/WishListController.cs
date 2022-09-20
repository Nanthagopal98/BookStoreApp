using Manager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL wishListBL;

        public WishListController(IWishListBL wishListBL)
        {
            this.wishListBL = wishListBL;
        }

        [HttpPost]
        [Route("AddToWishList")]
        public IActionResult AddToWishList(WishListModelCreate wishListModel)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = wishListBL.AddToWishList(UserId, wishListModel);
                if(result != false)
                {
                    return Ok(new { success = true, message = "WishList Added Successfully" });
                }
                return BadRequest(new {success = false, message = "Failed To Add WishList" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }
    }
}
