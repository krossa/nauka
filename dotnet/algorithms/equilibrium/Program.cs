using System;

namespace equilibrium
{
    class Program
    {
        // Write a program to find the equilibrium index of an array. Equilibrium index of an array is an index such that sum of elements at lower indexes = sum of elements at higher indexes.
        static void Main(string[] args)
        {
            var data = new int[] {-7, 1, 5, 2, -4, 3, 0};

            Console.WriteLine(new BruteForce().Run(data));
            Console.WriteLine(new Incremental().Run(data));
        }
    }
}
