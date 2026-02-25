using Humanetics.Business.Math; // DRY - Don't Repeat Yourself
namespace Humanetics.FirstConsoleApp
{
    internal class Program // UI Logic - SRP - Single Responsibility Principle
    {
        static void Main(string[] args) // SRP - Single Responsibility Principle
                                        // SOLID - OOP Principles
        {
            // Accept 2 numbers from the user and display the max of those numbers.
            int fno;
            int sno;
            int max;

            Console.WriteLine("Enter the first number:");
            fno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            sno = int.Parse(Console.ReadLine());

            // find the max of the two numbers
            max = MaxFinder.FindMax(fno, sno); // DRY - Don't Repeat Yourself

            //Console.WriteLine("The maximum of the two numbers is: " + max);
            Console.WriteLine($"The maximum of {fno} and {sno} is {max}");

        }



    }


}
