namespace ExceptionsDemo
{
    public class ZeroOrNegativeInputException : ApplicationException
    {
        public ZeroOrNegativeInputException()
        {

        }

        public ZeroOrNegativeInputException(string message) : base(message)
        {

        }


    }
}
