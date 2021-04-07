using System;

public enum Side { None, Left, Right }

public class ChainLink
{
    public ChainLink Left { get; private set; }
    public ChainLink Right { get; private set; }

    public void Append(ChainLink rightPart)
    {
        if (this.Right != null)
            throw new InvalidOperationException("Link is already connected.");

        this.Right = rightPart;
        rightPart.Left = this;
    }

    public Side LongerSide( )   {
        var nextLeft = Left;
        var nextRight = Right;

        while (!(nextLeft is null) && !(nextRight is null))
        {
            if (nextLeft == this || nextRight == this) return Side.None;
            nextLeft = nextLeft.Left;
            nextRight = nextRight.Right;
        }

        if (nextRight is null && nextLeft is null) return Side.None;
        return (nextRight is null) ? Side.Left : Side.Right;
    }

    public static void Main(string[] args)
    {
        ChainLink left = new ChainLink();
        ChainLink middle = new ChainLink();
        ChainLink right = new ChainLink();
        left.Append(middle);
        middle.Append(right);
        Console.WriteLine(left.LongerSide());
    }
}