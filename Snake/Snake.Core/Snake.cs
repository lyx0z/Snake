namespace Snake.Core;

public class Snake
{
    private Position head = new(6, 7);
    private List<Position> body = [new(6, 5), new(6, 6)];

    private IReadOnlyList<Position> GetPositions()
    {
        return [.. body, head];
    }

    public Position GetNextHead(Direction direction)
    {
        return direction switch
        {
            Direction.Right => head with { Col = head.Col + 1 },
            Direction.Left => head with { Col = head.Col - 1 },
            Direction.Up => head with { Row = head.Row - 1 },
            Direction.Down => head with { Row = head.Row + 1 },
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    private void MoveTo(Position nextHead, bool didEat)
    {
        body.Add(head);
        head = nextHead;
        if (!didEat)
        {
            body.RemoveAt(0);
        }
    }

    public void UpdateSnake(Board boardClass, Snake snake)
    {
        MoveTo(
            GetNextHead(Game.direction),
            IsEating(snake.GetNextHead(Game.direction), boardClass.GetBoard())
        );
        boardClass.SetSnake(snake.GetPositions());
    }

    public void SpawnNewAppleAfterEating(Board boardClass, Snake snake)
    {
        if (IsEating(snake.GetNextHead(Game.direction), boardClass.GetBoard()))
        {
            boardClass.SpawnApple();
        }
    }

    public bool IsEatingSelf()
    {
        return body.Contains(GetNextHead(Game.direction));
    }

    private static bool IsEating(Position nextHead, Cell[,] board)
    {
        if (board[nextHead.Row, nextHead.Col] == Cell.Apple)
        {
            board[nextHead.Row, nextHead.Col] = Cell.Snake;
            return true;
        }

        return false;
    }
}
