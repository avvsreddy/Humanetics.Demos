namespace Humanetics.SimpleCalculator
{
    public class Calculator
    {

        public int Sum(int a, int b)
        {
            // Business Rules
            // 1. both inputs must be +ve integers
            if (a < 0 && b < 0)
            {
                throw new ArgumentException("Both inputs must be positive integers.");
            }
            // 2. if any of the input is -ve, throw an exception
            // 3. both inputs must be non-zero integers else throw an exception
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Both inputs must be non-zero integers.");
            }
            // 4. both input must be even numbers else throw an exception
            if (a % 2 != 0 && b % 2 != 0)
            {
                throw new ArgumentException("Both inputs must be even numbers.");
            }


            return a + b;
        }



    }
}
