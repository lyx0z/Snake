namespace Snake.Core;

public class Board
{
    private static List<Position> validPositions = [];
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

    private List<Position> FindValidPos()
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] != Cell.Snake)
                {
                    var validPos = new Position(row, col);
                    validPositions.Add(validPos);
                }
            }
        }

        return validPositions;
    }

    private Position PickRandomCell()
    {
        validPositions = FindValidPos();
        var rnd = new Random();
        var validPosition = validPositions[rnd.Next(0, validPositions.Count)];
        return validPosition;
    }

    public void SpawnApple()
    {
        var validPosition = PickRandomCell();
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

    public bool IsOutOfBounds(Position nextHead)
    {
        var isRowInside = nextHead.Row >= 0 && nextHead.Row < board.GetLength(0);
        var isColInside = nextHead.Col >= 0 && nextHead.Col < board.GetLength(1);

        return !isRowInside || !isColInside;
    }
}
