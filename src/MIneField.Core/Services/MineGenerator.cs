using MineField.Core.Dependencies;
using MineField.Core.Entities;

namespace MineField.Core.Services;

public class MineGenerator : IMineGenerator
{
    public List<GridPosition> GenerateMines(int noOfMines)
    {
        List<GridPosition> mines = new();

        //noOfMines
        for (int i = 0; i < noOfMines; i++)
        {
            GridPosition gridPosition;
            do
            {
                Random random = new Random();
                int xPosition = random.Next(8);
                int yPosition = random.Next(8);
                gridPosition = new GridPosition(xPosition + 1, yPosition + 1); //Zero based Random
            } while (mines.Contains(gridPosition));

            mines.Add(gridPosition);
        }

        return mines;
    }
}