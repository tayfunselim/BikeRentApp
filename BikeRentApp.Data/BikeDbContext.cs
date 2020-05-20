using BikeRentApp.Core;
using BikeRentApp.Core.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BikeRentApp.Data
{
    public class BikeDbContext : IdentityDbContext<IdentityUser>
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Membership>().HasData(new List<Membership>
            {
                new Membership
                {
                     Id = 1,
                     MembershipType = "Green",
                     DiscountBuy = 0.20,
                     DiscountRent = 0.20
                },
                new Membership
                {
                    Id = 2,
                    MembershipType = "Blue",
                    DiscountBuy = 0.15,
                    DiscountRent = 0.13
                },
                new Membership
                {
                    Id = 3,
                    MembershipType = "Yellow",
                    DiscountBuy = 0.1,
                    DiscountRent = 0.1
                }
            });

            modelBuilder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Tayfun",
                    LastName = "Selim",
                    Email = "tayfunselim@gmail.com",
                    PhoneNumber = "075-271056",
                    MembershipId = 1,
                    City = Core.Enum.City.Skopje,
                    Gender = Core.Enum.Gender.Male,
                    Age = 35

                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Goran",
                    LastName = "Goranov",
                    Email = "ggor@gmail.com",
                    PhoneNumber = "072-371057",
                    MembershipId = 2,
                    City = Core.Enum.City.Bitola,
                    Gender = Core.Enum.Gender.Male,
                    Age = 23
                },
                 new Customer
                {
                    Id = 3,
                    FirstName = "Petar",
                    LastName = "Petrovski",
                    Email = "petre@yahoo.com",
                    PhoneNumber = "071-273057",
                    MembershipId = 3,
                    City = Core.Enum.City.Kumanovo,
                    Gender = Core.Enum.Gender.Male,
                    Age = 28
                },
                  new Customer
                {
                    Id = 4,
                    FirstName = "Maja",
                    LastName = "Petrovska",
                    Email = "majap@gmail.com",
                    PhoneNumber = "078-371957",
                    MembershipId = 3,
                    City = Core.Enum.City.Kumanovo,
                    Gender = Core.Enum.Gender.Female,
                    Age = 29
                },
                   new Customer
                {
                    Id = 5,
                    FirstName = "Svetlana",
                    LastName = "Svetlovska",
                    Email = "svetles@hotmail.com",
                    PhoneNumber = "072-371059",
                    MembershipId = 2,
                    City = Core.Enum.City.Strumica,
                    Gender = Core.Enum.Gender.Female,
                    Age = 33
                },
                   new Customer
                {
                    Id = 6,
                    FirstName = "Jole",
                    LastName = "Mala",
                    Email = "jolem@hotmail.com",
                    PhoneNumber = "078-371359",
                    MembershipId = 1,
                    City = Core.Enum.City.Ohrid,
                    Gender = Core.Enum.Gender.Female,
                    Age = 38
                },
                   new Customer
                {
                    Id = 7,
                    FirstName = "Gordana",
                    LastName = "Gorde",
                    Email = "gorde@hotmail.com",
                    PhoneNumber = "071-271059",
                    MembershipId = 3,
                    City = Core.Enum.City.Tetovo,
                    Gender = Core.Enum.Gender.Female,
                    Age = 33
                },
                   new Customer
                {
                    Id = 8,
                    FirstName = "Fatmir",
                    LastName = "Iseni",
                    Email = "fato@hotmail.com",
                    PhoneNumber = "072-371042",
                    MembershipId = 2,
                    City = Core.Enum.City.Skopje,
                    Gender = Core.Enum.Gender.Male,
                    Age = 37
                },
                   new Customer
                   {
                       Id = 14,
                    FirstName = "Monika",
                    LastName = "Gogo",
                    Email = "mogo@hotmail.com",
                    PhoneNumber = "071-371042",
                    MembershipId = 2,
                    City = Core.Enum.City.Skopje,
                    Gender = Core.Enum.Gender.Female,
                    Age = 57
                   }
            });
        }
    }
}
