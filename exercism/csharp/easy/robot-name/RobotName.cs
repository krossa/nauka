using System.Collections.Generic;
using System;

public class Robot
{
    private static HashSet<string> names = new HashSet<string>();

    string name;
    public string Name => name ??= GetName();
    
    public void Reset()
    {
        names.Remove(name);
        name = GetName();
    }

    private  string GetName()
    {
        string name;
        do
        {
             name = $"{GetLetters()}{GetNumber()}";
        } while (!names.Add(name));
        return name;
    }

    private string GetLetters()
    {
        var rnd = new Random();
        var char1 = (char)rnd.Next('A', 'Z');
        var char2 = (char)rnd.Next('A', 'Z');
        return $"{char1}{char2}";
    }

    private string GetNumber() => $"{new Random().Next(0, 999):D3}";
}