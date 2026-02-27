using Humanetics.DataLayer;
using Humanetics.DataLayer.Entities;

namespace Humanetics.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Manage Products - CRUD

            // DAL - EF - done
            // Install the required packages - done
            // SQL Server -done
            // Approach - Code First - done
            // Create a required Entity Classes - done
            // Confugure EF to use sql server - done
            // Generate the db and tables - migration


        }

        private static void Add()
        {
            // add a new product - write only OO code
            var p = new Product { Name = "I Phone 16", Price = 78000, Country = "India", IsAvailable = true };

            ProductDbContext db = new ProductDbContext();
            db.Products.Add(p);
            db.SaveChanges(); // writes product into products table
            Console.WriteLine("Product saved...");
        }
    }
}
