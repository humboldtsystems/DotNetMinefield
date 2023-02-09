using Minefield.Core.UnitTests.Common;

namespace Minefield.Core.UnitTests.Services;

[TestFixture]
internal sealed class GameServiceTests : TestBase
{
    //// board dimension hard coded to GridDimensions = 8;

    // TODO:- start at 0,0 - move left - can't - to test HitBounds()
    // TODO:- start at 0,0 - move right - check Moves.CurrentPosition
    // TODO:- start at 0,0 - move up - can't - to test HitBounds()
    // TODO:- start at 0,0 - move down

    // TODO:- hit mine, check GameService.Lives decremented - to test LoseLife()

    // TODO:- after move, check GameService.Moves incremented

    // TODO:- move right from 0,7 -> 0,8 - to test HasReachedEnd()

    //// moq IMineGenerator??
    //// create hard coded IGameConfiguration through a fixture

    // TODO:- hit 3 mines, check GameService.Lives && GameService.LoseLife returns dead / game over
    // can use MineGenerator.PlaceMine() to put mines in easier to test locations !!!
}
