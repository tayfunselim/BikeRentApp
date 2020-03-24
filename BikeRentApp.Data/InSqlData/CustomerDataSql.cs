using BikeRentApp.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return bikeDbContext.Customers
                .Include(m => m.Membership)
                .Include (e=>e.Email)
                .SingleOrDefault(c=>c.Id == id);
        }
        

        public IEnumerable<Customer> GetCustomers(string searchName = null, string searchEmail = null)
        {
            var sNamePattern = !string.IsNullOrEmpty(searchName) ? $"{searchName}%" : searchName;
            var emailPattern = !string.IsNullOrEmpty(searchEmail) ? $"{searchEmail}%" : searchEmail;
            return bikeDbContext.Customers
                .Where(c => string.IsNullOrEmpty(searchName) || EF.Functions.Like(c.FirstName, sNamePattern))
                .Where(c => string.IsNullOrEmpty(searchName) || EF.Functions.Like(c.LastName, sNamePattern))
                .Where(c => string.IsNullOrEmpty(searchEmail) || EF.Functions.Like(c.Email, emailPattern))
                .ToList();                
        }

        public Customer Update(Customer customer)
        {
            bikeDbContext.Entry(customer).State = EntityState.Modified;
            return customer;
        }
    }
}