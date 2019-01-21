using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        try
        {
            return Compute(sequence);
        }
        catch (System.Collections.Generic.KeyNotFoundException)
        {
            throw new System.ArgumentException();
        }
    }

    private static IDictionary<char, int> InitializeDNA()
    {
        return new Dictionary<char, int>()
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 }
        };
    }
    private static IDictionary<char, int> Compute(string sequence)
    {
        var dna = InitializeDNA();
        foreach (var item in sequence)
            dna[item]++;
        return dna;
    }
}