using System;
using System.Collections.Generic;

namespace interface_test.set_test
{
    public class SetTest
    {
        private SortedSet<int> sortedSet;
        private HashSet<int> hashSet;
        public SetTest(params int[] values)
        {
            sortedSet = new SortedSet<int>();
            hashSet = new HashSet<int>();

            foreach (var item in values)
            {
                sortedSet.Add(item);
                hashSet.Add(item);
            }
        }

        public void Print()
        {
            Console.WriteLine("SORTED SET");
            foreach (var item in sortedSet)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("");
            Console.WriteLine("HASH SET");
            foreach (var item in hashSet)
            {
                Console.Write($"{item} ");
            }
        }
    }
}