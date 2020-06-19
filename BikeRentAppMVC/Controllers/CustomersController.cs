using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.Core;
using BikeRentApp.Core.Enum;
using BikeRentApp.Data;
using BikeRentAppMVC.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeRentAppMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerData customerData;
        private readonly IHtmlHelper htmlHelper;
        private readonly IMembershipData membershipData;

        public CustomersController(ICustomerData customerData, IMembershipData membershipData, IHtmlHelper htmlHelper)
        {
            this.customerData = customerData;
            this.membershipData = membershipData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult List(string SearchName, string SearchEmail)
        {
            var model = new CustomersListViewModel();
            model.Customers = customerData.GetCustomers(SearchName, SearchEmail);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = new CustomersEditViewModel();
            if (id.HasValue)
            {
                model.Customer = customerData.GetCustomerById(id.Value);
                if (model.Customer == null)
                {
                    return View("NotFound");
                }                
            }
            else
            {
                model.Customer = new Customer();
            }
            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            model.Memberships = new SelectList(memberships, "Id", "Display");
            model.Gender = htmlHelper.GetEnumSelectList<Gender>();
            model.City = htmlHelper.GetEnumSelectList<City>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomersEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var membership = membershipData.GetMembershipById(model.Customer.Id);
                model.Customer.Membership = membership;

                if (model.Customer.Id == 0)
                {
                    model.Customer = customerData.Create(model.Customer);
                    TempData["TempMessage"] = "New customer is created!";
                }
                else
                {
                    model.Customer = customerData.Update(model.Customer);
                    TempData["TempMessage"] = "Data for customer is updated!";
                }

                customerData.Commit();
                return RedirectToAction("List");
            }
            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            model.Memberships = new SelectList(memberships, "Id", "Display");
            model.Gender = htmlHelper.GetEnumSelectList<Gender>();
            model.City = htmlHelper.GetEnumSelectList<City>();
            return View(model);
        }

        public IActionResult NotFound(int id)
        {
            return View("NotFound");
        }
    }
}
