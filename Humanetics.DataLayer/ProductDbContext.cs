using Humanetics.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Humanetics.DataLayer
{
    public class ProductDbContext : DbContext
    {
        // Configure with DB

        // through constructor
        // overriding OnConfiguring base class method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // configure the db with connection string
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HumaneticProductsDb;Integrated Security=True");
        }


        // Map Entity classes with tables
        // DbSet = In-memory database table
        public DbSet<Product> Products { get; set; }

    }
}
