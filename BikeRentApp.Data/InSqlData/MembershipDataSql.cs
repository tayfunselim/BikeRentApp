using BikeRentApp.Core;
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

        public IMembership Create(IMembership membership)
        {
            bikeDbContext.Memberships.Add(membership);
            return membership;
        }

        public IMembership Delete(int id)
        {
            var tempMembership = bikeDbContext.Memberships.SingleOrDefault (m => m.Id == id);
            if (tempMembership!=null)
            {
                bikeDbContext.Memberships.Remove(tempMembership);
            }
            return tempMembership;
        }

        public IMembership GetMembershipById(int? id)
        {
            return bikeDbContext.Memberships.SingleOrDefault(m=>m.Id==id);
        }

        public IEnumerable<IMembership> GetMemberships()
        {
            return bikeDbContext.Memberships.ToList();
        }

        public IMembership Update(IMembership membership)
        {
            bikeDbContext.Entry(membership).State = EntityState.Modified;
            return membership;
        }
    }
}
