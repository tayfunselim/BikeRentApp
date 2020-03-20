using BikeRentApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Data
{
    public interface ICustomerData
    {
        Customer Create(Customer customer);
        Customer GetCustomerById(int id);
        Customer Update(Customer customer);
        int Commit();
        Customer Delete(int id);
        IEnumerable<Customer> GetCustomers(string searchTerm = null);
    }
}
