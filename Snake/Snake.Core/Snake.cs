namespace Snake.Core;

public class Snake(IInputReader inputReader)
{
    private Direction direction = Direction.Right;
    private Position head = new(6, 7);
    private List<Position> body = [new(6, 5), new(6, 6)];

    public IReadOnlyList<Position> GetPositions()
    {
        return [.. body, head];
    }

    private void MoveDirection(Direction currentDirection)
    {
        body.Add(head);
        head = currentDirection switch
        {
            Direction.Right => head with { Col = head.Col + 1 },
            Direction.Left => head with { Col = head.Col - 1 },
            Direction.Up => head with { Row = head.Row - 1 },
            Direction.Down => head with { Row = head.Row + 1 },
            _ => throw new ArgumentOutOfRangeException(
                nameof(currentDirection),
                currentDirection,
                null
            ),
        };
        body.RemoveAt(0);
    }

    public void UpdateSnake(Board boardClass, Snake snake)
    {
        direction = inputReader.ReadDirection(direction);
        boardClass.ClearSnake();
        snake.MoveDirection(direction);
        boardClass.SetSnake(snake.GetPositions());
    }
}
