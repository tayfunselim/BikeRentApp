using BikeRentApp.Core;
using BikeRentApp.Data;
using System.Linq;

namespace BikeRentApp.BusinessLayer
{
    public class PurchaseBL
    {
        private readonly IPurchaseData purchaseData;

        public PurchaseBL(IPurchaseData purchaseData)
        {
            this.purchaseData = purchaseData;
        }

        public Bike CreateBuy(double price)
        {
            return new Bike
            {
                BikeModel = PurchaseType.Buy,
                Price = price
            };
        }
        
        public Bike CreateRent(double price)
        {
            return new Bike
            {
                BikeModel = PurchaseType.Rent,
                Price = price
            };
        }

        public double TotalPurchase (Purchase purchase)
        {
            var sum = 0.0;            
            foreach (var item in purchase.Bikes.Where(b => b.BikeModel == PurchaseType.Buy).ToList())
            {
                if (purchase.Customer.IsMember)
                {
                    sum += item.Price * (1 - purchase.Customer.Membership.DiscountBuy);
                }
                else
                {
                    sum += item.Price;
                }
            }

            foreach (var item in purchase.Bikes.Where(b => b.BikeModel == PurchaseType.Rent).ToList())
            {
                if (purchase.Customer.IsMember)
                {
                    sum += item.Price * (1 - purchase.Customer.Membership.DiscountRent);
                }
                else
                {
                    sum += item.Price;
                }
            }

            return sum;
        }
    }
}
