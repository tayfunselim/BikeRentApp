using System.ComponentModel.DataAnnotations;

namespace BikeRentApp.Core
{
    public class Customer : Person
    {
        public bool IsMember
        {
            get { return MembershipId.HasValue; }
        }

        [Display(Name = "Membership")]
        public int? MembershipId { get; set; }
        public Membership.Membership Membership { get; set; }
    }
}
