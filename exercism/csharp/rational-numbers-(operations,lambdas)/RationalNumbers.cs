using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    //just so I don't need to type so many long words
    public int Num => Numerator;
    public int Den => Denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0) throw new ArgumentException("Denominator cannot be 0.");

        var gcd = GCD(numerator, denominator);
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var den = r2.Den == r1.Den ? r1.Den : r2.Den * r1.Den;
        return new RationalNumber(r1.Num * (den / r1.Den) + r2.Num * (den / r2.Den), den);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var den = r2.Den == r1.Den ? r1.Den : r2.Den * r1.Den;
        return new RationalNumber(r1.Num * (den / r1.Den) - r2.Num * (den / r2.Den), den);
    }
    
    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.Num * r2.Num, r1.Den * r2.Den);
    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.Num * r2.Den, r2.Num * r1.Den);

    public RationalNumber Abs() => new RationalNumber(Math.Abs(Num), Math.Abs(Den));

    public RationalNumber Reduce() => this; //reduction is performed in constructor

    public RationalNumber Exprational(int power) => new RationalNumber(Convert.ToInt32(Math.Pow(Num, Math.Abs(power))), Convert.ToInt32(Math.Pow(Den, Math.Abs(power))));

    public double ToDouble() => Num / Den;

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, Num / (double)Den);

    static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}