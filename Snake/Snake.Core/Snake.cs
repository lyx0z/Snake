namespace Snake.Core;

public class Snake
{
    private Position head = new Position(6, 9);
    private List<Position> body = [];

    public Snake()
    {
        for (var col = 5; col < 9; col++)
        {
            body.Add(new Position(6, col));
        }
    }

    public IReadOnlyList<Position> GetPositions()
    {
        return [.. body, head];
    }

    public void MoveDirection(Direction currentDirection)
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
}
