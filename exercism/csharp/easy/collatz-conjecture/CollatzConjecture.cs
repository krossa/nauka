using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1) throw new ArgumentException();
        var steps = 0;
        while(number != 1)
        {
            number = number.IsEaven() ? (number / 2) : (3 * number + 1);
            steps++;
        }
        return steps;
    }

    public static bool IsEaven(this int number)
    {
        return number % 2 == 0;
    }
}