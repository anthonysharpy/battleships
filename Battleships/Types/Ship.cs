namespace Battleships;

internal class Ship
{
    public Vector2Int Position { get; private set; } // Top-left of the board is 0, 0.
    public ShipOrientationType Orientation { get; private set; }
    public ShipDefinition Definition { get; private set; }
    public Vector2Int[] SpacesOccupied { get; private set; } // No point recalculating this all the time so let's save it.

    public Ship(Vector2Int position, ShipDefinition definition, ShipOrientationType orientation)
    {
        Definition = definition;
        Position = position;
        Orientation = orientation;

        CalculateSpacesOccupied();
    }

    private void CalculateSpacesOccupied()
    {
        SpacesOccupied = new Vector2Int[Definition.Length];

        if (Orientation == ShipOrientationType.Vertical)
        {
            for (int y = Position.Y, i = 0; y < Position.Y + Definition.Length; y++, i++)
            {
                SpacesOccupied[i] = new Vector2Int(Position.X, y);
            }
        }
        else
        {
            for (int x = Position.X, i = 0; x < Position.X + Definition.Length; x++, i++)
            {
                SpacesOccupied[i] = new Vector2Int(x, Position.Y);
            }
        }
    }

    // During the initial setup phase of the game we need to be able to place and
    // re-place ships. 
    public void SetPosition(Vector2Int position, ShipOrientationType orientation)
    {
        Orientation = orientation;
        Position = position;
        CalculateSpacesOccupied();
    }

    // Useful for seeing if a ship was hit.
    public bool DoesOccupySpace(int x, int y)
    {
        return SpacesOccupied.Any(space => space.X == x && space.Y == y);
    }

    // Useful for seeing if a ship would overlap another.
    public bool DoesOccupySpaces(Vector2Int[] spaces)
    {
        foreach (var space in spaces)
            if (SpacesOccupied.Any(so => so.Equals(space)))
                return true;

        return false;
    }
}
