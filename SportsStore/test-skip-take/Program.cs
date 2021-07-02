using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace test_skip_take
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string>()
            {
                 "1",
                 "2",
                 "3",
                 "4"
            };

            var i = test.Skip(2);

            Console.ReadLine();
        }
    }
}
