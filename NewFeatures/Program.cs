namespace NewFeatures
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // Consumer / Client
            //Product p = new Product(); // Instatiated
            //// Initialize
            //p.ProductId = 1;
            //p.ProductName = "Laptop";
            //p.Price = 90000;



            // Object Initialization Syntax

            // Anonymous Types

            var p2 = new { ProductId = 2, ProductName = "IPhone", Price = 99999 };

            var p3 = new { ProductId = 3 };

            var p4 = new { ProductId = 5, Price = 1000 };

            // Extension Methods

            string str = "Some confidential data";
            // to upper
            str.ToUpper();
            str.ToLower();
            // Encrypt

            //Enumerable
            str = MyUtils.Encrypt(str);

            List<int> num = new List<int> { 1, 2, 3, 4, 5 };

            var evens = num.Where(x => x % 2 == 0);

            var otherWay = from n in num
                           where n % 2 == 0
                           select n;

            int a = 10;

        }
    }

    public static class MyUtils
    {
        public static string Encrypt(this object str)
        {
            return "@#$@#$FSDFER@#$DFSDF@#$@#RWDFW#%@#$%";
        }
    }


    // Author
    //public class Product
    //{
    //    // Class Members
    //    // State - data
    //    //int productId; // Fields
    //    //string name; // Fields

    //    //string backingfield234234234234;
    //    double price; // Fields

    //    // Behaviours - methods

    //    public int ProductId { get; set; }

    //    public string ProductName // Automatic Property
    //    {
    //        get; // { return this.name; } // reads
    //        set; // { this.name = value; } // writes
    //    }

    //    public double Price
    //    {
    //        get { return (double)this.price; }
    //        set
    //        {
    //            if (value <= 0)
    //            {
    //                this.price = 1;
    //            }
    //            else
    //            {
    //                this.price = value;
    //            }
    //        }
    //    }

    //    public double CalculateTax()
    //    {
    //        return price * 0.10;
    //    }

    //    //public Product()
    //    //{

    //    //}
    //    //public Product(int id, string name, double price) : this(id,price)
    //    //{
    //    //    //this.ProductId = id;
    //    //    this.ProductName = name;
    //    //    //this.price = price;
    //    //}

    //    //public Product(int id)
    //    //{
    //    //    this.ProductId = id;
    //    //}
    //    //public Product(int id, double price) : this(id)
    //    //{
    //    //    //this.ProductId = id; 
    //    //    this.Price = price;
    //    //}
    //}

    class Employee // Entity Classess - Map to some table
    {
        // empid
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public DateTime Dob { get; set; }
        // name
        // salary
        // dob


    }
}
