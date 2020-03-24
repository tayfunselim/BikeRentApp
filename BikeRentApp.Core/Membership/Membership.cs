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
        //public DateTime StartDate { get; set; }
        
        [Required, MaxLength(15)]
        public string MembershipType { get; set; }
        public double DiscountBuy { get; set; }
        public double DiscountRent { get; set; }
        //public virtual MembershipType GetMembershipType()
        //{
        //    return MembershipType.Blue;
        //}

        //public virtual double GetDiscount()
        //{
        //    return 10 / 100;
        //}
    }
}