using BikeRentApp.Core.Membership;
using BikeRentApp.Data;
using BikeRentAppMVC.Models.Memberships;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentAppMVC.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly IMembershipData membershipData;

        public MembershipsController(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }
        public IActionResult List()
        {
            var model = new MembershipsListViewModel();
            model.Memberships = membershipData.GetMemberships();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = new MembershipsEditViewModel();
            if (id.HasValue)
            {
                model.Membership = membershipData.GetMembershipById(id.Value);
            }
            else
            {
                model.Membership = new Membership();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MembershipsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Membership.Id == 0)
                {
                    model.Membership = membershipData.Create(model.Membership);
                    TempData["TempMessage"] = "New membership is created!";
                }
                else
                {
                    model.Membership = membershipData.Update(model.Membership);
                    TempData["TempMessage"] = "Membership terms are updated!";
                }
                membershipData.Commit();
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var membership = membershipData.GetMembershipById(id);
            return View(membership);
        }

        [HttpPost]
        public IActionResult Delete(Membership model)
        {
            var temp = membershipData.Delete(model.Id);
            membershipData.Commit();
            TempData["TempMessage"] = "The membership is deleted!";
            return RedirectToAction("List");
        }
    }
}
