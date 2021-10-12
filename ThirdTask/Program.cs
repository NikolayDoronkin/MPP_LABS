using System;
using System.Threading;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            var mutex = new Mutex();
            for (var i = 0; i < n; i++)
            {
                new Thread(() =>
                    {
                        mutex.Lock();
                        Console.WriteLine("current Thread id: " + Thread.CurrentThread.ManagedThreadId + " lock Thread");
                        Thread.Sleep(400);
                        Console.WriteLine("current Thread id: " + Thread.CurrentThread.ManagedThreadId + " unlock Thread");
                        mutex.Unlock();
                    }
                ).Start();
            }
        }
    }
}