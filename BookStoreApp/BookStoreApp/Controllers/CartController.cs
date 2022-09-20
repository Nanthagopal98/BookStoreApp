using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;
using System;
using System.Security.Claims;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartBL CartBL;
        public CartController(ICartBL cartBL)
        {
            CartBL = cartBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart(CartModel cartModel)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = CartBL.AddToCart(UserId, cartModel);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Added To Cart" });
                }
                return BadRequest(new { success = false, meassage = "Failed To add To Cart" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }
    }
}
