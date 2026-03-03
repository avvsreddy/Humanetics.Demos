using Humanetics.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Humanetics.DataLayer
{

    /// <summary>
    /// Provides methods for managing products and categories in the product database.
    /// </summary>
    /// <remarks>The ProductsRepository class implements the IProductsRepository interface and offers CRUD
    /// operations for products and categories. It uses a ProductDbContext instance to interact with the underlying data
    /// store. This class is intended for use in applications that require direct access to product and category data.
    /// Methods in this class may throw DataException if an operation fails, such as when an entity is not found or a
    /// database error occurs.</remarks>
    public class ProductsRepository : IProductsRepository
    {

        private ProductDbContext _db = null;// new ProductDbContext(); //Dependency - tightly coupled

        //public ProductsRepository(ProductDbContext db)
        //{
        //    this._db = db;
        //}

        public ProductsRepository()
        {
            this._db = new ProductDbContext(); // DIP - Dependency Inversion Principle - high level module should not depend on low level module, both should depend on abstraction
        }

        /// <summary>
        /// Adds a new category to the data store.
        /// </summary>
        /// <remarks>If an error occurs while adding the category, a DataException is thrown. The method
        /// does not check for duplicate categories; callers should ensure that the category does not already exist if
        /// uniqueness is required.</remarks>
        /// <param name="category">The category to add. Cannot be null.</param>
        /// <returns>true if the category was successfully added; otherwise, false.</returns>
        /// <exception cref="DataException">Thrown when an error occurs while adding the category.</exception>
        /// 
        public bool AddCategory(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                return _db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Log the exception - send it to a logging framework or write to a log file
                // You can use a logging framework like NLog, Serilog, or log4net to log the exception details
                DataException dataException = new DataException("An error occurred while adding the category.", ex);

                throw dataException; // Rethrow the exception to be handled by the calling code
            }

        }

        public bool AddProduct(Product product)
        {
            _db.Products.Add(product);
            return _db.SaveChanges() > 0;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            _db.Products.Add(product);
            //return _db.SaveChanges() > 0;
            return await _db.SaveChangesAsync() > 0;
            //sdfsdfsd
            //sdfsdfsdf
        }

        public bool DeleteProduct(int id)
        {
            var productToDelete = _db.Products.Find(id);
            if (productToDelete == null)
            {
                DataException dataException = new DataException("Product not found, cannot delete.");
                throw dataException;
            }
            _db.Products.Remove(productToDelete);
            return _db.SaveChanges() > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var productToDelete = await _db.Products.FindAsync(id);
            if (productToDelete == null)
            {
                DataException dataException = new DataException("Product not found, cannot delete.");
                throw dataException;
            }
            _db.Products.Remove(productToDelete);
            return await _db.SaveChangesAsync() > 0;
        }

        public bool EditCategory(Category category)
        {
            _db.Categories.Update(category);
            return _db.SaveChanges() > 0;
        }

        public bool EditProduct(Product product)
        {
            _db.Products.Update(product);
            return _db.SaveChanges() > 0;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public async Task<List<Product>> GetAllProductsAsynce()
        {
            return await _db.Products.ToListAsync();
        }

        /// <summary>
        /// Finds the category with the specified ID. If the category is not found, a DataException is thrown.
        /// </summary>
        /// <param name="id">The ID of the category to find.</param>
        /// <returns>The category with the specified ID.</returns>
        /// <exception cref="DataException">Thrown when the category is not found.</exception>
        public Category GetCategoryById(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                DataException dataException = new DataException("Category not found.");
                throw dataException;
            }
            return category;
        }

        public Product GetProductById(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                DataException dataException = new DataException("Product not found.");
                throw dataException;
            }
            return product;
        }
    }
}
