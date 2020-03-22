using BikeRentApp.Core;
using BikeRentApp.Core.Membership;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeRentApp.Data.InSqlData
{
    public class MembershipDataSql : IMembershipData
    {
        private readonly BikeDbContext bikeDbContext;

        public MembershipDataSql(BikeDbContext bikeDbContext)
        {
            this.bikeDbContext = bikeDbContext;
        }
        public int Commit()
        {
            return bikeDbContext.SaveChanges();
        }

        public Membership Create(Membership membership)
        {
            bikeDbContext.Memberships.Add(membership);
            return membership;
        }

        public Membership Delete(int id)
        {
            var tempMembership = bikeDbContext.Memberships.SingleOrDefault (m => m.Id == id);
            if (tempMembership!=null)
            {
                bikeDbContext.Memberships.Remove(tempMembership);
            }
            return tempMembership;
        }

        public Membership GetMembershipById(int? id)
        {
            return bikeDbContext.Memberships.SingleOrDefault(m=>m.Id==id);
        }

        public IEnumerable<Membership> GetMemberships()
        {
            return bikeDbContext.Memberships.ToList();
        }

        public Membership Update(Membership membership)
        {
            bikeDbContext.Entry(membership).State = EntityState.Modified;
            return membership;
        }
    }
}
