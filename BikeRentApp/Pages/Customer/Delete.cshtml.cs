using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerData customerData;

        public Core.Customer Customer { get; set; }

        public DeleteModel(ICustomerData customerData)
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

        public IActionResult OnPost(int id)
        {
            var temp = customerData.Delete(id);
            if (temp == null)
            {
                return RedirectToPage("./NotFound");
            }

            customerData.Commit();
            TempData["TempMessage"] = "The customer is deleted!";
            return RedirectToPage("./List");
        }
    }
}