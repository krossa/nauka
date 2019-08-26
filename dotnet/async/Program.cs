using System;
using System.Threading;
using System.Threading.Tasks;

namespace async
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example1();
            // Example2();
            Example3();
            System.Console.ReadKey();

        }

        private static void Example1()
        {
            new MyApp().MyAsync();
            System.Console.Write("B");
            System.Console.ReadKey();
        }

        private static void Example2()
        {
            new MyApp().MyTaskAsync();
            System.Console.Write("X");
            System.Console.ReadKey();
        }

        private static async Task Example3Execute()
        {
            Console.WriteLine("pow samll");
            double d = await PowTwo(5);
            System.Console.WriteLine(d);
            Console.WriteLine("pow big");
            d = await PowTwo(10);
            System.Console.WriteLine(d);
        }

        private static async void Example3()
        {
            await Example3Execute();
            System.Console.ReadKey();

        }

        private static async ValueTask<double> PowTwo(double a)
        {
            if (a < 10 && a > -10) { return System.Math.Pow(a, 2); }
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return System.Math.Pow(a, 2);
            }
            );
        }
    }
}
