using System;
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        return new String(input.ToCharArray().Reverse().ToArray());
    }
}