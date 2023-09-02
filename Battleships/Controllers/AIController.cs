namespace Battleships;

internal static class AIController
{
    public static void SetupBoardPieces(Board board)
    {
        foreach (var shipDefinition in Program.GameShipDefinition)
        {
            var ship = new Ship(Board.GetRandomBoardPosition(), shipDefinition, ShipOrientation.GetRandomOrientation());

            // Brute-force the ship into a valid location. It's not an amazing approach but it
            // is fine for this situation, and most of all, it's simple.
            while (!board.TryAddShip(ship))
                ship.SetPosition(Board.GetRandomBoardPosition(), ship.Orientation);
        }
    }

    public static Vector2Int GetRandomStrikePositionForBoard(Board board)
    {
        var strikePosition = Board.GetRandomBoardPosition();

        // Brute-force it. Not an amazing way to do it but it's not going to cause
        // a problem here.
        while (board.BoardContents[strikePosition.X, strikePosition.Y].Type != GridStatusType.Untouched)
            strikePosition = Board.GetRandomBoardPosition();

        return strikePosition;
    }
}

