using System.Threading;
using System.Threading.Tasks;

class MyApp
{
    public async void MyAsync()
    {
        System.Console.Write("A");
        await System.Threading.Tasks.Task.Delay(2000);
        System.Console.Write("C");
    }

    public async void MyTaskAsync()
    {
        string result = await MyTask();
        System.Console.Write(result);
    }

    public Task<string> MyTask()
    {
        return Task.Run<string>(() =>
        {
            Thread.Sleep(2000);
            return "Y";
        });
    }
}
