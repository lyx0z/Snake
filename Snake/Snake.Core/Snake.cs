namespace Snake.Core;

public class Snake
{
    private Position head = new(6, 7);
    private List<Position> body = [new(6, 5), new(6, 6)];
    private bool shouldGrow;

    public IReadOnlyList<Position> GetPositions()
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

    public void MoveTo(Position nextHead)
    {
        body.Add(head);
        head = nextHead;

        if (shouldGrow)
        {
            shouldGrow = false;
        }
        else
        {
            body.RemoveAt(0);
        }
    }

    public void Grow()
    {
        shouldGrow = true;
    }

    public bool IsEatingSelf(Position nextHead)
    {
        return body.Contains(nextHead);
    }

    public static bool IsEating(Position nextHead, Position apple)
    {
        return nextHead == apple;
    }
}
