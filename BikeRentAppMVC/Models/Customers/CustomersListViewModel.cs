using BikeRentApp.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentAppMVC.Models.Customers
{
    public class CustomersListViewModel
    {
        [Display(Name = "Search by name")]
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [Display(Name = "Search by e-mail")]
        [BindProperty(SupportsGet = true)]
        public string SearchEmail { get; set; }


        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
