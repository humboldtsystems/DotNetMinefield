namespace MineField.Core.Dependencies;

public interface IGameConfiguration
{
    short Lives { get; set; }

    short NoOfMines { get; set; }
}