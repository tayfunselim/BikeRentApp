using BikeRentApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeRentApp.Data.InSqlData
{
    public class CustomerDataSql : ICustomerData
    {
        private readonly BikeDbContext bikeDbContext;

        public CustomerDataSql(BikeDbContext bikeDbContext)
        {
            this.bikeDbContext = bikeDbContext;
        }
        public int Commit()
        {
            return bikeDbContext.SaveChanges();
        }

        public Customer Create(Customer customer)
        {
            bikeDbContext.Customers.Add(customer);
            return customer;
        }

        public Customer Delete(int id)
        {            
            var tempCustomer = bikeDbContext.Customers.SingleOrDefault(c=> c.Id == id);
            if (tempCustomer != null)
            {
                bikeDbContext.Customers.Remove(tempCustomer);
            }
            return tempCustomer;
        }

        public Customer GetCustomerById(int id)
        {
            return bikeDbContext.Customers.Include(m => m.Membership).SingleOrDefault(c=>c.Id == id);
        }

        public IEnumerable<Customer> GetCustomers(string searchTerm = null)
        {
            return bikeDbContext.Customers
                .Include(m => m.Membership)
                .Where(n => string.IsNullOrEmpty(searchTerm)
                    || n.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                    || n.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                    .OrderBy(n => n.FirstName)
                    .ToList();
        }

        public Customer Update(Customer customer)
        {
            bikeDbContext.Entry(customer).State = EntityState.Modified;
            return customer;
        }
    }
}
