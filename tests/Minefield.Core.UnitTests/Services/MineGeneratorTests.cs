using MineField.Core.Services;
using Shouldly;

namespace Minefield.Core.UnitTests.Services;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
}
