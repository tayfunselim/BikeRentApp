using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Core.Membership
{
    public class Green : IMembership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public double GetDiscount()
        {
            return 20 / 100;
        }

        public MembershipType GetMembershipType()
        {
            return MembershipType.Green;
        }
    }
}
