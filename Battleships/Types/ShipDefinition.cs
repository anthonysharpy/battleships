namespace Battleships;

internal class ShipDefinition
{
    public int Length;
    public string Name;

    public ShipDefinition(int length, string name)
    {
        Length = length;
        Name = name;
    }

    public char GetBoardRepresentation()
    {
        // Won't work if two ships begin with the same letter (e.g. Battlecruiser and
        // Battleship), but it's fine for now.
        return Name[0];
    }
}
