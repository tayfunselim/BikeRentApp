using BikeRentApp.Core;
using BikeRentApp.Core.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeRentApp.Data
{
    public class BikeDbContext : IdentityDbContext<IdentityUser>
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
}
