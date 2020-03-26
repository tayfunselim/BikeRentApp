using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerData customerData;
        public Core.Customer Customer { get; set; }
        public DetailsModel(ICustomerData customerData)
        {
            this.customerData = customerData;
        }

        public IActionResult OnGet(int id)
        {
            Customer = customerData.GetCustomerById(id);
            if (Customer == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }        
    }
}