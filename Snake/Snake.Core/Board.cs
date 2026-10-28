namespace Snake.Core;

public class Board
{
    private readonly Cell[,] board = new Cell[16, 16];

    public Cell[,] GetBoard()
    {
        return (Cell[,])board.Clone();
    }

    public void SetSnake(IReadOnlyList<Position> positions)
    {
        foreach (var position in positions)
        {
            board[position.Row, position.Col] = Cell.Snake;
        }
    }

    public void SpawnApple()
    {
        var validPosition = Rules.PickRandomCell(board);
        board[validPosition.Row, validPosition.Col] = Cell.Apple;
    }

    public void ClearSnake()
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Cell.Snake)
                {
                    board[row, col] = Cell.Empty;
                }
            }
        }
    }
}
