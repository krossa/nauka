using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var left = 0;
        var right = input.Length - 1;
        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (input[middle] < value)
            {
                left = middle + 1;
                continue;
            }
            if (input[middle] > value)
            {
                right = middle - 1;
                continue;
            }
            return middle;
        }
        return -1;
    }
}