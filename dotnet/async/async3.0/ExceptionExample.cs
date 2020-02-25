using System;
using System.Threading.Tasks;

public class ExceptionExample
{
    public async Task Run()
    {
        try
        {
            await ExceptionOne();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception ONE catch block");
            Console.WriteLine(e.Message);
        }

        try
        {
            ExceptionTwo();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception ONE catch block");
            Console.WriteLine(e.Message);
        }

        ExceptionTwo();
    }

    private async Task ExceptionOne()
    {
        await Task.Delay(1);
        throw new Exception("exception ONE");
    }

    private async Task ExceptionTwo()
    {
        await Task.Delay(1);
        throw new Exception("exception TWO");
    }
}