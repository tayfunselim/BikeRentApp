using BikeRentApp.Core;
using BikeRentApp.Core.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Data
{
    public interface IMembershipData
    {
        Membership Create(Membership membership);
        IEnumerable<Membership> GetMemberships();
        Membership GetMembershipById(int? id);
        int Commit();

        Membership Update(Membership membership);
        Membership Delete(int id);
    }
}
