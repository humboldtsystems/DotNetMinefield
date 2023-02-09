namespace MineField.Core.Entities;

public class GridPosition
{
    public GridPosition(int x, int y)
    {
        XPosition = x;
        YPosition = y;
    }
    public int XPosition { get; set; }
    public int YPosition { get; set; }

    /// <summary>
    /// Dependent on 1 based array!
    /// </summary>
    public string ChessBoardNotation
    {
        get { return Char.ConvertFromUtf32(64 + XPosition) + YPosition.ToString(); }
    }

    public override string ToString()
    {
        return ChessBoardNotation;
    }
}