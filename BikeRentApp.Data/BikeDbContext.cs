using BikeRentApp.Core;
using Microsoft.EntityFrameworkCore;

namespace BikeRentApp.Data
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<IMembership> Memberships { get; set; }
    }
}
