using System;
using System.Collections.Generic;

[Flags]
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private Allergen allergen { get; }

    public Allergies(int mask)
    {
        allergen = (Allergen)mask;
    }

    public bool IsAllergicTo(Allergen value)
    {
        return ((allergen & value) == value);
    }

    public Allergen[] List()
    {
        if (allergen == 0)
            return new Allergen[] { };

        var list = new List<Allergen>();

        foreach (Allergen item in Enum.GetValues(typeof(Allergen)))
            if ((allergen & item) == item) list.Add(item);

        return list.ToArray();
    }
}