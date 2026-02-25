using System.Collections.Concurrent;

namespace ArraysAndCollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // two types of collections in .net
            // 1. Static collections (arrays)

            int a; // scallar variable

            int[] b = new int[4];
            b[0] = 1;
            b[1] = 2;
            b[2] = 3;
            b[3] = 4;
            // b[4] = 5; // this will throw an exception because the array has a fixed size of 4

            // Read

            int x = b[0]; // 1

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }

            foreach (int item in b)
            {
                Console.WriteLine(item);
            }

            int sum = b.Sum();
            int max = b.Max();
            int min = b.Min();
            double avg = b.Average();
            // sort
            Array.Sort(b); // ascending order
            Array.Reverse(b); // descending order


            // multi-dimensional arrays
            int[,] matrix = new int[3, 3];
            // write to the matrix
            matrix[0, 0] = 1;
            // read from the matrix
            int y = matrix[0, 0]; // 1


            // declare and initialize an array
            int[] c1 = new int[5] { 1, 2, 3, 4, 5 };
            int[] c2 = new int[] { 1, 2, 3, 4, 5 };
            int[] c3 = { 1, 2, 3, 4, 5 };

            // 2. Dynamic collections (lists, dictionaries, queues, stacks, etc.)
            // List<T> is a dynamic collection that can grow and shrink in size
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // read from the list
            int z = list[0]; // 1
            // Stack<T> is a dynamic collection that follows the Last In First Out (LIFO) principle
            Stack<string> stack = new Stack<string>();
            stack.Push("Hello"); // add an item to the top of the stack
            stack.Push("World");

            // read from the stack
            string top = stack.Peek(); //  only read
            string popped = stack.Pop(); // read and remove

            // Queue<T> is a dynamic collection that follows the First In First Out (FIFO) principle
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Hello"); // add an item to the end of the queue
            queue.Enqueue("World");

            // read from the queue
            string front = queue.Peek(); //  only read
            string dequeued = queue.Dequeue(); // read and remove

            // HashSet<T> is a dynamic collection that stores unique elements and provides fast lookup
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(1); // duplicate, will not be added
            // read from the set
            foreach (int item in set)
            {
                Console.WriteLine(item);
            }

            // Dictionary<TKey, TValue> is a dynamic collection that stores key-value pairs and provides fast lookup by key
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "One");
            dictionary.Add(2, "Two");
            dictionary.Add(3, "Three");

            // read from the dictionary
            string value = dictionary[1]; // "One"


            // Thread Safe Collections
            // ConcurrentQueue<T> is a thread-safe collection that follows the First In First Out (FIFO) principle
            ConcurrentQueue<string> concurrentQueue = new ConcurrentQueue<string>();
            concurrentQueue.Enqueue("Hello");
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>();
        }
    }
}
