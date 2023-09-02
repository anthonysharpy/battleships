namespace Battleships;

internal struct Vector2Int
{
    public int X;
    public int Y;

    public Vector2Int(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Could also have overloaded the == operator but I didn't really see the need to.
    // But in the real world I probably would have just to be safe.
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj is Vector2Int otherVector)
            return X == otherVector.X && Y == otherVector.Y;

        return false;
    }

    // Avoids compiler warning.
    public override int GetHashCode() => (X, Y).GetHashCode();

    /// <summary>
    /// Convert this vector into its string equivalent (e.g. 0,1 -> B1).
    /// </summary>
    public string ToCellCoordinate()
    {
        return $"{StringHelpers.NthLetterOfAlphabet(Y + 1).ToString().ToUpper()}{X + 1}";
    }

    public static Vector2Int ParseVector2Int(string input)
    {
        if (input == null || input.Length < 2)
            throw new Exception($"invalid coordinate string {input}");

        var row = StringHelpers.LetterToAlphabetNth(input[0]);

        input = input.Substring(1);

        // We already throw (and catch) a bunch of exceptions from this function so there is
        // no need to use TryParse.
        var column = int.Parse(input) - 1;

        if (row < 0 || row > 9)
            throw new Exception($"invalid row index {row}");

        if (column < 0 || column > 9)
            throw new Exception($"invalid column index {column}");

        return new Vector2Int(column, row);
    }
}
