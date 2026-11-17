namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    public static Direction direction = Direction.Right;
    private bool isRunning = true;

    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake();
        boardClass.SpawnApple();
        while (isRunning)
        {
            direction = inputReader.ReadDirection(direction);
            Thread.Sleep(400);
            if (
                Board.IsOutOfBounds(snake.GetNextHead(direction), boardClass.GetBoard())
                || snake.IsEatingSelf()
            )
            {
                boardPrinter.TriggerGameOver();
                Thread.Sleep(3000);
                Start();
            }
            snake.UpdateSnake(boardClass, snake);
            boardPrinter.Print(boardClass.GetBoard());
        }
    }
}
