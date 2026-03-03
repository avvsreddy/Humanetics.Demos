using Humanetics.DataLayer;

namespace Humanetics.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductsRepository repo = new ProductsRepository();

            var allCategories = repo.GetAllCategories();

            foreach (var category in allCategories)
            {
                Console.WriteLine($"{category.CategoryId} \t {category.Name}");
            }

            try
            {
                var category1 = repo.GetCategoryById(1);
                Console.WriteLine($"{category1.CategoryId} \t {category1.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        #region Other methods
        /*
        private static void NewProductWithExistingCategory()
        {
            // Add new product with existing category

            ProductDbContext db = new ProductDbContext();
            var category = db.Categories.Find(2);


            var product = new Product { Name = "Dell Inspiron", Price = 78000, Country = "India", IsAvailable = true, Category = category, Brand = "Dell" };

            db.Products.Add(product);
            db.SaveChanges();
        }

        private static void NewProductWithNewCategory()
        {
            // add new product with new category
            ProductDbContext db = new ProductDbContext();

            var category = new Category { Name = "Laptops" };

            var product = new Product { Name = "HP Pavilion", Price = 88000, Country = "India", IsAvailable = true, Category = category, Brand = "HP" };

            db.Products.Add(product);
            //db.Categories.Add(category);
            db.SaveChanges();
        }

        private static void PLinq()
        {
            // PLinq = Parallel LINQ

            ProductDbContext db = new ProductDbContext();
            var allProducts = (from p in db.Products
                               select p).AsParallel();
        }

        private static void AsNoTracking()
        {
            // Get the data for only read operations
            ProductDbContext db = new ProductDbContext();
            var allProducts = (from p in db.Products
                               select p).AsNoTracking<Product>();

            foreach (var product in allProducts)
            {
                Console.WriteLine($"{product.Name} \t {product.Price}");
                db.Products.Remove(product); // still delete the product, but it will not be tracked by db context
            }

            //db.Products.RemoveRange(allProducts);
            db.SaveChanges();
        }

        private static void Edit()
        {
            ProductDbContext db = new ProductDbContext();
            // Edit
            // Fetch the record to edit
            var productToEdit = db.Products.Find(1);
            if (productToEdit != null)
            {
                productToEdit.Price = 99999;
                productToEdit.Brand = "Apple";
                //db.Products.Update(productToEdit);
                db.SaveChanges();
            }
        }

        private static void SqlRaw()
        {
            // Delete range of records

            string sqlDelete = "delete from products where country = 'a'";
            ProductDbContext db = new ProductDbContext();

            db.Database.ExecuteSqlRaw(sqlDelete);
        }

        private static void RemoveRange()
        {
            // Delete range of products
            // fetch the records to delete
            ProductDbContext db = new ProductDbContext();
            var productsToDelete = from p in db.Products
                                   where p.Brand == "aaa"
                                   select p;

            // remove one at a time
            //foreach (var product in productsToDelete)
            //{
            //    db.Products.Remove(product);
            //}
            // remove all at once
            db.Products.RemoveRange(productsToDelete);

            db.SaveChanges();
        }

        private static void Delete()
        {
            // Delete
            // Fetch the record/row/object from db
            ProductDbContext db = new ProductDbContext();
            var productToDelete = db.Products.Find(1);
            //db.Products.Remove(productToDelete);
            db.Products.Entry(productToDelete).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private static void Find()
        {
            // Search for a product by id and display details

            ProductDbContext dbContext = new ProductDbContext();
            //var product1 = (from p in dbContext.Products
            //                where p.ProductId == 1
            //                select p).FirstOrDefault();

            var product1 = dbContext.Products.Find(1);


            Console.WriteLine(product1.Name);

            //var product2 = (from p in dbContext.Products
            //                where p.ProductId == 1
            //                select p).FirstOrDefault();

            var product2 = dbContext.Products.Find(1);
            Console.WriteLine(product2.Name);
        }

        private static void Read()
        {
            // get all products and display

            //var allProducts = from p in dbContext.Products
            //                  select p;

            ProductDbContext dbContext = new();

            var allProducts = dbContext.Products;


            foreach (var product in allProducts)
            {
                Console.WriteLine($"{product.Name} \t {product.Price}");
            }
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
        */
        #endregion
    }
}
