namespace BattleshipTests;

using Battleships;

[TestClass]
public class InputControllerTests
{
    [TestMethod]
    public void ParseOrientationString_Works()
    {
        Assert.IsTrue(InputController.ParseOrientationString("v") == ShipOrientationType.Vertical);
        Assert.IsTrue(InputController.ParseOrientationString("vertical") == ShipOrientationType.Vertical);
        Assert.IsTrue(InputController.ParseOrientationString("V") == ShipOrientationType.Vertical);
        Assert.IsTrue(InputController.ParseOrientationString("Vertical") == ShipOrientationType.Vertical);

        Assert.IsTrue(InputController.ParseOrientationString("h") == ShipOrientationType.Horizontal);
        Assert.IsTrue(InputController.ParseOrientationString("horizontal") == ShipOrientationType.Horizontal);
        Assert.IsTrue(InputController.ParseOrientationString("H") == ShipOrientationType.Horizontal);
        Assert.IsTrue(InputController.ParseOrientationString("Horizontal") == ShipOrientationType.Horizontal);

        Assert.IsTrue(InputController.ParseOrientationString("hv") == null);
        Assert.IsTrue(InputController.ParseOrientationString("dfsdf") == null);
        Assert.IsTrue(InputController.ParseOrientationString("353") == null);
        Assert.IsTrue(InputController.ParseOrientationString("") == null);
    }

    [TestMethod]
    public void ParseVector2String_Works()
    { 
        Assert.IsTrue(InputController.ParseVector2String("A1").Value.Equals(new Vector2Int(0, 0)));
        Assert.IsTrue(InputController.ParseVector2String("B2").Value.Equals(new Vector2Int(1, 1)));
        Assert.IsTrue(InputController.ParseVector2String("b2").Value.Equals(new Vector2Int(1, 1)));
        Assert.IsTrue(InputController.ParseVector2String("C3").Value.Equals(new Vector2Int(2, 2)));
        Assert.IsTrue(InputController.ParseVector2String("A4").Value.Equals(new Vector2Int(3, 0)));
        Assert.IsTrue(InputController.ParseVector2String("a4").Value.Equals(new Vector2Int(3, 0)));
        Assert.IsTrue(InputController.ParseVector2String("J10").Value.Equals(new Vector2Int(9, 9)));
        Assert.IsTrue(InputController.ParseVector2String("G6").Value.Equals(new Vector2Int(5, 6)));

        Assert.IsTrue(InputController.ParseVector2String("A0") == null);
        Assert.IsTrue(InputController.ParseVector2String("FF") == null);
        Assert.IsTrue(InputController.ParseVector2String("A") == null);
        Assert.IsTrue(InputController.ParseVector2String("0") == null);
        Assert.IsTrue(InputController.ParseVector2String("") == null);
        Assert.IsTrue(InputController.ParseVector2String("F333") == null);
    }
}