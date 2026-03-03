using Humanetics.DataLayer.Entities;

namespace Humanetics.DataLayer
{
    public interface IProductsRepository // what operations we want to perform on products table
    {

        #region Sync Methods
        bool AddProduct(Product product);

        #endregion

        #region Async Methods
        Task<bool> AddProductAsync(Product product);
        #endregion






        bool EditProduct(Product product);
        bool DeleteProduct(int id);
        Task<bool> DeleteProductAsync(int id);

        Product GetProductById(int id);
        List<Product> GetAllProducts();
        Task<List<Product>> GetAllProductsAsynce();

        bool AddCategory(Category category);
        bool EditCategory(Category category);
        // bool DeleteCategory(int id);


        /// <summary>
        /// Finds the category with the specified ID. If the category is not found, a DataException is thrown.
        /// </summary>
        /// <param name="id">The ID of the category to find.</param>
        /// <returns>The category with the specified ID.</returns>
        /// <exception cref="DataException">Thrown when the category is not found.</exception>
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();

    }
}
