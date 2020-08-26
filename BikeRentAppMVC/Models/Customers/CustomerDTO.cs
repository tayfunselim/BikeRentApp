using BikeRentApp.Core.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentAppMVC.Models.Customers
{
    public class CustomerDTO : PersonDTO
    {
        public bool IsMember
        {
            get { return MembershipId.HasValue; }
        }

        [Display(Name = "Membership")]
        public int? MembershipId { get; set; }
        //public Membership.Membership Membership { get; set; }
    }
}
