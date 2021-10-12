using System;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileCopier = new FileCopier(
                "C:/Users/nicol/OneDrive/Рабочий стол/Рабочий стол/5 СЕМЕСТР/СПП/2лр/test", 
                "C:/Users/nicol/OneDrive/Рабочий стол/Рабочий стол/5 СЕМЕСТР/СПП/2лр/dest");
            
            fileCopier.CopyFiles();
            Console.WriteLine("Всего файлов скопировано: " + FileCopier.Counter);
        }
    }
}