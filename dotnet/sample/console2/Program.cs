using System;
using System.Collections.Generic;
using System.Linq;

public class MovingTotal
{
    List<int> numbers = new List<int>();
    HashSet<int> totals = new HashSet<int>();
    public void Append(int[] list)
    {
        foreach (var item in list)
        {
            numbers.Add(item);
            if (numbers.Count < 3) continue;



            // totals.Add(numbers.Skip(Math.Max(0, numbers.Count() - 3)).Sum());

            var sum = 0;
            for (int i = numbers.Count() - 3; i < numbers.Count; ++i)
            {
                sum += numbers.ElementAt(i);
            }

            totals.Add(sum);
        }


        // numbers.AddRange(list);
        // if (numbers.Count < 3) return;

        // totals.Add(numbers.Skip(Math.Max(0, numbers.Count() - 3)).Sum());
    }

    public bool Contains(int total)
    {
        return totals.Contains(total);
    }

    public static void Main(string[] args)
    {
        MovingTotal movingTotal = new MovingTotal();

        movingTotal.Append(new int[] { 1, 2, 3 });

        Console.WriteLine(movingTotal.Contains(6));
        Console.WriteLine(movingTotal.Contains(9));

        movingTotal.Append(new int[] { 4, 1 });

        Console.WriteLine(movingTotal.Contains(9));
        // Console.WriteLine("Hello");
    }
}