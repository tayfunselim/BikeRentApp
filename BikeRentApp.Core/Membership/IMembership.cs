using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Core
{
    public interface IMembership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        MembershipType GetMembershipType();
        
        double GetDiscount();
    }
}
