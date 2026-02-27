namespace Humanetics.DataLayer.Entities
{

    // Naming Convensions
    // Data Annotations
    // Fluent API - style
    public class Product // Entity Class
    {
        //[Key]
        public int ProductId { get; set; } // primary key
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Country { get; set; }
    }
}
