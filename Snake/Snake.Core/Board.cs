namespace Snake.Core;

public class Board
{
    private readonly Cell[,] board = new Cell[16, 16];
    private readonly Random random = new();
    public Position applePosition { get; private set; }

    public Board(IReadOnlyList<Position> snake)
    {
        SpawnApple(snake);
    }

    private List<Position> FindValidPos(IReadOnlyList<Position> snake)
    {
        var validPositions = new List<Position>();
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                var position = new Position(row, col);
                if (!snake.Contains(position))
                {
                    validPositions.Add(position);
                }
            }
        }
        return validPositions;
    }

    private Position PickRandomCell(IReadOnlyList<Position> snake)
    {
        var validPositions = FindValidPos(snake);
        return validPositions[random.Next(0, validPositions.Count)];
    }

    public void SpawnApple(IReadOnlyList<Position> snake)
    {
        applePosition = PickRandomCell(snake);
    }

    public bool IsOutOfBounds(Position nextHead)
    {
        var isRowInside = nextHead.Row >= 0 && nextHead.Row < board.GetLength(0);
        var isColInside = nextHead.Col >= 0 && nextHead.Col < board.GetLength(1);

        return !isRowInside || !isColInside;
    }

    public Cell[,] GenerateNextFrame(IReadOnlyList<Position> snake)
    {
        var nextBoard = new Cell[16, 16];
        nextBoard[applePosition.Row, applePosition.Col] = Cell.Apple;
        foreach (var part in snake)
        {
            nextBoard[part.Row, part.Col] = Cell.Snake;
        }

        return nextBoard;
    }
}
