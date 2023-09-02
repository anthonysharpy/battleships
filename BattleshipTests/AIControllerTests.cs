namespace BattleshipTests;

using Battleships;

[TestClass]
public class AIControllerTests
{
    [TestMethod]
    public void SetupBoardPieces_Works()
    {
        Board board = new();

        AIController.SetupBoardPieces(board);

        var result = board.GetBoardString(true);

        // 1 battleship and 2 destroyers.
        Assert.IsTrue(result.Where(x => x == 'B').Count() == 6); // 6 not 5 beacause "B" also shows up in the axis.
        Assert.IsTrue(result.Where(x => x == 'D').Count() == 9); // 9 not 8 beacause "D" also shows up in the axis.
    }

    [TestMethod]
    public void GetRandomStrikePositionForBoard_Works()
    {
        Board board = new();

        for (int i = 0; i < 1000; i++)
        {
            var position = AIController.GetRandomStrikePositionForBoard(board);

            Assert.IsTrue(position.X >= 0 && position.X <= 9);
            Assert.IsTrue(position.Y >= 0 && position.Y <= 9);
        }
    }
}