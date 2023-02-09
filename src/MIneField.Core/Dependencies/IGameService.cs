using MineField.Core.Entities;

namespace MineField.Core.Dependencies;

public interface IGameService
{
    bool Move(MovementDirection movementDirection);

    GridPosition CurrentPosition { get; }

    int Moves { get; }

    IList<GridPosition> MineLocations { get; set; }

    int Lives { get; set; }

    bool GameOver { get; }

    int GridDimensions { get; set; }
}