using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace async
{
    class Program
    {
        public static int count = 50;
        static void Main(string[] args)
        {
            // Example1();
            // Example2();
            Example3();
            System.Console.ReadKey();

        }

        private static async void Example1()
        {
            Console.WriteLine($"PROCESS(1) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");

            new MyApp().MyAsync();
            // foreach (var item in Enumerable.Range(0, count)) Console.WriteLine("0");
            Thread.Sleep(1000);
            System.Console.WriteLine("B");
            Console.WriteLine($"PROCESS(1) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");

            System.Console.ReadKey();
        }

        private static async Task Example2()
        {
            Console.WriteLine($"PROCESS(1) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");

            new MyApp().MyTaskAsync();
            Console.WriteLine($"PROCESS(1) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");

            // foreach (var item in Enumerable.Range(0, 10)) Console.WriteLine(item);
            System.Console.WriteLine("X");
            System.Console.ReadKey();
        }

        private static async Task Example3Execute()
        {
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("pow samll");
            double d = await PowTwo(5);
            System.Console.WriteLine(d);
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("pow big");
            d = await PowTwo(10);
            System.Console.WriteLine(d);
            Console.WriteLine($"TAKS(1) id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async void Example3()
        {
            Console.WriteLine($"TAKS(0) id: {Thread.CurrentThread.ManagedThreadId}");
            await Example3Execute();
            System.Console.ReadKey();

        }

        private static async ValueTask<double> PowTwo(double a)
        {
            Console.WriteLine($"TAKS(2) id: {Thread.CurrentThread.ManagedThreadId}");
            if (a < 10 && a > -10) { return System.Math.Pow(a, 2); }
            Console.WriteLine($"TAKS(2) id: {Thread.CurrentThread.ManagedThreadId}");
            return await Task.Run(() =>
            {
                Console.WriteLine($"TAKS(2) id: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                return System.Math.Pow(a, 2);
            }
            );
        }
    }
}
