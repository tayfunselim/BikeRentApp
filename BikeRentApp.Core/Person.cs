using System.ComponentModel.DataAnnotations;

namespace BikeRentApp.Core
{
    public class Person
    {
        public int Id { get; set; }

        [Required, StringLength(20, MinimumLength = 3), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(20, MinimumLength = 3), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, Phone, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}