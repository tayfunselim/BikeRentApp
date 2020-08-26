using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentAppMVC.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        private readonly ICustomerData customerData;

        public CustomersApiController(ICustomerData customerData)
        {
            this.customerData = customerData;
        }

        [HttpGet]
        public IActionResult GetCustomersAll()
        {
            return Ok(customerData.GetCustomers());
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomers(int id)
        {
            var data = customerData.GetCustomerById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //[HttpPost]
        //public IActionResult Create()
        //{

        //}
    }
}
