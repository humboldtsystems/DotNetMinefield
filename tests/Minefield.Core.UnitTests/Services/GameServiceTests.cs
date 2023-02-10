using Microsoft.Extensions.DependencyInjection;
using Minefield.Core.UnitTests.Common;
using MineField.Core.Dependencies;
using MineField.Core.Entities;
using Shouldly;

namespace Minefield.Core.UnitTests.Services;

[TestFixture]
internal sealed class GameServiceTests : TestBase
{
    //// board dimension hard coded to GridDimensions = 8;

    /// <summary>
    /// start at 0,0 - move left - can't - to test HitBounds()
    /// </summary>
    [Test]
    public void Move_Left_Fail()
    {
        // arrange
        var gameEngine = ServiceProvider.GetService<IGameService>();

        // act
        var moveStatus = gameEngine!.Move(MovementDirection.Left);

        // assert
        moveStatus.ShouldBe(false);
        gameEngine.Lives.ShouldBe(3);
        gameEngine.Moves.ShouldBe(0);
        gameEngine.CurrentPosition.XPosition.ShouldBe(1);
        gameEngine.CurrentPosition.YPosition.ShouldBe(1);
        gameEngine.MineLocations.Count.ShouldBe(10);
    }

    /// <summary>
    /// start at 0,0 - move right
    /// </summary>
    [Test]
    public void Move_Right_Success()
    {
        // arrange
        var gameEngine = ServiceProvider.GetService<IGameService>();

        // act
        var moveStatus = gameEngine!.Move(MovementDirection.Right);

        // assert
        moveStatus.ShouldBe(true);
        //gameEngine.Lives.ShouldBe(3);
        gameEngine.Moves.ShouldBe(1);
        gameEngine.CurrentPosition.XPosition.ShouldBe(2);
        gameEngine.CurrentPosition.YPosition.ShouldBe(1);
        gameEngine.MineLocations.Count.ShouldBe(10);
    }

    /// <summary>
    /// start at 0,0 - move up - can't - to test HitBounds()
    /// </summary>
    [Test]
    public void Move_Up_Fail()
    {
        // arrange
        var gameEngine = ServiceProvider.GetService<IGameService>();

        // act
        var moveStatus = gameEngine!.Move(MovementDirection.Up);

        // assert
        moveStatus.ShouldBe(false);
        gameEngine.Lives.ShouldBe(3);
        gameEngine.Moves.ShouldBe(0);
        gameEngine.CurrentPosition.XPosition.ShouldBe(1);
        gameEngine.CurrentPosition.YPosition.ShouldBe(1);
        gameEngine.MineLocations.Count.ShouldBe(10);
    }

    /// <summary>
    /// start at 0,0 - move down
    /// </summary>
    [Test]
    public void Move_Down_Success()
    {
        // arrange
        var gameEngine = ServiceProvider.GetService<IGameService>();

        // act
        var moveStatus = gameEngine!.Move(MovementDirection.Down);

        // assert
        moveStatus.ShouldBe(true);
        //gameEngine.Lives.ShouldBe(3);
        gameEngine.Moves.ShouldBe(1);
        gameEngine.CurrentPosition.XPosition.ShouldBe(1);
        gameEngine.CurrentPosition.YPosition.ShouldBe(2);
        gameEngine.MineLocations.Count.ShouldBe(10);
    }

    /// <summary>
    /// move in a diagonal to see if we can get to the end with lives in-tact
    /// </summary>
    [Test]
    public void Keep_Moving_Success()
    {
        // arrange
        var gameEngine = ServiceProvider.GetService<IGameService>();
        bool moveStatus = false;

        // act
        moveStatus = gameEngine!.Move(MovementDirection.Right);

        // assert
        moveStatus.ShouldBe(true);
        gameEngine.Moves.ShouldBe(1);
        gameEngine.CurrentPosition.XPosition.ShouldBe(2);
        gameEngine.CurrentPosition.YPosition.ShouldBe(1);
        gameEngine.MineLocations.Count.ShouldBe(10);

        moveStatus = gameEngine!.Move(MovementDirection.Down);
        moveStatus.ShouldBe(true);
        gameEngine.Moves.ShouldBe(2);
        gameEngine.CurrentPosition.XPosition.ShouldBe(2);
        gameEngine.CurrentPosition.YPosition.ShouldBe(2);

        moveStatus = gameEngine!.Move(MovementDirection.Right);
        moveStatus.ShouldBe(true);
        gameEngine.Moves.ShouldBe(3);
        gameEngine.CurrentPosition.XPosition.ShouldBe(3);
        gameEngine.CurrentPosition.YPosition.ShouldBe(2);

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Down);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(4);
            gameEngine.CurrentPosition.XPosition.ShouldBe(3);
            gameEngine.CurrentPosition.YPosition.ShouldBe(3);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Right);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(5);
            gameEngine.CurrentPosition.XPosition.ShouldBe(4);
            gameEngine.CurrentPosition.YPosition.ShouldBe(3);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Down);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(6);
            gameEngine.CurrentPosition.XPosition.ShouldBe(4);
            gameEngine.CurrentPosition.YPosition.ShouldBe(4);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Right);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(7);
            gameEngine.CurrentPosition.XPosition.ShouldBe(5);
            gameEngine.CurrentPosition.YPosition.ShouldBe(4);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Down);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(8);
            gameEngine.CurrentPosition.XPosition.ShouldBe(5);
            gameEngine.CurrentPosition.YPosition.ShouldBe(5);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Right);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(9);
            gameEngine.CurrentPosition.XPosition.ShouldBe(6);
            gameEngine.CurrentPosition.YPosition.ShouldBe(5);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Down);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(10);
            gameEngine.CurrentPosition.XPosition.ShouldBe(6);
            gameEngine.CurrentPosition.YPosition.ShouldBe(6);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Right);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(11);
            gameEngine.CurrentPosition.XPosition.ShouldBe(7);
            gameEngine.CurrentPosition.YPosition.ShouldBe(6);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Down);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(12);
            gameEngine.CurrentPosition.XPosition.ShouldBe(7);
            gameEngine.CurrentPosition.YPosition.ShouldBe(7);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Right);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(13);
            gameEngine.CurrentPosition.XPosition.ShouldBe(8);
            gameEngine.CurrentPosition.YPosition.ShouldBe(7);
        }

        if (!gameEngine.GameOver)
        {
            moveStatus = gameEngine!.Move(MovementDirection.Down);
            moveStatus.ShouldBe(true);
            gameEngine.Moves.ShouldBe(14);
            gameEngine.CurrentPosition.XPosition.ShouldBe(8);
            gameEngine.CurrentPosition.YPosition.ShouldBe(8);
        }
    }

    // TODO:- hit 3 mines, check GameService.Lives && GameService.LoseLife returns dead / game over
    // can use MineGenerator.PlaceMine() to put mines in easier to test locations !!!
}
