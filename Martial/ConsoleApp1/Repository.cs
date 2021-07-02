using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Repository
    {
        static readonly Random _random = new Random();
        public Repository()
        {
            RowCount = _random.Next(1, 10000000);
        }

        public int RowCount { get; }

        //public int RowCount { get; }
    }
}
