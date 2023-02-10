using MineField.Core.Dependencies;
using MineField.Core.Entities;

namespace MineField.Core.Services;

public class MineGenerator : IMineGenerator
{
    public List<GridPosition> Mines { get; } = new();

    public List<GridPosition> GenerateMines(int noOfMines)
    {
        for (var i = 0; i < noOfMines; i++)
        {
            GridPosition gridPosition;
            do
            {
                Random random = new();
                var xPosition = random.Next(8);
                var yPosition = random.Next(8);
                gridPosition = new GridPosition(xPosition + 1, yPosition + 1); // Convert Zero based Random to 1 based !
            } while (Mines.Contains(gridPosition));

            PlaceMine(gridPosition);
        }

        return Mines;
    }

    public void PlaceMine(GridPosition mine)
    {
        Mines.Add(mine);
    }
}