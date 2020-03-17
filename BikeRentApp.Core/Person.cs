using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeRentApp.Core
{
    public class Person
    {
        public int Id { get; set; }
        [Required, MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }
                
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Phone, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}