using BikeRentApp.Core;
using System.Collections.Generic;

namespace BikeRentApp.Data
{
    public interface ICustomerData
    {
        Customer Create(Customer customer);
        Customer GetCustomerById(int id);
        Customer Update(Customer customer);
        int Commit();
        Customer Delete(int id);
        IEnumerable<Customer> GetCustomers(string searchName = null, string searchEmail = null);
    }
}