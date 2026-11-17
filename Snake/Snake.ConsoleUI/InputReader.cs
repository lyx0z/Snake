using Snake.Core;

namespace Snake.ConsoleUI;

public class InputReader : IInputReader
{
    public Direction ReadDirection(Direction currentDirection)
    {
        return !Console.KeyAvailable
            ? currentDirection
            : GetDirection(Console.ReadKey(true).Key, currentDirection);
    }

    public bool ReadKeyGameOver()
    {
        return Console.ReadKey(true).Key == ConsoleKey.Spacebar;
    }

    private static Direction GetDirection(ConsoleKey key, Direction current) =>
        key switch
        {
            ConsoleKey.W or ConsoleKey.UpArrow when current != Direction.Down => Direction.Up,
            ConsoleKey.S or ConsoleKey.DownArrow when current != Direction.Up => Direction.Down,
            ConsoleKey.A or ConsoleKey.LeftArrow when current != Direction.Right => Direction.Left,
            ConsoleKey.D or ConsoleKey.RightArrow when current != Direction.Left => Direction.Right,
            _ => current,
        };
}
