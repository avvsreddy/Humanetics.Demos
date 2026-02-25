namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Linq to Objects - Inmemory collections

            List<int> numbers = new List<int>() { 12, 2, 13, 44, 51, 64, 17, 18, 90, 10 };

            // Table : numbers
            // column : number
            // SQL Select : SELECT number FROM numbers WHERE number mod 2 = 0


            // Get all even numbers from the list into a new list and then display
            // Traditional way

            //List<int> evenNumbers = new List<int>();

            //foreach (int number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        evenNumbers.Add(number);
            //    }
            //}

            // LINQ to Objects - Query Syntax

            // SQL Select : SELECT number FROM numbers
            // WHERE number mod 2 = 0

            var evenNumbers = from number in numbers
                              where number % 2 == 0
                              //orderby number descending
                              select number;

            // using LINQ method syntax (Lambda Expressions / Arrow functions)
            var evenNumbers2 = numbers.Where(number => number % 2 == 0)
                .OrderByDescending(number => number);

            Console.WriteLine("Even numbers (traditional way):");
            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }

        }
    }
}
