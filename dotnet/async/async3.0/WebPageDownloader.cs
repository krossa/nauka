using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;

public class WebPageDownloader
{
    private readonly string[] urls = new[]
            {
        "https://github.com/naudio/NAudio",
        "https://twitter.com/mark_heath",
        "https://github.com/markheath/azure-functions-links",
        "https://pluralsight.com/authors/mark-heath",
        // "https://github.com/markheath/advent-of-code-js",
        // "http://stackoverflow.com/users/7532/mark-heath",
        // "https://mvp.microsoft.com/en-us/mvp/Mark%20%20Heath-5002551",
        // "https://github.com/markheath/func-todo-backend",
        // "https://github.com/markheath/typescript-tetris",
        // "https://github.com/naudio/NAudio",
        // "https://twitter.com/mark_heath",
        // "https://github.com/markheath/azure-functions-links",
        "https://pluralsight.com/authors/mark-heath",
        "https://github.com/markheath/advent-of-code-js",
        "http://stackoverflow.com/users/7532/mark-heath",
        "https://mvp.microsoft.com/en-us/mvp/Mark%20%20Heath-5002551",
        "https://github.com/markheath/func-todo-backend",
        "https://github.com/markheath/typescript-tetris"
        };

    public async Task GetSequentailAsync()
    {
        var client = new HttpClient();
        foreach (var url in urls)
        {
            var html = await client.GetStringAsync(url);
            Console.WriteLine($"retrieved {html.Length} characters from {url}");
        }
    }

    public async Task GetConcurrentQueueAsync()
    {
        var maxThreads = 4;
        var colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue };
        var q = new ConcurrentQueue<string>(urls);
        var tasks = new List<Task>();
        for (int n = 0; n < maxThreads; n++)
        {
            var color = colors[n];
            tasks.Add(Task.Run(async () =>
            {
                while (q.TryDequeue(out string url))
                {
                    var client = new HttpClient();
                    var html = await client.GetStringAsync(url);
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} retrieved {html.Length} characters from {url}");
                }
            }));
        }
        async3.Program.PrintInfo("MAIN");
        await Task.WhenAll(tasks);
        async3.Program.PrintInfo("MAIN");
    }

    public async Task SemaphoreSlim()
    {
        var allTasks = new List<Task>();
        var throttler = new SemaphoreSlim(initialCount: 4);
        foreach (var url in urls)
        {
            await throttler.WaitAsync();
            allTasks.Add(
                Task.Run(async () =>
                {
                    var html = string.Empty;
                    try
                    {
                        var client = new HttpClient();
                        html = await client.GetStringAsync(url);
                    }
                    finally
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{throttler.Release()} retrieved {html.Length} characters from {url}");

                    }
                }));
        }
        await Task.WhenAll(allTasks);
    }

    public void ParallelForEach()
    {
        var options = new ParallelOptions() { MaxDegreeOfParallelism = 4 };
        Parallel.ForEach(urls, options, url =>
            {
                var client = new HttpClient();
                var html = client.GetStringAsync(url).Result; // use only with synchronues methods. '.Result' is antypattern
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} retrieved {html.Length} characters from {url}");
            });
    }

    //https://github.com/App-vNext/Polly
    public async Task PollyBulkheadAsync()
    {
        var bulkhead = Policy.BulkheadAsync(4, Int32.MaxValue);
        var tasks = new List<Task>();
        foreach (var url in urls)
        {
            var t = bulkhead.ExecuteAsync(async () =>
            {
                var client = new HttpClient();
                var html = await client.GetStringAsync(url);
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} retrieved {html.Length} characters from {url}");
            });
            tasks.Add(t);
        }
        await Task.WhenAll(tasks);
    }
}