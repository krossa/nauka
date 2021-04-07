using System;

namespace hacker_help
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            var val = number%2 switch
            {
                1 => 1,
                0 => 2,
            };
            Console.WriteLine(val);
        }
    }
}
