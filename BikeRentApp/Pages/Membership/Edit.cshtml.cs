using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Membership
{
    public class EditModel : PageModel
    {
        private readonly IMembershipData membershipData;
        
        [BindProperty]
        public Core.Membership.Membership Membership { get; set; }

        public EditModel(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Membership = membershipData.GetMembershipById(id.Value);
                if (Membership == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Membership = new Core.Membership.Membership();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Membership.Id == 0)
                {
                    Membership = membershipData.Create(Membership);
                    TempData["Message"] = "The Membership is created!";
                }
                else
                {
                    Membership = membershipData.Update(Membership);
                    TempData["Message"] = "The Membership is updated!";
                }
                
                membershipData.Commit();
                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}