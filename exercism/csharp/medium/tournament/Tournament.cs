using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = GetTeams(inStream);
        WriteResult(outStream, teams.OrderByDescending(t => t.Points).ThenBy(t => t.Name).ToList());
    }

    private static IReadOnlyList<Team> GetTeams(Stream stream)
    {
        var result = new List<Team>();
        using var sr = new StreamReader(stream);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var data = line.Split(";");
            var team1 = GetOrAddTeam(result, data[0]);
            var team2 = GetOrAddTeam(result, data[1]);
            switch (data[2])
            {
                case "win":
                    team1.WinCount++;
                    team2.LossCount++;
                    break;
                case "loss":
                    team1.LossCount++;
                    team2.WinCount++;
                    break;
                case "draw":
                    team1.DrawCount++;
                    team2.DrawCount++;
                    break;
            }
        }
        return result;
    }

    private static void WriteResult(Stream stream, List<Team> teams)
    {
        using var sw = new StreamWriter(stream);
        sw.Write("Team                           | MP |  W |  D |  L |  P");
        for (int i = 0; i < teams.Count(); ++i)
        {
            sw.Write(Environment.NewLine);
            sw.Write(teams.ElementAt(i).ToString());
        }
        sw.Flush();
    }

    private static Team GetOrAddTeam(List<Team> teams, string name)
    {
        if (!teams.Any(t => t.Name.Equals(name)))
            teams.Add(new Team { Name = name });
        return teams.First(t => t.Name.Equals(name));
    }
}

public class Team
{
    public string Name { get; set; }
    public int WinCount { get; set; }
    public int LossCount { get; set; }
    public int DrawCount { get; set; }
    public int Points => WinCount * 3 + DrawCount;
    public int MatchPlayedCount => WinCount + LossCount + DrawCount;

    public override string ToString() =>
     $"{Name,-31}|{MatchPlayedCount,3} |{WinCount,3} |{DrawCount,3} |{LossCount,3} |{Points,3}";
}