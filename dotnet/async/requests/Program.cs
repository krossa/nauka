using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace requests
{
    public class Program
    {
        public static int Requests;
        public static void Main(string[] args)
        {
            new Thread(_ => {
                while(true) 
                {
                    ThreadPool.GetAvailableThreads(out var available, out var _);
                    ThreadPool.GetMaxThreads(out var maxThreads, out var _);
                    ThreadPool.GetMinThreads(out var minThreads, out var _);

                    Console.WriteLine($"Requests: {Volatile.Read(ref Requests)} Available: {available}, Active: {maxThreads - available}, Min: {minThreads}, Max: {maxThreads}");

                    Thread.Sleep(1000);
                }
            })
            {
                IsBackground = true,
            }.Start();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                ;
    }
}
