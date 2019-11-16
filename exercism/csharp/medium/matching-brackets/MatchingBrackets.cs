using System.Linq;
using System;
using System.Collections.Generic;

public static class MatchingBrackets
{
    static IReadOnlyDictionary<char, char> brackets = new Dictionary<char, char>()
    {
        {'[',']'},
        {'{','}'},
        {'(',')'}
    };

    public static bool IsPaired(string input)
    {
        var readBrackets = new Stack<char>();
        foreach (var item in input)
        {
            if (IsOpening(item))
            {
                if (readBrackets.Count == 0 ||
                    IsOpening(readBrackets.Peek()))
                    readBrackets.Push(item);
            }
            if (IsClosing(item))
            {
                if (readBrackets.Count == 0 ||
                    !AreMatching(readBrackets.Peek(), item))
                    return false;

                readBrackets.Pop();
            }
        }
        return readBrackets.Count == 0;
    }

    private static bool IsOpening(char item) => brackets.Keys.Contains(item);
    private static bool IsClosing(char item) => brackets.Values.Contains(item);
    private static bool AreMatching(char opening, char closing) => brackets[opening] == closing;
}
