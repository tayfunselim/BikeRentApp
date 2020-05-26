using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.BusinessLayer;
using BikeRentApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentApp.Pages.Purchase
{
    public class StatsModel : PageModel
    {
        private readonly IPurchaseData purchaseData;
        private readonly PurchaseBL purchaseBL;

        public StatsModel(IPurchaseData purchaseData, PurchaseBL purchaseBL)
        {
            this.purchaseData = purchaseData;
            this.purchaseBL = purchaseBL;
        }

        public IEnumerable<Core.Purchase> Purchases { get; set; }

        public void OnGet(int id)
        {
            Purchases = purchaseData.GetPurchasesByCustomer(id);
        }
    }
}