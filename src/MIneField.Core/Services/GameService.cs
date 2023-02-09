using MineField.Core.Dependencies;
using MineField.Core.Entities;

namespace MineField.Core.Services;

public class GameService : IGameService
{
    private int _moves;
    private readonly GridPosition _playerPosition;
    private bool _gameOver = false;

    public GridPosition CurrentPosition => _playerPosition;

    public int Moves => _moves;

    public IList<GridPosition> MineLocations { get; set; }

    public int Lives { get; set; }

    public bool GameOver => _gameOver;

    public int GridDimensions { get; set; }

    public GameService(IMineGenerator mineGenerator, IGameConfiguration gameConfiguration)
    {
        _playerPosition = new GridPosition(1, 1);
        Lives = gameConfiguration.Lives;
        GridDimensions = 8;
        MineLocations = mineGenerator.GenerateMines(gameConfiguration.NoOfMines);
    }

    public bool Move(MovementDirection movementDirection)
    {
        bool hasMoved = false;

        if(!GameOver)
        {
            switch (movementDirection)
            {
                case MovementDirection.Up:
                    if (CanMove(movementDirection))
                    {
                        _playerPosition.YPosition--;
                        hasMoved = true;
                    }

                    break;

                case MovementDirection.Down:
                    if (CanMove(movementDirection))
                    {
                        _playerPosition.YPosition++;
                        hasMoved = true;
                    }

                    break;

                case MovementDirection.Left:
                    if (CanMove(movementDirection))
                    {
                        _playerPosition.XPosition--;
                        hasMoved = true;
                    }

                    break;

                case MovementDirection.Right:
                    if (CanMove(movementDirection))
                    {
                        _playerPosition.XPosition++;
                        hasMoved = true;
                    }

                    break;
            }
        }
        
        if (hasMoved)
        {
            _moves++;

            CheckForWinOrLoseConditions();
            return true;
        }
        else
        {
            // todo:- raise event to update console?
            Console.WriteLine($"Unable to move off grid! Current position ({_playerPosition.ChessBoardNotation})");
            return false;
        }
    }

    private bool CanMove(MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.Up => (_playerPosition.YPosition - 1) > 0,
            MovementDirection.Down => (_playerPosition.YPosition + 1) < GridDimensions,
            MovementDirection.Left => (_playerPosition.XPosition - 1) > 0,
            MovementDirection.Right => (_playerPosition.XPosition + 1) <= GridDimensions,
            _ => false
        };
    }

    private void CheckForWinOrLoseConditions()
    {
        var mineHit = MineLocations.Contains(_playerPosition);

        // todo:- raise event to update console?
        Console.WriteLine($"Current position ({_playerPosition.ChessBoardNotation}) - Lives {Lives} - Moves {Moves}");

        if (mineHit)
        {
            LoseLife();
            return;
        }

        if (HasReachedEnd())
        {
            var livesText = Lives > 1 ? "lives" : "life";
            // todo:- raise event to update console?
            Console.WriteLine($"Congratulations you reached the end of the grid in {Moves} moves! You had {Lives} {livesText} left.");
            _gameOver = true;
            return;
        }
    }

    private void LoseLife()
    {
        const string message = "BOOM you hit a mine and lost a life!";

        Lives--;

        if (Lives <= 0)
        {
            _gameOver = true;
            // todo:- raise event to update console?
            Console.WriteLine(message);
            Console.WriteLine("GAME OVER!");
        }
        else
        {
            // todo:- raise event to update console?
            Console.WriteLine($"{message} Remaining lives:{Lives}");
        }
    }

    private bool HasReachedEnd()
    {
        return _playerPosition.YPosition >= GridDimensions && GameOver == false;
    }
}