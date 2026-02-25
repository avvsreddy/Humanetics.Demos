using System.Xml.Linq;

namespace LinqToObjectsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var book1 = new { Author = "Author1", Title = "Title1" };
            //List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ////var evenNumbers = numbers.Where(n => n % 2 == 0);
            //var evenNumbers = (from n in numbers
            //                   where n % 2 == 0
            //                   select n).ToList();

            //numbers.Add(10);

            //foreach (var num in evenNumbers)
            //{
            //    Console.WriteLine(num);
            //}

            //List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };
            // get short names
            //var shortNames = names.Where(name => name.Length <= 3).ToList();

            // Load XML document
            //XDocument doc = XDocument.Load("XMLFile1.xml");
            XDocument doc = XDocument.Load("XMLFile2.xml");
            // Linq to XML query to get short names
            //var shortNames = (from name in doc.Descendants("name")
            //                  where name.Value.Length <= 3
            //                  select name.Value).ToList();


            //var authors = (from author in doc.Descendants("author")
            //               select author.Value).ToList();

            //foreach (var name in authors)
            //{
            //    Console.WriteLine(name);
            //}

            // Get all book titles belonging to the "Computer" genre
            var computerBooks = (from book in doc.Descendants("book")
                                 where book.Element("genre")?.Value == "Computer"
                                 select new { Author = book.Element("author").Value, Title = book.Element("title")?.Value })
                                 .ToList();

            // display the computer book titles
            foreach (var book in computerBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }
    }

    //class BookTitleAuthor
    //{
    //    public string Author { get; set; }
    //    public string Title { get; set; }

    //}
}