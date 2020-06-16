using BikeRentApp.Core;
using BikeRentApp.Core.Membership;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentAppMVC.Models.Memberships
{
    public class MembershipsListViewModel
    {
        public IEnumerable<Membership> Memberships { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        [TempData]
        public string TempMessage { get; set; }
    }
}
