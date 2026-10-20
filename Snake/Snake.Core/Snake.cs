namespace Snake.Core;

public class Snake
{
    private readonly List<Position> positions = [];

    public Snake()
    {
        for (var col = 5; col <= 9; col++)
        {
            positions.Add(new Position(6, col));
        }
    }

    public IReadOnlyList<Position> GetPositions()
    {
        return positions;
    }
}
