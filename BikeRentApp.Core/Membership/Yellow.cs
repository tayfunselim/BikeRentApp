using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Core.Membership
{
    public class Yellow : IMembership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public double GetDiscount()
        {
            return 15 / 100; ;
        }

        public MembershipType GetMembershipType()
        {
            return MembershipType.Yellow;
        }
    }
}
