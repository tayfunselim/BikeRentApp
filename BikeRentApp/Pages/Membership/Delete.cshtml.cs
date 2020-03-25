using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Membership
{
    public class DeleteModel : PageModel
    {
        private readonly IMembershipData membershipData;

        public Core.Membership.Membership Membership { get; set; }

        public DeleteModel(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }
        public IActionResult OnGet(int id)
        {
            Membership = membershipData.GetMembershipById(id);
            if (Membership == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = membershipData.Delete(id);
            if (temp == null)
            {
                return RedirectToPage("./NotFound");
            }
            membershipData.Commit();
            TempData["Message"] = "The membership is deleted!";
            return RedirectToPage("./List");
        }

    }
}