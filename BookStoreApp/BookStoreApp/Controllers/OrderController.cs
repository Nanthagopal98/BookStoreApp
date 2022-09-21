using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

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
    }
}
