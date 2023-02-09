using MIneField.Core.Entities;

namespace MIneField.Core.Dependencies;

public interface IMineGenerator
{
    List<GridPosition> GenerateMines(int noOfMines);
}