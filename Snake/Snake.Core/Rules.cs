namespace Snake.Core;

public class Rules
{
    public Direction MoveTo(ConsoleKey key)
    {
        var direction = key switch
        {
            ConsoleKey.W => Direction.Up,
            ConsoleKey.D => Direction.Right,
            ConsoleKey.S => Direction.Down,
            ConsoleKey.A => Direction.Left,
            _ => Direction.Right,
        };

        return direction;
    }
}
