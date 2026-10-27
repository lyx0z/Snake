using Snake.Core;

namespace Snake.ConsoleUI;

public class InputReader : IInputReader
{
    public Direction ReadDirection(Direction currentDirection)
    {
        return !Console.KeyAvailable ? currentDirection : MoveTo(Console.ReadKey(true).Key, currentDirection);
    }

    private static Direction MoveTo(ConsoleKey key, Direction currentDirection) => key switch
    {
        ConsoleKey.W or ConsoleKey.UpArrow => Direction.Up,
        ConsoleKey.D or ConsoleKey.RightArrow => Direction.Right,
        ConsoleKey.S or ConsoleKey.DownArrow => Direction.Down,
        ConsoleKey.A or ConsoleKey.LeftArrow => Direction.Left,
        _ => currentDirection,
    };
}
