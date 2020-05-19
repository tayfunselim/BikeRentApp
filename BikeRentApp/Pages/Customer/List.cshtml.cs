using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display (Name = "Search by name")]
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [Display(Name = "Search by e-mail")]
        [BindProperty(SupportsGet = true)]
        public string SearchEmail { get; set; }

        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Core.Customer> Customers { get; set; }
        public void OnGet()
        {
            Customers = customerData.GetCustomers(SearchName, SearchEmail);
        }
    }
}