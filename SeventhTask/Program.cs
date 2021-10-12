using System;
using System.Threading;

namespace SeventhTask
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Parallel.WaitAll(new ParallelDelegate[] { Sleep3, Sleep5, Sleep7 });
            Console.WriteLine("Program: finished.");
        }
        
        private static void Sleep3()
        {
            Console.WriteLine("Sleep3: started.");
            Thread.Sleep(3000);
            Console.WriteLine("Sleep3: finished.");
        }

        private static void Sleep5()
        {
            Console.WriteLine("Sleep5: started.");
            Thread.Sleep(5000);
            Console.WriteLine("Sleep5: finished.");
        }
        private static void Sleep7()
        {
            Console.WriteLine("Sleep7: started.");
            Thread.Sleep(7000);
            Console.WriteLine("Sleep7: finished.");
        }
    }
}