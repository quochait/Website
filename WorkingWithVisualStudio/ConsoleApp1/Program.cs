using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoMainThread();
            string result = string.Join(", ", "Hello", 1, 2, 3.5); //Hello, 1, 2, 3.5
            Console.WriteLine(result);

            Console.ReadLine();
        }

        private static void DoMainThread()
        {
            DoSomeThing();
            Console.WriteLine("Print something");
        }

        private static async void DoSomeThing()
        {
            Console.WriteLine("Processing.....");
            await Task.Delay(3000);
            Console.WriteLine("Finished!");
        }
    }
}
