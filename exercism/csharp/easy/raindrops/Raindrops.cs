using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    private static IReadOnlyDictionary<int, string> conditions = new Dictionary<int, string>
    {
        {3, "Pling"},
        {5, "Plang"},
        {7, "Plong"},
    };

    public static string Convert(int number)
    {
        var raindrops = conditions.Where(c => number % c.Key == 0).Select(c => c.Value);

        return raindrops.Any() ? string.Join("", raindrops) : number.ToString();
    }
}