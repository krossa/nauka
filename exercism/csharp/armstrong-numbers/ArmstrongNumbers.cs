using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = number.ToString().ToCharArray();
        return number == digits.Sum(d => Math.Pow(Int16.Parse(d.ToString()), digits.Length));
    }
}