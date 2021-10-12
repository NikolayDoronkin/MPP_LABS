using System;
using System.Threading;

namespace FirstTask
{
    public delegate void Method();
    
    class Program
    {
        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(5);

            Method one = sayHello;
            Method two = sayGoodbye;
            Method three = say1;
            Method four = say2;
            Method five = say3;
            Method six = say4;
            
            taskQueue.EnqueueTask(one);
            taskQueue.EnqueueTask(two);
            taskQueue.EnqueueTask(three);
            taskQueue.EnqueueTask(four);
            taskQueue.EnqueueTask(five);
            taskQueue.EnqueueTask(six);
            taskQueue.EnqueueTask(six);
            taskQueue.EnqueueTask(six);
            taskQueue.EnqueueTask(six);
            taskQueue.EnqueueTask(six);
            
            taskQueue.DequeueTask();
            taskQueue.DequeueTask();
            taskQueue.DequeueTask();
            taskQueue.DequeueTask();
            taskQueue.DequeueTask();
            taskQueue.DequeueTask();
            taskQueue.DequeueTask();
        }

        static void sayHello()
        {
            Console.WriteLine("Hello world!" + Thread.CurrentThread.Name);
        }
        static void sayGoodbye()
        {
            Console.WriteLine("Goodbye world!" + Thread.CurrentThread.Name);
        }
        static void say1()
        {
            Console.WriteLine("1!" + Thread.CurrentThread.Name);
        }
        static void say2()
        {
            Console.WriteLine("2!" + Thread.CurrentThread.Name);
        }
        static void say3()
        {
            Console.WriteLine("3!" + Thread.CurrentThread.Name);
        }
        static void say4()
        {
            Console.WriteLine("4!" + Thread.CurrentThread.Name);
        }
    }
}