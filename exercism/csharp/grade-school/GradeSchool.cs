using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    public GradeSchool()
    {
        _roster = new Dictionary<int, SortedSet<string>>();
    }

    public Dictionary<int, SortedSet<string>> _roster { get; private set; }

    public void Add(string name, int grade)
    {
        InitializeGrade(grade);
        _roster[grade].Add(name);
    }

    public SortedSet<string> Grade(int grade)
    {
        if (_roster.ContainsKey(grade)) return _roster[grade];
        return new SortedSet<string>();
    }

    public IEnumerable<String> Roster()
    {
        foreach (var grade in _roster.OrderBy(r => r.Key))
        {
            foreach (var name in grade.Value)
            {
                yield return name;
            }
        }
    }
    private void InitializeGrade(int grade)
    {
        if (_roster.ContainsKey(grade)) return;
        _roster.Add(grade, new SortedSet<string>());
    }
}