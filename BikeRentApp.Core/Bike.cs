using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Core
{
    public class Bike
    {
        public int Id { get; set; }

        public double Price { get; set; }
        public BikeModel BikeModel { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
