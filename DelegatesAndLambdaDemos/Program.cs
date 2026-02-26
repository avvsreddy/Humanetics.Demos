namespace DelegatesAndLambdaDemos
{

    //public class MyDelete : MulticasteDelegate
    //{

    //}

    // The above code will not compile because the Delegate class is sealed and cannot be inherited.

    // Step 1: Delegate Declaration
    public delegate void MyDelete(string msg);


    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMessage("Hello, World! calling directly"); // Direct method call

            //Delegate delObj = new Delegate();
            // Step 2: Instantiate and Initialize the delegate
            MyDelete delObj = new MyDelete(PrintMessage2);
            delObj += PrintMessage; // Subscription Multicasting: Adding another method to the delegate invocation list
            // Unsubscribe from the delegate
            delObj -= PrintMessage2; // Unsubscription: Removing a method from the delegate invocation list
            // Step 3: Invoke the delegate
            delObj.Invoke("Hello calling from delegate!");
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine("Message from PrintMessage" + message);
        }

        static void PrintMessage2(string message)
        {
            Console.WriteLine("Message from PrintMessage2: " + message);
        }
    }
}
