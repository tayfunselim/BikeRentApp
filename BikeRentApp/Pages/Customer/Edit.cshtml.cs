using System.Collections.Generic;
using System.Linq;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeRentApp.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly ICustomerData customerData;
        private readonly IMembershipData membershipData;        

        [BindProperty]
        public Core.Customer Customer { get; set; }

        public IEnumerable<SelectListItem> Memberships { get; set; }       
        
        public EditModel(ICustomerData customerData, IMembershipData membershipData)
        {
            this.customerData = customerData;
            this.membershipData = membershipData;            
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Customer = customerData.GetCustomerById(id.Value);
                if (Customer == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Customer = new Core.Customer();
            }

            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            Memberships = new SelectList(memberships, "Id", "Display");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var membership = membershipData.GetMembershipById(Customer.MembershipId);
                Customer.Membership = membership;
                
                if (Customer.Id == 0)
                {
                    Customer = customerData.Create(Customer);
                    TempData["Message"] = "New customer is created!";
                }
                else
                {
                    Customer = customerData.Update(Customer);
                    TempData["Message"] = "The customer is updated!";
                }

                customerData.Commit();
                return RedirectToPage("./List");
            }

            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            Memberships = new SelectList(memberships, "Id", "Display");
            return Page();
        }
    }
}