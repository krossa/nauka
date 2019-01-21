using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) =>
        Enumerable.Range(1, max).Sum().Square();

    public static int CalculateSumOfSquares(int max) =>
        Enumerable.Range(1, max).Sum(Square);

    public static int CalculateDifferenceOfSquares(int max) =>
        CalculateSquareOfSum(max) - CalculateSumOfSquares(max);

    static int Square(this int value) => value * value;
}