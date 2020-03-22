using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Core.Membership
{
    public class Membership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public virtual MembershipType GetMembershipType()
        {
            return MembershipType.Blue;
        }

        public virtual double GetDiscount()
        {
            return 10 / 100;
        }
    }
}