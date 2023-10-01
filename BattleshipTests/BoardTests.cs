namespace BattleshipTests;

using Battleships;

[TestClass]
public class BoardTests
{
    [TestMethod]
    public void GetBoardString_WhenBoardEmpty_PrintsCorrectly()
    {
        Board board = new();

        var output = board.GetBoardString(true);
        var expectedValue =
@"---------------------------------------------
|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |
---------------------------------------------
| A |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| B |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| C |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| D |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| E |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| F |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| G |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| H |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| I |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| J |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------

";
        expectedValue = expectedValue.Replace("\r", "");
        Assert.AreEqual(output, expectedValue);
    }

    [TestMethod]
    public void GetBoardString_PrintsOneShipCorrectly()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsTrue(board.TryAddShip(ship));

        var output = board.GetBoardString(true);
        var expectedValue =
@"---------------------------------------------
|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |
---------------------------------------------
| A |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| B |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| C |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| D |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| E |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| F |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| G |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| H |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| I |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| J |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------

";
        expectedValue = expectedValue.Replace("\r", "");
        Assert.AreEqual(output, expectedValue);
    }

    [TestMethod]
    public void GetBoardString_PrintsTwoShipsCorrectly()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsTrue(board.TryAddShip(ship));

        Ship ship2 = new(new Vector2Int(4, 4), new ShipDefinition(1, "Bigboy"), ShipOrientationType.Horizontal);
        Assert.IsTrue(board.TryAddShip(ship2));

        var output = board.GetBoardString(true);
        var expectedValue =
@"---------------------------------------------
|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |
---------------------------------------------
| A |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| B |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| C |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| D |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| E |   | T |   |   | B |   |   |   |   |   |
---------------------------------------------
| F |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| G |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| H |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| I |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| J |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------

";
        expectedValue = expectedValue.Replace("\r", "");
        Assert.AreEqual(output, expectedValue);
    }

    [TestMethod]
    public void GetBoardString_ShowShips_HidesShipsWhenFalse()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsTrue(board.TryAddShip(ship));

        Ship ship2 = new(new Vector2Int(4, 4), new ShipDefinition(1, "Bigboy"), ShipOrientationType.Horizontal);
        Assert.IsTrue(board.TryAddShip(ship2));

        var output = board.GetBoardString(false);
        var expectedValue =
@"---------------------------------------------
|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |
---------------------------------------------
| A |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| B |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| C |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| D |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| E |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| F |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| G |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| H |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| I |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| J |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------

";
        expectedValue = expectedValue.Replace("\r", "");
        Assert.AreEqual(output, expectedValue);
    }

    [TestMethod]
    public void GetBoardString_ShowsHits()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsTrue(board.TryAddShip(ship));

        var message = board.AttackCell(1, 1);
        Assert.AreEqual(message, "Hit. A test is on fire!");

        var output = board.GetBoardString(true);
        var expectedValue =
@"---------------------------------------------
|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |
---------------------------------------------
| A |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| B |   | X |   |   |   |   |   |   |   |   |
---------------------------------------------
| C |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| D |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| E |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| F |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| G |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| H |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| I |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| J |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------

";
        expectedValue = expectedValue.Replace("\r", "");
        Assert.AreEqual(output, expectedValue);
    }

    [TestMethod]
    public void GetBoardString_ShowsMisses()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsTrue(board.TryAddShip(ship));

        var message = board.AttackCell(2, 1);
        Assert.IsTrue(message == "Miss.");

        var output = board.GetBoardString(true);
        var expectedValue =
@"---------------------------------------------
|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |
---------------------------------------------
| A |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| B |   | T | - |   |   |   |   |   |   |   |
---------------------------------------------
| C |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| D |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| E |   | T |   |   |   |   |   |   |   |   |
---------------------------------------------
| F |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| G |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| H |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| I |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------
| J |   |   |   |   |   |   |   |   |   |   |
---------------------------------------------

";
        expectedValue = expectedValue.Replace("\r", "");
        Assert.AreEqual(output, expectedValue);
    }

    [TestMethod]
    public void AnyShipsLeft_Works()
    {
        Board board = new();

        Assert.IsFalse(board.AnyShipsLeft());

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        board.TryAddShip(ship);

        Assert.IsTrue(board.AnyShipsLeft());

        board.AttackCell(1, 1);
        board.AttackCell(1, 2);
        board.AttackCell(1, 3);
        board.AttackCell(1, 4);

        Assert.IsFalse(board.AnyShipsLeft());
    }

    [TestMethod]
    public void SameAreaHitTwice_IsAMiss()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(1, 1), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        board.TryAddShip(ship);

        board.AttackCell(1, 1);

        var message = board.AttackCell(1, 1);

        Assert.IsTrue(message == "Miss.");
    }

    [TestMethod]
    public void TryAddShip_MustBeWithinBoard()
    {
        Board board = new();

        Ship ship = new(new Vector2Int(9, 9), new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsFalse(board.TryAddShip(ship));

        ship.SetPosition(new Vector2Int(0, 9), ShipOrientationType.Vertical);
        Assert.IsFalse(board.TryAddShip(ship));

        ship.SetPosition(new Vector2Int(-1, 9), ShipOrientationType.Vertical);
        Assert.IsFalse(board.TryAddShip(ship));

        ship.SetPosition(new Vector2Int(-1, 9), ShipOrientationType.Horizontal);
        Assert.IsFalse(board.TryAddShip(ship));

        ship.SetPosition(new Vector2Int(9, 9), ShipOrientationType.Horizontal);
        Assert.IsFalse(board.TryAddShip(ship));

        ship.SetPosition(new Vector2Int(9, 0), ShipOrientationType.Horizontal);
        Assert.IsFalse(board.TryAddShip(ship));

        ship.SetPosition(new Vector2Int(9, -1), ShipOrientationType.Horizontal);
        Assert.IsFalse(board.TryAddShip(ship));
    }

    [TestMethod]
    public void TryAddShip_DoesntAllowOverlappingShips()
    {
        Board board = new();

        Ship ship = new(Vector2Int.ParseVector2Int("B5")!.Value, new ShipDefinition(5, "Test"), ShipOrientationType.Horizontal);
        Assert.IsTrue(board.TryAddShip(ship));

        Ship ship2 = new(Vector2Int.ParseVector2Int("E6")!.Value, new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsTrue(board.TryAddShip(ship2));

        Ship ship3 = new(Vector2Int.ParseVector2Int("F5")!.Value, new ShipDefinition(4, "Test"), ShipOrientationType.Horizontal);
        Assert.IsFalse(board.TryAddShip(ship3));

        Ship ship4 = new(Vector2Int.ParseVector2Int("A5")!.Value, new ShipDefinition(4, "Test"), ShipOrientationType.Vertical);
        Assert.IsFalse(board.TryAddShip(ship4));
    }
}