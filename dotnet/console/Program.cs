using System;

public class MathUtils
{
    public static double Average(int a, int b)
    {
        return Convert.ToDouble(a + b) / 2;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine(Average(2, 1));
    }
}