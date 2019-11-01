using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static IDictionary<char, char> mapping = new Dictionary<char, char>()
    {
        { 'G', 'C' },
        { 'C', 'G' },
        { 'T', 'A' },
        { 'A', 'U' }
    };
    public static string ToRna(string nucleotide)
    {
        var rna =  nucleotide.Select( c => mapping[c]);
        return new string(rna.ToArray());
    }
}