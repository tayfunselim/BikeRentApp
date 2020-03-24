using System.Collections.Generic;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Customer
{
    public class ListModel : PageModel
    {
        private readonly ICustomerData customerData;
        public ListModel(ICustomerData customerData)
        {
            this.customerData = customerData;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchEmail { get; set; }
        public IEnumerable<Core.Customer> Customers { get; set; }
        public void OnGet()
        {
            Customers = customerData.GetCustomers(SearchName, SearchEmail);
        }
    }
}