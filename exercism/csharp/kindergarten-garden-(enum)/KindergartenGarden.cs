using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public enum Student
{
    Alice = 0, Bob = 2, Charlie = 4, David = 6,
    Eve = 8, Fred = 10, Ginny = 12, Harriet = 14,
    Ileana = 16, Joseph = 18, Kincaid = 20, Larry = 22
}

public class KindergartenGarden
{
    private string[] rows = new string[2];
    private IDictionary<char, Plant> plants = new Dictionary<char, Plant>()
    {
        { 'V', Plant.Violets },
        { 'R', Plant.Radishes },
        { 'C', Plant.Clover },
        { 'G', Plant.Grass }
    };

    public KindergartenGarden(string diagram)
    {
        rows = diagram.Split(Environment.NewLine);
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var index = (int)(Student)Enum.Parse(typeof(Student), student);
        return (from row in rows
                from i in Enumerable.Range(index, 2)
                select plants[row[i]]);

    }
}