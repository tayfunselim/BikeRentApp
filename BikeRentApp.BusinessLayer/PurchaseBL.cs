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

        public Bike CreateTofo(double price)
        {
            return new Bike
            {
                BikeModel = BikeModel.Tofo,
                Price = price
            };
        }
        
        public Bike CreateTLady(double price)
        {
            return new Bike
            {
                BikeModel = BikeModel.TLady,
                Price = price
            };
        }

        public Bike CreateTUni(double price)
        {
            return new Bike
            {
                BikeModel = BikeModel.TUni,
                Price = price
            };
        }

        public double TotalPurchase (Purchase purchase)
        {
            var sum = 0.0;            
            foreach (var item in purchase.Bikes.Where(b => b.BikeModel == BikeModel.Tofo).ToList())
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

            foreach (var item in purchase.Bikes.Where(b => b.BikeModel == BikeModel.TLady).ToList())
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

            foreach (var item in purchase.Bikes.Where(b => b.BikeModel == BikeModel.TUni).ToList())
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
