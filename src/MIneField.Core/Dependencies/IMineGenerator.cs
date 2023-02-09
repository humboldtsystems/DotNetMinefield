using MineField.Core.Entities;

namespace MineField.Core.Dependencies;

public interface IMineGenerator
{
    List<GridPosition> GenerateMines(int noOfMines);
}