using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentApp.Core
{
    public class Purchase
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public List<Bike> Bikes { get; set; }
        public Purchase()
        {
            Bikes = new List<Bike>();
        }
    }
}
