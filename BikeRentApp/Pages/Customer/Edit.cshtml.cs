using System.Collections.Generic;
using System.Linq;
using BikeRentApp.Core.Enum;
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
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Customer Customer { get; set; }

        public IEnumerable<SelectListItem> Memberships { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }
        public IEnumerable<SelectListItem> City { get; set; }

        public EditModel(ICustomerData customerData, IMembershipData membershipData, IHtmlHelper htmlHelper)
        {
            this.customerData = customerData;
            this.membershipData = membershipData;
            this.htmlHelper = htmlHelper;
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
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            City = htmlHelper.GetEnumSelectList<City>();
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
                    TempData["TempMessage"] = "New customer is created!";
                }
                else
                {
                    Customer = customerData.Update(Customer);
                    TempData["TempMessage"] = "Data for customer is updated!";
                }

                customerData.Commit();
                return RedirectToPage("./List");
            }

            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            Memberships = new SelectList(memberships, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            City = htmlHelper.GetEnumSelectList<City>();
            return Page();
        }
    }
}