using System;

public static class Bob
{
    const string QUESTION = "Sure.";
    const string EXPLANATION = "Whoa, chill out!";
    const string QUESTION_EXPLANATION = "Calm down, I know what I'm doing!";
    const string EMPTY = "Fine. Be that way!";
    const string OTHER = "Whatever.";
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if (statement.EndsWith('?'))
            return QUESTION;
        if (statement.Contains('!'))
            return EXPLANATION;
        if (statement.Contains('!') && statement.Contains('?'))
            return QUESTION_EXPLANATION;
        if (String.IsNullOrWhiteSpace(statement))
            return EMPTY;
        return OTHER;
    }
}