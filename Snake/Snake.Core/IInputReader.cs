namespace Snake.Core;

public interface IInputReader
{
    Direction ReadDirection(Direction currentDirection);
}
