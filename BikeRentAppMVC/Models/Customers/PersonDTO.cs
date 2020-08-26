using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentAppMVC.Models.Customers
{
    public class PersonDTO
    {        

        [Required, StringLength(20, MinimumLength = 3), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(20, MinimumLength = 3), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress), Display(Name = "E-mail Adress")]
        public string Email { get; set; }

        [Required, Phone, DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public int City { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Gender { get; set; }
    }
}
