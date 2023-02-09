using MineField.Core.Entities;
using Shouldly;

namespace Minefield.Core.UnitTests.Entities;

[TestFixture]
public class GridPositionTests
{
    [Test]
    public void ChessBoardNotation_A1_Position_Success()
    {
        // arrange
        var gridPos = new GridPosition(1, 1);

        // assert
        gridPos.ChessBoardNotation.ShouldBe("A1");
    }
}