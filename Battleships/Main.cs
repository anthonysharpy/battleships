using Battleships;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BattleshipTests")]

static class Program
{
    private static Board _playerBoard = new();
    private static Board _aiBoard = new();

    // We can add more ships or even define new ones.
    public static ShipDefinition[] GameShipDefinition = new[] {
        new ShipDefinition(5, "Battleship"),
        new ShipDefinition(4, "Destroyer"),
        new ShipDefinition(4, "Destroyer"),
    };

    static void Main(string[] args)
    {
        SetupGame();
        GameplayLoop();
    }

    private static void SetupGame()
    {
        AIController.SetupBoardPieces(_aiBoard);

		_playerBoard.Print(true);
        Console.WriteLine("It is time to setup your ships.");

        for (int i = 0; i < GameShipDefinition.Length; i++)
        {
            var ship = new Ship(new Vector2Int(0, 0), GameShipDefinition[i], ShipOrientationType.Vertical);

            if (i != 0)
				_playerBoard.Print(true);

            PlayerSetupShipRoutine(ship, StringHelpers.IntToOrdinal(i+1));
        }      
    }

    private static void PlayerSetupShipRoutine(Ship ship, string nthDescriptor)
    {
        var shipOrientation = InputController.GetUserInput($"Your {nthDescriptor} ship is a " +
            $"{ship.Definition.Name.ToLower()}, which is {ship.Definition.Length} units long. Please enter whether you would like to "+
            "place this ship vertically (v) or horizontally (h): ", ShipOrientation.ParseShipOrientation);

        var shipPosition = InputController.GetUserInput("Please enter the coordinates you would like to place it at "+
            "(e.g. B2, E7) - this will be the topmost or leftmost point of the boat: ", Vector2Int.ParseVector2Int);

        ship.SetPosition(shipPosition!.Value, shipOrientation!.Value);

        while (!_playerBoard.TryAddShip(ship))
        {
            shipPosition = InputController.GetUserInput("Your ship doesn't fit there, please choose somewhere else: ",
                Vector2Int.ParseVector2Int);
            ship.SetPosition(shipPosition!.Value, shipOrientation.Value);
        }
    }

    private static void GameplayLoop()
    {
        while (true)
        {
			_aiBoard.Print(false);

            var strikePosition = InputController.GetUserInput("This is your opponent's board. Where would you like to aim next?: ",
                    Vector2Int.ParseVector2Int)!.Value;
            Console.WriteLine($"You attacked {strikePosition.ToCellCoordinate()}.");
            Console.WriteLine(_aiBoard.AttackCell(strikePosition.X, strikePosition.Y));

            if (!_aiBoard.AnyShipsLeft())
            {
                Console.WriteLine("Your opponent has no ships left. You win! Thanks for playing!");
                break;
            }

            Console.ReadKey();

            var aiStrikePosition = AIController.GetRandomStrikePositionForBoard(_playerBoard);
            var aiAttack = $"Your opponent attacked {aiStrikePosition.ToCellCoordinate()}.";
            var aiAttackResult = _playerBoard.AttackCell(aiStrikePosition.X, aiStrikePosition.Y);

			_playerBoard.Print(true);
            Console.WriteLine(aiAttack);
            Console.WriteLine(aiAttackResult);

            if (!_playerBoard.AnyShipsLeft())
            {
                Console.WriteLine("You have no ships left. You lose! Thanks for playing!");
                break;
            }

            Console.ReadKey();
        }
    }
}