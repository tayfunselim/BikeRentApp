using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Membership
{
    public class ListModel : PageModel
    {
        private readonly IMembershipData membershipData;
        public IEnumerable<Core.Membership.Membership> Memberships { get; set; }
        
        [TempData]
        public string TempMessage { get; set; }

        public ListModel(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }

        public void OnGet()
        {
            Memberships = membershipData.GetMemberships();
        }
    }
}