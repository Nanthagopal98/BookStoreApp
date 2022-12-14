using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;
using System;
using System.Security.Claims;
using System.Collections.Generic;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        public ICartBL CartBL;
        public CartController(ICartBL cartBL)
        {
            CartBL = cartBL;
        }

        
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
                return BadRequest(new { success = false, meassage = "Book Already Added in Cart" });
            }
            catch(System.Exception) 
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateCart")]
        public IActionResult UpdateCart(CartUpdateModel cartUpdateModel)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = CartBL.UpdateCart(UserId, cartUpdateModel);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Cart Updated" });
                }
                return BadRequest(new { success = false, messsage = "Cart Update Failed" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteCart")]
        public IActionResult DeleteCart(int bookId)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = CartBL.DeleteCart(bookId, UserId);
                if(result != false)
                {
                    return Ok(new { succcess = true, message = "Cart Delete Success" });
                }
                return BadRequest(new { success = false, message = "Cart Delete Failed" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAllCart")]
        public IActionResult GetCart()
        {
            try {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = CartBL.GetCart(UserId);
                if (result != null)
                {
                    return Ok(new { succcess = true, message = "Get Cart Success", data = result });
                }
                return BadRequest(new { success = false, message = "Get Cart Failed" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
