namespace Battleships;

public enum ShipOrientationType
{
    Vertical,
    Horizontal
}

// Originally I had all this in the Ship class but the ParseShipOrientation function
// felt out of place so I made a separate struct for it. I think it would have been
// fine either way.
internal struct ShipOrientation
{
    public ShipOrientationType Type;

    private static Random Randomiser = new(); // No point constantly creating this.

    public static ShipOrientationType? ParseShipOrientation(string input)
    {
        switch (input.ToLower())
        {
            case "v":
                return ShipOrientationType.Vertical;
            case "h":
                return ShipOrientationType.Horizontal;
            case "vertical":
                return ShipOrientationType.Vertical;
            case "horizontal":
                return ShipOrientationType.Horizontal;
            default:
                return null;
        }
    }

    public static ShipOrientationType GetRandomOrientation()
    {
        var n = Randomiser.Next() % 2;

        switch (n)
        {
            case 0:
                return ShipOrientationType.Vertical;
            case 1:
                return ShipOrientationType.Horizontal;
            default:
                throw new Exception($"no ship orientation for value {n}");
        }
    }
}
