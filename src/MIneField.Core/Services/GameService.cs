using MineField.Core.Dependencies;
using MineField.Core.Entities;
using MineField.Core.Events;

namespace MineField.Core.Services;

public class GameService : IGameService
{
    private int _moves;
    private readonly GridPosition _playerPosition;
    private bool _gameOver = false;

    public GridPosition CurrentPosition => _playerPosition;

    public int Moves => _moves;

    public IList<GridPosition> MineLocations { get; private set; }

    public int Lives { get; private set; }

    public bool GameOver => _gameOver;

    public int GridDimensions { get; private set; }

    public event Action<object, InformPlayerEventArgs> InformPlayerTriggered;

    public GameService(IMineGenerator mineGenerator, IGameConfiguration gameConfiguration)
    {
        _playerPosition = new GridPosition(1, 1);
        Lives = gameConfiguration.Lives;
        GridDimensions = 8;
        MineLocations = mineGenerator.GenerateMines(gameConfiguration.NoOfMines);
    }

    public bool Move(MovementDirection movementDirection)
    {
        var hasMoved = false;

        if (!GameOver)
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
            InformPlayerTriggered?.Invoke(this, new InformPlayerEventArgs { Message = $"Unable to move off grid! Current position ({_playerPosition.ChessBoardNotation})" });
            return false;
        }
    }

    private bool CanMove(MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.Up => (_playerPosition.YPosition - 1) > 0,
            MovementDirection.Down => (_playerPosition.YPosition + 1) <= GridDimensions,
            MovementDirection.Left => (_playerPosition.XPosition - 1) > 0,
            MovementDirection.Right => (_playerPosition.XPosition + 1) <= GridDimensions,
            _ => false
        };
    }

    private void CheckForWinOrLoseConditions()
    {
        var mineHit = MineLocations.Contains(_playerPosition);

        InformPlayerTriggered?.Invoke(this, new InformPlayerEventArgs { Message = $"Current position ({_playerPosition.ChessBoardNotation}) - Lives {Lives} - Moves {Moves}" });

        if (mineHit)
        {
            LoseLife();
            return;
        }

        if (EndCheck())
            return;
    }

    private void LoseLife()
    {
        const string message = "BOOM you hit a mine and lost a life!";

        Lives--;

        if (Lives <= 0)
        {
            _gameOver = true;
            var gameOverMessage = message + Environment.NewLine + "GAME OVER!";

            InformPlayerTriggered?.Invoke(this, new InformPlayerEventArgs { Message = gameOverMessage });
        }
        else
        {
            InformPlayerTriggered?.Invoke(this, new InformPlayerEventArgs { Message = $"{message} Remaining lives:{Lives}" });
        }
    }

    private bool EndCheck()
    {
        var endCheck = HasReachedEnd();

        if (endCheck)
        {
            var livesText = Lives > 1 ? "lives" : "life";
            InformPlayerTriggered?.Invoke(this, new InformPlayerEventArgs { Message = $"Congratulations you reached the end of the grid in {Moves} moves! You had {Lives} {livesText} left." });
            _gameOver = true;
        }

        return endCheck;
    }

    private bool HasReachedEnd()
    {
        return _playerPosition.YPosition >= GridDimensions && GameOver == false;
    }
}