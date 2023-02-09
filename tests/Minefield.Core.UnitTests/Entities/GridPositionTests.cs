using Minefield.Core.UnitTests.Common;
using MineField.Core.Entities;
using Shouldly;

namespace Minefield.Core.UnitTests.Entities;

[TestFixture]
internal sealed class GridPositionTests : TestBase
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