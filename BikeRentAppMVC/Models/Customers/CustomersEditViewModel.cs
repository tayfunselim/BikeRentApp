using BikeRentApp.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BikeRentAppMVC.Models.Customers
{
    public class CustomersEditViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<SelectListItem> Memberships { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }
        public IEnumerable<SelectListItem> City { get; set; }
    }
}
