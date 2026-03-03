using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Humanetics.DataLayer.Entities
{

    // Naming Convensions - PascalCase for class names and properties
    // Data Annotations - entity class
    // Fluent API - style - Ctx class
    [Table("tbl_products")]
    public class Product // Entity Class
    {
        //[Key]
        public int ProductId { get; set; } // primary key
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1, 9999999)]
        public decimal Price { get; set; }
        [Column("InStock")]
        public bool IsAvailable { get; set; }
        public string Country { get; set; }
        public string Brand { get; set; }
        [NotMapped]
        public int Profit { get; set; }

        // Navigation property - to represent the relationship between entities
        // One-One relationship - one product belongs to one category
        public Category Category { get; set; }

        public List<Supplier> Suppliers { get; set; } = new();
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // One-Many relationship - one category can have many products
        public List<Product> Products { get; set; } = new List<Product>();
    }


    abstract public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }


    public class Supplier : Person
    {
        public string GST { get; set; }
        public int Rating { get; set; }

        public List<Product> Products { get; set; } = new();
    }

    public class Customer : Person
    {
        public int Discount { get; set; }
    }
}
