namespace Humanetics.Business.Math // SRP
{
    public class MaxFinder // Business Logic - SRP - Single Responsibility Principle
    {
        public static int FindMax(int a, int b) // SRP - Single Responsibility Principle
        {
            if (a > b)
                return a;
            else
                return b;
        }
    }
}
