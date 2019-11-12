using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) =>
    string.Join("", text.Select(c =>
        {
            if (!char.IsLetter(c))
                return c;

            var d = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + shiftKey) - d) % 26) + d);
        }));
}