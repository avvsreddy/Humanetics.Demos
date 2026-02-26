using System.Diagnostics;

namespace DelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Frontend Developer 1
            //ProcessManager pMgr = new ProcessManager();
            //pMgr.ShowProcessList(delegate { return true; });

            // Frontend Developer 2
            ProcessManager pMgr = new ProcessManager();
            // Anonymous Delegates
            pMgr.ShowProcessList(delegate (Process process)
            {
                return process.ProcessName.StartsWith("S", StringComparison.OrdinalIgnoreCase);
            });

            // Lambda Statement 
            pMgr.ShowProcessList((Process process) =>
            {
                return process.ProcessName.StartsWith("S", StringComparison.OrdinalIgnoreCase);
            });

            // Lambda Expression - Light Weight Syntax for Anonymous Delegates
            pMgr.ShowProcessList((Process process) =>

                 process.ProcessName.StartsWith("S", StringComparison.OrdinalIgnoreCase)
            );

            pMgr.ShowProcessList(process => process.ProcessName.StartsWith("S", StringComparison.OrdinalIgnoreCase)
          );

            // Pass business logic as a parameter to another business logic - OCP - Open/Closed Principle

            // Frontend Developer 3
            //ProcessManager pMgr = new ProcessManager();
            //ProcessFilter filter = FilterByMemoryUsage; // OCP - Open/Closed Principle
            pMgr.ShowProcessList(p => p.WorkingSet64 > 1000 * 1024 * 1024); //50MB

        }
        // Fronted Dev 1
        //public static bool NoFilter(Process p) { return true; }


        // Frontend Developer 2
        //public static bool FilterByProcessName(System.Diagnostics.Process process)
        //{
        //    return process.ProcessName.StartsWith("S", StringComparison.OrdinalIgnoreCase);
        //}


        // Frontend Developer 3
        public static bool FilterByMemoryUsage(System.Diagnostics.Process process)
        {
            return process.WorkingSet64 > 1000 * 1024 * 1024; //50MB
        }
    }
    // Backend Developer

    public delegate bool ProcessFilter(System.Diagnostics.Process process); // OCP - Open/Closed Principle

    public class ProcessManager // OCP - Open/Closed Principle
    {
        public void ShowProcessList(ProcessFilter filter)
        {
            foreach (var process in System.Diagnostics.Process.GetProcesses())
            {
                if (filter(process))
                    Console.WriteLine($"Process Name: {process.ProcessName}, ID: {process.Id}");
            }
        }

        //public void ShowProcessList(long size)
        //{
        //    foreach (var process in System.Diagnostics.Process.GetProcesses())
        //    {
        //        if (process.WorkingSet64 > size)
        //            Console.WriteLine($"Process Name: {process.ProcessName}, ID: {process.Id}, Memory Usage: {process.WorkingSet64 / (1024 * 1024)} MB");
        //    }
        //}


    }
}
