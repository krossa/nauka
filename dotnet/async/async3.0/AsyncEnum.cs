using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AsyncEnum
{
    public async Task Run()
    {
        await NotAsync();
        await Async();
    }

    #region not async
    private async Task NotAsync()
    {
        foreach (var dataPoint in await FetchDataEnum())
        {
            Console.WriteLine(dataPoint);
        }
    }

    private async Task<IEnumerable<int>> FetchDataEnum()
    {
        List<int> dataPoints = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            dataPoints.Add(i);
        }

        return dataPoints;
    }
    #endregion

    #region async

    private async Task Async()
    {
        await foreach (var dataPoint in FetchDataAsync())
        {
            Console.WriteLine(dataPoint);
        }
    }

    private async IAsyncEnumerable<int> FetchDataAsync()
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            yield return i;
        }
    }

    #endregion
}