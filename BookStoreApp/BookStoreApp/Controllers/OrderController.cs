using Manager.Interface;
using Manager.Service;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public IActionResult PlaceOrder(OrderModel orderModel)
        {
            try
            {
                var result = orderBL.PlaceOrder(orderModel);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Order Successful" });
                }
                return BadRequest(new {success = false, message = "order Failed"});
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("CancelOrder")]
        public IActionResult CancelOrder(int orderId)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = orderBL.CancelOrder(orderId,UserId);
                if (result != null)
                {
                    return Ok(new { succcess = true, message = "Cancel Order Success"});
                }
                return BadRequest(new { success = false, message = "Cancel Order Failed" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
