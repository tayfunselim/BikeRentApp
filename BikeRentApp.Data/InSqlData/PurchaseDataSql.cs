using BikeRentApp.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BikeRentApp.Data.InSqlData
{
    public class PurchaseDataSql : IPurchaseData
    {
        private readonly BikeDbContext bikeDbContext;

        public PurchaseDataSql(BikeDbContext bikeDbContext)
        {
            this.bikeDbContext = bikeDbContext;
        }

        public int Commit()
        {
            return bikeDbContext.SaveChanges();
        }

        public Purchase Create(Purchase purchase)
        {
            bikeDbContext.Purchases.Add(purchase);
            return purchase;
        }

        public Purchase Delete(int id)
        {
            var tempPurchase = bikeDbContext.Purchases.SingleOrDefault(p=>p.Id == id);
            if (tempPurchase != null)
            {
                bikeDbContext.Purchases.Remove(tempPurchase);
            }
            return tempPurchase;
        }

        public IEnumerable<Purchase> GetPurchasesByCustomer(int id)
        {            
            return bikeDbContext
                .Purchases.Include(p => p.Customer).ThenInclude(p => p.Membership)
                          .Include(p => p.Bikes).Where(p => p.CustomerId == id)
                          .ToList();
        }

        public Purchase GetPurchaseById(int id)
        {
            return bikeDbContext.Purchases.SingleOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Purchase> GetPurchases(string searchTerm = null)
        {
            return bikeDbContext
                .Purchases.Include(p => p.Customer)
                          .ThenInclude(p => p.Membership)
                          .Include(p => p.Bikes)
                          .Where(p=>string.IsNullOrEmpty(searchTerm)
                            ||p.Customer.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                            ||p.Customer.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                          .OrderBy(p => p.Customer.FirstName)
                          .ToList();
        }

        public Purchase Update(Purchase purchase)
        {
            bikeDbContext.Entry(purchase).State = EntityState.Modified;
            return purchase;
        }
    }
}
