namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private Direction direction = Direction.Right;

    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake();
        boardClass.SetSnake(snake.GetPositions());
        while (true)
        {
            direction = inputReader.ReadDirection(direction);
            boardClass.ClearSnake();
            snake.MoveDirection(direction);

            boardClass.SetSnake(snake.GetPositions());
            boardPrinter.Print(boardClass.GetBoard());
            Thread.Sleep(800);
        }
    }
}
