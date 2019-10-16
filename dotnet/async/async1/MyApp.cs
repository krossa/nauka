using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using async;

class MyApp
{
    public async Task MyAsync()
    {
        Console.WriteLine($"PROCESS(2) id: {Thread.GetCurrentProcessorId()}");
        Console.WriteLine($"TAKS(2) id: {Thread.CurrentThread.ManagedThreadId}");
        System.Console.WriteLine("A");
        await System.Threading.Tasks.Task.Delay(2000);
        // foreach (var item in Enumerable.Range(0, 50)) Console.WriteLine("x");
        // await Task.Run(() =>
        // {
        //     Console.WriteLine($"TAKS(3) id: {Thread.GetCurrentProcessorId()}");
        //     foreach (var item in Enumerable.Range(0, Program.count)) Console.WriteLine("1");
        //     // Thread.Sleep(2000);
        // });
        System.Console.WriteLine("C");
        Console.WriteLine($"PROCESS(2) id: {Thread.GetCurrentProcessorId()}");
        Console.WriteLine($"TAKS(2) id: {Thread.CurrentThread.ManagedThreadId}");
    }

    public async void MyTaskAsync()
    {
        Console.WriteLine($"PROCESS(2) id: {Thread.GetCurrentProcessorId()}");
        Console.WriteLine($"TAKS(2) id: {Thread.CurrentThread.ManagedThreadId}");

        var task = MyTask();
        System.Console.WriteLine("Z");
        var result = await task;
        System.Console.Write(result);
    }

    public Task<string> MyTask()
    {
        return Task.Run<string>(() =>
        {
            Console.WriteLine($"PROCESS(3) id: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine($"TAKS(3) id: {Thread.CurrentThread.ManagedThreadId}");

            System.Console.WriteLine("TASK RUN");
            // Thread.Sleep(1000);
            // foreach (var item in Enumerable.Range(0, 10)) Console.WriteLine("P");
            System.Console.WriteLine("TASK END");
            return "Y";
        });
    }
}
