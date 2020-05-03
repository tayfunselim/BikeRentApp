using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentApp.Api
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly ICustomerData customerData;

        public CustomerApiController(ICustomerData customerData)
        {
            this.customerData = customerData;
        }

        [HttpGet]
        public IActionResult GetCustomersAll()
        {
            var data = customerData.GetCustomers();
            return Ok(data);
        }

        [HttpGet ("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var data = customerData.GetCustomerById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}