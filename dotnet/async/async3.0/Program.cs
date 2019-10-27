using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace async3
{
    class Program
    {
        private static readonly object lockObj = new object();

        async static Task Main(string[] args)
        {
            // await ScenerioOne();
            // await ScenerioTwo();
            // await new WebPageDownloader().GetSequentailAsync();
            // await new WebPageDownloader().GetConcurrentQueueAsync();
            // await new WebPageDownloader().SemaphoreSlim();
            // await new WebPageDownloader().ParallelForEach();
            await new WebPageDownloader().PollyBulkheadAsync();
            // Console.ReadKey();
        }

        #region SCENERIO ONE

        private static async Task ScenerioOne()
        {
            PrintInfo("1");
            await OneAsync().ConfigureAwait(true);
            Loop("MAIN", ConsoleColor.Green);
            PrintInfo("2");
            TwoAsync();
            PrintInfo("3");
            Thread.Sleep(1);
            Loop("MAIN", ConsoleColor.Yellow);
        }

        private static async Task OneAsync()
        {
            PrintInfo("ONE 1");
            await System.Threading.Tasks.Task.Delay(1);
            PrintInfo("ONE 2");
            Loop("ONE", ConsoleColor.Blue);
        }

        private static async Task TwoAsync()
        {
            PrintInfo("TWO 1");
            await System.Threading.Tasks.Task.Delay(1);
            PrintInfo("TWO 2");
            Loop("TWO", ConsoleColor.Red);
        }

        #endregion

        #region SCENERIO TWO

        private static async Task ScenerioTwo()
        {
            PrintInfo("1");
            var result = ReturnAsync();
            // Console.WriteLine(result.Result);
            PrintInfo("2");
            Loop("MAIN", ConsoleColor.Red);
            await result;
            PrintInfo("3");
            Console.WriteLine(result.Result);
        }

        private static async Task<string> ReturnAsync()
        {
            PrintInfo("RET 1");
            await Task.Delay(1);
            PrintInfo("RET 2");
            Loop("ASYNC", ConsoleColor.Yellow);
            return "ASYNC RESULT";
        }

        #endregion

        #region SCENERIO THREE

        #endregion

        public static void PrintInfo(string id)
        {
            // Console.WriteLine($"PROCESS({id}) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"THREAD({id}) id: {Thread.CurrentThread.ManagedThreadId}");
            // Console.WriteLine($"CONTEXT({id}) id: {SynchronizationContext.Current}");
        }

        public static void Loop(string phrase, ConsoleColor color = ConsoleColor.White)
        {
            foreach (var item in Enumerable.Range(0, 5))
            {
                var rand = new Random(DateTime.Now.Millisecond);
                Thread.Sleep(rand.Next(1, 10));
                lock (lockObj)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(phrase);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
