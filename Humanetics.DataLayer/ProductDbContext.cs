using Humanetics.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Humanetics.DataLayer
{
    internal class ProductDbContext : DbContext
    {
        // Configure with DB

        // through constructor
        // overriding OnConfiguring base class method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // configure the db with connection string
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HumaneticProductsDb;Integrated Security=True")
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// normal code to configure the model
            //modelBuilder.Entity<Product>().ToTable("tbl_products"); //[Table("tbl_products" )]
            //modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50);
            //modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();

            //// with fluent API - method chaining
            //modelBuilder.Entity<Product>().Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Person>().UseTptMappingStrategy(); // not recommended for performance
            modelBuilder.Entity<Person>().UseTpcMappingStrategy(); //best for performance
            //modelBuilder.Entity<Person>().UseTphMappingStrategy(); // default strategy


        }


        // Map Entity classes with tables
        // DbSet = In-memory database table
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
