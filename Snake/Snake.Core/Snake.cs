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
        var nextHead = GetNextHead(Game.direction);

        boardClass.ClearSnake();

        var didEat = Apples.Eat(snake.GetNextHead(Game.direction), boardClass.GetBoard());
        if (didEat)
        {
            boardClass.SpawnApple();
        }
        MoveTo(nextHead, didEat);
        boardClass.SetSnake(snake.GetPositions());
    }

    public bool IsEatingSelf()
    {
        return body.Contains(GetNextHead(Game.direction));
    }
}
