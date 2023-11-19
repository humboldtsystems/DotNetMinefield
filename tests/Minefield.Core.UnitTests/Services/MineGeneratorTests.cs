using Minefield.Core.UnitTests.Common;
using MineField.Core.Entities;
using MineField.Core.Services;
using Shouldly;

namespace Minefield.Core.UnitTests.Services;

internal sealed class MineGeneratorTests : TestBase
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void GenerateMines_Success()
    {
        // arrange
        var mineGenerator = new MineGenerator();

        // act
        var minePositions = mineGenerator.GenerateMines(10);

        // assert
        minePositions.Count.ShouldBe(10);
    }

    // test explicit mine location
    [Test]
    public void PlaceMine_Success()
    {
        // arrange
        var mineGenerator = new MineGenerator();
        var mine = new GridPosition(1, 1);

        // act
        mineGenerator.PlaceMine(mine);

        // assert
        var minePositions = mineGenerator.Mines;
        minePositions.Count.ShouldBe(1);

        var minePosition = minePositions[0];

        minePosition.XPosition.ShouldBe(mine.XPosition);
        minePosition.YPosition.ShouldBe(mine.YPosition);
    }
    
    // TODO mr:- could also test 2 mines not created in same grid position?  
}
