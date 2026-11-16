namespace Snake.Core;

public class Snake(IInputReader inputReader)
{
    private Direction direction = Direction.Right;
    private Position head = new(6, 7);
    private List<Position> body = [new(6, 5), new(6, 6)];

    private IReadOnlyList<Position> GetPositions()
    {
        return [.. body, head];
    }

    public Position GetNextHead()
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
        direction = inputReader.ReadDirection(direction);

        var nextHead = GetNextHead();

        boardClass.ClearSnake();

        var didEat = Rules.EatAndSpawnApple(snake.GetNextHead(), boardClass, boardClass.GetBoard());
        MoveTo(nextHead, didEat);
        boardClass.SetSnake(snake.GetPositions());
    }
}
