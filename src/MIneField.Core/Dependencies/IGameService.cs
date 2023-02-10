using MineField.Core.Entities;
using MineField.Core.Events;

namespace MineField.Core.Dependencies;

public interface IGameService
{
    bool Move(MovementDirection movementDirection);

    GridPosition CurrentPosition { get; }

    int Moves { get; }

    IList<GridPosition> MineLocations { get; }

    int Lives { get; }

    bool GameOver { get; }

    int GridDimensions { get; }

    event Action<object, InformPlayerEventArgs> InformPlayerTriggered;
}