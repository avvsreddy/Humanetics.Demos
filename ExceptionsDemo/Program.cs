namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept user input and display the result of sum of two numbers


            while (true)
            {
                try
                {
                    Console.WriteLine("Enter first number:");
                    int fno = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter second number:");
                    int sno = Convert.ToInt32(Console.ReadLine());


                    // Business rule : accept only positive non-zero numbers
                    if (fno <= 0 || sno <= 0)
                    {
                        throw new ZeroOrNegativeInputException("Input must be positive and non-zero."); // Throwing a custom exception when the input is zero or negative
                    }


                    int sum = fno + sno;
                    Console.WriteLine("The sum of the two numbers is: " + sum);

                }
                catch (FormatException ex) // Catching format exceptions that may occur when converting user input to integers
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer. " + ex.Message);
                }
                catch (OverflowException ex) // Catching overflow exceptions that may occur when the input number is too large or too small for an integer
                {
                    Console.WriteLine("The number entered is too large or too small. Please enter a valid integer. " + ex.Message);
                }
                catch (Exception ex) // Catching any exception that may occur during the execution of the code
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("This block will always execute, regardless of whether an exception was thrown or not.");
                    // This is a good place to perform any cleanup operations, such as closing files or releasing resources.

                }
            }
        }
    }
}
