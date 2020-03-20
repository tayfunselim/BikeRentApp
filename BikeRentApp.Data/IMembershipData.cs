using BikeRentApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Data
{
    public interface IMembershipData
    {
        IMembership Create(IMembership membership);
        IEnumerable<IMembership> GetMemberships();
        IMembership GetMembershipById(int? id);
        int Commit();

        IMembership Update(IMembership membership);
        IMembership Delete(int id);

    }
}
