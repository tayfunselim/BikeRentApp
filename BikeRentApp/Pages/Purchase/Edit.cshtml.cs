using System.Collections.Generic;
using System.Linq;
using BikeRentApp.BusinessLayer;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeRentApp.Pages.Purchase
{
    public class EditModel : PageModel
    {
        private readonly IPurchaseData purchaseData;
        private readonly ICustomerData customerData;
        private readonly PurchaseBL purchaseBL;

        public EditModel(IPurchaseData purchaseData, ICustomerData customerData, PurchaseBL purchaseBL)
        {
            this.purchaseData = purchaseData;
            this.customerData = customerData;
            this.purchaseBL = purchaseBL;
        }
        
        [BindProperty]
        public Core.Purchase Purchase { get; set; }
        public string Message { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        
        public IActionResult OnGet()
        {
            Purchase = new Core.Purchase();
            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Purchase.CustomerId.Value);
                Purchase.Customer = customer;

                Purchase = purchaseData.Create(Purchase);
                TempData["TempMessage"] = "Purchase is registered!";

                purchaseData.Commit();
                return RedirectToPage("./List");
            }

            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }

        public IActionResult OnPostPurchase(double? BuyPrice, double? RentPrice)
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Purchase.CustomerId.Value);
                Purchase.Customer = customer;

                if (BuyPrice.HasValue && BuyPrice.Value > 0)
                {
                    Purchase.Bikes.Add(purchaseBL.CreateTofo(BuyPrice.Value));
                }
                if (RentPrice.HasValue && RentPrice.Value > 0)
                {
                    Purchase.Bikes.Add(purchaseBL.CreateTLady(RentPrice.Value));
                }
                if (RentPrice.HasValue && RentPrice.Value > 0)
                {
                    Purchase.Bikes.Add(purchaseBL.CreateTUni(RentPrice.Value));
                }
            }

            Message = Purchase.CustomerId == null ? "No customer selected." : $"Total expences: {purchaseBL.TotalPurchase(Purchase).ToString("c0")}";
            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }
    }
}