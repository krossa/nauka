﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace async3._0
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // ScenerioOne();
            ScenerioTwo();
            Console.ReadKey();
        }

        #region SCENERIO ONE

        private static async Task ScenerioOne()
        {
            PrintInfo("1");
            await OneAsync();
            PrintInfo("2");
            TwoAsync();
            PrintInfo("3");
            Thread.Sleep(1);
            Loop("MAIN",ConsoleColor.Yellow);
        }

        private static async Task OneAsync()
        {
            PrintInfo("ONE 1");
            await System.Threading.Tasks.Task.Delay(1);
            PrintInfo("ONE 2");
            // Loop("ONE");
        }

        private static async Task TwoAsync()
        {
            PrintInfo("TWO 1");
            await System.Threading.Tasks.Task.Delay(1);
            PrintInfo("TWO 2");
            Loop("ONE",ConsoleColor.Red);
        }

        #endregion

        #region SCENERIO TWO

        private static async Task ScenerioTwo()
        {
            PrintInfo("1");
            var result = ReturnAsync();
            // Console.WriteLine(result.Result);
            PrintInfo("2");
            Loop("MAIN",ConsoleColor.Red);
            await result;
            PrintInfo("3");
            Console.WriteLine(result.Result);
        }

        private static async Task<string> ReturnAsync()
        {
            PrintInfo("RET 1");
            await Task.Delay(1);
            PrintInfo("RET 2");
            Loop("ASYNC",ConsoleColor.Yellow);
            return "ASYNC RESULT";
        }

        #endregion

        private static void PrintInfo(string id)
        {
            // Console.WriteLine($"PROCESS({id}) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"THREAD({id}) id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Loop(string phrase, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (var item in Enumerable.Range(0, 5))
            {
                var rand = new Random(DateTime.Now.Millisecond);
                Thread.Sleep(rand.Next(1, 10));
                Console.WriteLine(phrase);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
