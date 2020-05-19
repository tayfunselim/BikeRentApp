using BikeRentApp.Core.Enum;
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

        [Required, EmailAddress, DataType(DataType.EmailAddress), Display(Name = "E-mail Adress")]
        public string Email { get; set; }

        [Required, Phone, DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public City City { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

    }
}