using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;
using System;
using Experimental.System.Messaging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL addressBL;

        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [HttpPost]
        [Route("AddAddress")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = addressBL.AddAddress(addressModel, UserId);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Address Added Successfully" });
                }
                return BadRequest(new { success = false, message = "Failed to Add Address"});
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateAddress")]
        public IActionResult UpdateAddress(AddressUpdateModel addressModel, int addressId)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = addressBL.UpdateAddress(addressModel, UserId);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Address Update Successful"});
                }
                return BadRequest(new { success = false, message = "Failed To Update Address" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAddress")]
        public IActionResult GetAllAddress()
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = addressBL.GetAllAddress(UserId);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Address Get from DB", data = result });
                }
                return BadRequest(new { success = false, message = "Failed" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }
    }
}
