using System.Collections.Generic;
using BikeRentApp.BusinessLayer;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages
{
    public class ListModel : PageModel
    {
        private readonly IPurchaseData purchaseData;
        private readonly PurchaseBL purchaseBL;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        [TempData]
        public string TempMessage { get; set; }
        public IEnumerable<Core.Purchase> Purchases { get; set; }

        public ListModel(IPurchaseData purchaseData, PurchaseBL purchaseBL)
        {
            this.purchaseData = purchaseData;
            this.purchaseBL = purchaseBL;
        }

        public double GetTotalPurchase(Core.Purchase purchase)
        {
            return purchaseBL.TotalPurchase(purchase);
        }

        public void OnGet()
        {
            Purchases = purchaseData.GetPurchases(SearchTerm);
        }
    }
}