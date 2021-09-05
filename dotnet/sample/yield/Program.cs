using System;
using System.Collections.Generic;
using System.Linq;

namespace yield
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetList(3).ToList();
            Console.WriteLine(result.Count);
        }

        private static IEnumerable<int> GetList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                yield return i;
            }
        }
    }
}
