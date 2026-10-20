namespace Snake.Core;

public class Board
{
    private readonly Cell[,] board = new Cell[16, 16];

    public Cell[,] GetBoard()
    {
        return (Cell[,])board.Clone();
    }
}
