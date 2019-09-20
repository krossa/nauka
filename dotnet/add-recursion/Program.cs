using System;
using System.Collections.Generic;
using System.Linq;

namespace add_recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var values = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(add(values, 0));
        }

        static int add(IEnumerable<int> values, int total)
        {
            if (!values.Any()) return total;
            return add(values.Skip(1), total + values.First());
        }
    }
}
