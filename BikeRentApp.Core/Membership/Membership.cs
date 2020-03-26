using System;
using System.ComponentModel.DataAnnotations;

namespace BikeRentApp.Core.Membership
{
    public class Membership
    {
        public Membership()
        {
            DiscountRent = 15 / 100;
        }
        public int Id { get; set; }
        
        [Required, MaxLength(15)]
        public string MembershipType { get; set; }
        
        [Required]
        public double DiscountBuy { get; set; }
        
        [Required]
        public double DiscountRent { get; set; }        
    }
}