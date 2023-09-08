namespace BattleshipTests;

using Battleships;

[TestClass]
public class Vector2IntTests
{
    [TestMethod]
    public void ToVector2Int_Works()
    {
        Dictionary<string, Vector2Int?> testTable = new()
        {
            { "A1", new Vector2Int(0, 0) },
            { "AA11", null },
            { "", null },
            { "A111", null },
            { "B1", new Vector2Int(0, 1) },
            { "C1", new Vector2Int(0, 2) },
            { "J1", new Vector2Int(0, 9) },
            { "J2", new Vector2Int(1, 9) },
            { "J3", new Vector2Int(2, 9) },
            { "J10", new Vector2Int(9, 9) },
            { "B4", new Vector2Int(3, 1) },
            { "C7", new Vector2Int(6, 2) },
        };

        foreach (var test in testTable)
        {
            try
            {
                var result = Vector2Int.ParseVector2Int(test.Key).Value;
                Assert.IsTrue(test.Value.Equals(result));
            }
            catch
            {
                Assert.AreEqual(test.Value, null);
            }
        }
    }

    [TestMethod]
    public void ToCellCoordinate_Works()
    {
        Dictionary<string, Vector2Int?> testTable = new()
        {
            { "A1", new Vector2Int(0, 0) },
            { "B1", new Vector2Int(0, 1) },
            { "C1", new Vector2Int(0, 2) },
            { "J1", new Vector2Int(0, 9) },
            { "J2", new Vector2Int(1, 9) },
            { "J3", new Vector2Int(2, 9) },
            { "J10", new Vector2Int(9, 9) },
            { "B4", new Vector2Int(3, 1) },
            { "C7", new Vector2Int(6, 2) },
        };

        foreach (var test in testTable)
        {
            var result = test.Value.Value.ToCellCoordinate();
            Assert.IsTrue(test.Key.Equals(result));   
        }
    }
}