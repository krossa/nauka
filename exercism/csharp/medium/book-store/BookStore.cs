using System;
using System.Collections.Generic;

public static class BookStore
{
    private static Dictionary<int, int> discounts = new Dictionary<int, int>()
    {
        { 2, 5 },
        { 3, 10 },
        { 4, 20 },
        { 5, 25 }
    };
    public static double Total(IEnumerable<int> books)
    {
        
    }
}