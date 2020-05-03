using BikeRentApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Data
{
    public interface IPurchaseData
    {
        Purchase Create(Purchase purchase);
        Purchase GetPurchaseById(int id);
        int Commit();
        IEnumerable<Purchase> GetPurchases();
        IEnumerable<Purchase> GetPurchasesByCustomer(int id);
        Purchase Update(Purchase purchase);
        Purchase Delete(int id);

    }
}
