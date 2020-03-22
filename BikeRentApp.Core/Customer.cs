using System;
using System.Collections.Generic;
using System.Text;


namespace BikeRentApp.Core
{
    public class Customer : Person
    {
        public bool IsMember
        {
            get { return MembershipId.HasValue; }
        }

        public int? MembershipId { get; set; }
        public Membership.Membership Membership { get; set; }
    }
}
