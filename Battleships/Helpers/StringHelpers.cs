namespace Battleships;

internal static class StringHelpers
{
    public static string IntToOrdinal(int n)
    {
        switch (n)
        {
            case 1:
                return "first";
            case 2:
                return "second";
            case 3:
                return "third";
            case 4:
                return "fourth";
            case 5:
                return "fifth";
            case 6:
                return "sixth";
            case 7:
                return "seventh";
            case 8:
                return "eighth";
            case 9:
                return "ninth";
            case 10:
                return "tenth";
            default:
                // Depending on the use-case this might not be the best way to handle it
                // in a production environment. But since I know that this should never
                // happen it's fine to throw here.
                throw new Exception("unsupported ordinal number " + n);
        }
    }

    /// <summary>
    /// Get the nth letter of the alphabet.
    /// </summary>
    public static char NthLetterOfAlphabet(int n)
    {
        if (n < 1 || n > 26)
            throw new Exception($"the number {n} does not represent an nth letter of the alphabet"); 

        return (char)(n+64);
    }

    /// <summary>
    /// Find out what nth letter of the alphabet a given letter is.
    /// Zero-indexed (i.e. A = 0).
    /// </summary>
    public static int LetterToAlphabetNth(char letter)
    {
        // Lowercase letters.
        if (letter >= 97 && letter <= 122)
            return letter - 97;

        // Lowercase letters.
        if (letter >= 65 && letter <= 90)
            return letter - 65;

        throw new Exception($"unrecognised letter {letter}");
    }
}

