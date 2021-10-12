using System;

namespace SixthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var logBuffer = new LogBuffer("C:/Users/nicol/OneDrive/Рабочий стол/test.txt");
            for (var index = 1; index <= 100; index++)
            {
                logBuffer.Add(index.ToString());
            }
            Console.WriteLine("Press the Enter key to exit anytime... ");
            Console.ReadLine();
            logBuffer.Close();
        }
    }
}