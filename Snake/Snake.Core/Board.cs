namespace Snake.Core;

public class Board
{
    public enum Cell
    {
        Empty,
        Snake,
        Apple,
    }

    private readonly Cell[,] board = new Cell[16, 16];

    public Cell[,]? GetBoard()
    {
        return board.Clone() as Cell[,];
    }
}
