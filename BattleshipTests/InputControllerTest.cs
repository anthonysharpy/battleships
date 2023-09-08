namespace BattleshipTests;

using Battleships;

[TestClass]
public class InputControllerTests
{
    [TestMethod]
    public void ParseOrientationString_Works()
    {
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("v") == ShipOrientationType.Vertical);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("vertical") == ShipOrientationType.Vertical);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("V") == ShipOrientationType.Vertical);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("Vertical") == ShipOrientationType.Vertical);

        Assert.IsTrue(ShipOrientation.ParseShipOrientation("h") == ShipOrientationType.Horizontal);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("horizontal") == ShipOrientationType.Horizontal);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("H") == ShipOrientationType.Horizontal);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("Horizontal") == ShipOrientationType.Horizontal);

        Assert.IsTrue(ShipOrientation.ParseShipOrientation("hv") == null);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("dfsdf") == null);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("353") == null);
        Assert.IsTrue(ShipOrientation.ParseShipOrientation("") == null);
    }

    [TestMethod]
    public void ParseVector2String_Works()
    { 
        Assert.IsTrue(Vector2Int.ParseVector2Int("A1").Value.Equals(new Vector2Int(0, 0)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("B2").Value.Equals(new Vector2Int(1, 1)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("b2").Value.Equals(new Vector2Int(1, 1)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("C3").Value.Equals(new Vector2Int(2, 2)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("A4").Value.Equals(new Vector2Int(3, 0)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("a4").Value.Equals(new Vector2Int(3, 0)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("J10").Value.Equals(new Vector2Int(9, 9)));
        Assert.IsTrue(Vector2Int.ParseVector2Int("G6").Value.Equals(new Vector2Int(5, 6)));

        Assert.IsTrue(Vector2Int.ParseVector2Int("A0") == null);
        Assert.IsTrue(Vector2Int.ParseVector2Int("FF") == null);
        Assert.IsTrue(Vector2Int.ParseVector2Int("A") == null);
        Assert.IsTrue(Vector2Int.ParseVector2Int("0") == null);
        Assert.IsTrue(Vector2Int.ParseVector2Int("") == null);
        Assert.IsTrue(Vector2Int.ParseVector2Int("F333") == null);
    }
}