using Minefield.Core.UnitTests.Common;
using MineField.Core.Entities;
using MineField.Core.Services;
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

    [Test]
    public void Check_Equals()
    {
        // arrange
        var gridPos = new GridPosition(1, 1);
        var mineGenerator = new MineGenerator();
        var mine = new GridPosition(1, 1);
        mineGenerator.PlaceMine(mine);

        // act
        var hasMine = mineGenerator.Mines.Contains(gridPos);

        // assert
        hasMine.ShouldBe(true);
    }

}