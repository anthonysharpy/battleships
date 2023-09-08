namespace Battleships;

internal class Board
{
    public GridStatus[,] BoardContents = new GridStatus[10,10];

    private List<Ship> Ships = new();
    private static Random Randomiser = new(); // No point constantly creating this.

    public bool TryAddShip(Ship newShip)
    {
        if (!IsShipPlacementValid(newShip))
            return false;

        Ships.Add(newShip);
        return true;
    }

    /// <summary>
    /// Returns a char representing what's at this cell.
    /// </summary>
    private char GetCharForCell(int x, int y, bool showShips)
    {
        var cell = BoardContents[x, y].ToString();

        if (cell != " ")
            return cell[0]; // If there is a hit marker here, prefer showing that.

        if (showShips)
        {
            var ship = GetShipAt(x, y);

            if (ship != null)
                return ship.Definition.GetBoardRepresentation();
        }

        return ' '; // Nothing here.
    }

    public static Vector2Int GetRandomBoardPosition()
    {
        return new Vector2Int(Randomiser.Next() % 10, Randomiser.Next() % 10);
    }

    public bool AnyShipsLeft()
    {
        return Ships.Any(x => !ShipIsSunk(x));
    }

    /// <summary>
    /// Attack this cell, returning a string representing what happened.
    /// </summary>
    public string AttackCell(int x, int y)
    {
        if (BoardContents[x, y].Type != GridStatusType.Untouched)
            return "Miss.";

        var ship = GetShipAt(x, y);

        if ( ship != null )
        {
            BoardContents[x, y].Type = GridStatusType.Hit;

            if (ShipIsSunk(ship))
                return $"Sunk. A {ship.Definition.Name.ToLower()} goes down!";
            else
                return $"Hit. A {ship.Definition.Name.ToLower()} is on fire!";
        }

        BoardContents[x, y].Type = GridStatusType.Miss;
        return $"Miss.";
    }

    // It feels more natural having this on the Board object instead of the Ship object
    // since the board already tracks hits and misses; it would be superfluous for the
    // ship to also track hits.
    private bool ShipIsSunk(Ship ship)
    {
        foreach (var cell in ship.SpacesOccupied)
            if (BoardContents[cell.X, cell.Y].Type != GridStatusType.Hit)
                return false;

        return true;
    }

    private Ship GetShipAt(int x, int y)
    {
        return Ships.SingleOrDefault(ship => ship.DoesOccupySpace(x, y));
    }

    private bool IsShipPlacementValid(Ship ship)
    {
        // Can't overlap other ships.
        foreach (var existingShip in Ships)
            if (existingShip.DoesOccupySpaces(ship.SpacesOccupied))
                return false;

        // Must be within the bounds of the board.
        foreach (var space in ship.SpacesOccupied)
            if (space.X < 0 || space.X > 9 || space.Y < 0 || space.Y > 9)
                return false;

        return true;
    }

    // Returning a string instead of printing directly to IO makes this easier
    // to unit test. It would be better practice to use StringBuilder but I
    // think that is overkill for this scenario.
    public string GetBoardString(bool showShips)
    {
        // Top axis.
        var result = FormatLineWithContents(new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

        // Rest of board.
        for (int y = 0; y < BoardContents.GetLength(0); y++)
        {
            string[] row = new string[11];
            row[0] = StringHelpers.NthLetterOfAlphabet(y + 1).ToString();

            for (int x = 0; x < BoardContents.GetLength(1); x++)
            {
                row[x + 1] = $"{GetCharForCell(x, y, showShips)}";
            }

            result += FormatLineWithContents(row);
        }

        result += GetHorizontalLine(); // Final line to close off the grid.
        return result + "\n";
    }

    public void Print(bool showShips)
    {
        Console.Clear();
        Console.Write(GetBoardString(showShips));
    }

    // I mean this could also just be a const variable but it doesn't really matter.
    // It's nice to have as a function as we may want to make it more complicated later.
    private string GetHorizontalLine()
    {
        return "---------------------------------------------\n";
    }

    private string FormatCellItem(string item, bool withRightmostBar)
    {
        string result = "";

        switch (item.Length)
        {
            case 0:
                result += "|   ";
                break;
            case 1:
                result += $"| {item} ";
                break;
            case 2:
                result += $"|{item} ";
                break;
            default:
                throw new Exception($"string was too long ({item.Length})");
        }

        if (withRightmostBar)
            result += "|";

        return result;
    }

    private string FormatLineWithContents(string[] contents)
    {
        var result = GetHorizontalLine();

        if (contents.Length != 11)
            throw new Exception("a line must have 11 columns");

        for (int i = 0; i < contents.Length; i++)
            result += FormatCellItem(contents[i], i == 10);

        return result + "\n";
    }
}

