﻿using MineField.Core.Entities;

namespace MineField.Core.Dependencies;

public interface IGameService
{
    bool Move(MovementDirection movementDirection);

    GridPosition CurrentPosition { get; }

    short Moves { get; }

    IList<GridPosition> MineLocations { get; set; }

    short Lives { get; set; }

    bool GameOver { get; }

    short GridDimensions { get; set; }
}