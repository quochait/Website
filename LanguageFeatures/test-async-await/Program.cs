using System;
using System.Threading.Tasks;

namespace test_async_await
{
    public class Program
    {
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

        static void Main(string[] args)
        {
            DoMainThread();
            Console.ReadLine();
        }
    }
}
