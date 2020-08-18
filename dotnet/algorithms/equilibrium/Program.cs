using System;

namespace equilibrium
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] {-7, 1, 5, 2, -4, 3, 0};

            Console.WriteLine(new BruteForce().Run(data));
            Console.WriteLine(new Incremental().Run(data));
        }
    }
}
