using MineField.Core.Entities;

namespace MineField.Core.Dependencies;

public interface IMineGenerator
{
    List<GridPosition> Mines { get; }

    List<GridPosition> GenerateMines(int noOfMines);

    /// <summary>
    /// Seperated this out so we can place a mine in a specific position for unit testing
    /// </summary>
    /// <param name="mine"></param>
    void PlaceMine(GridPosition mine);
}