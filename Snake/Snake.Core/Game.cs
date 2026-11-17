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
            if (boardClass.IsOutOfBounds(snake.GetNextHead(direction)) || snake.IsEatingSelf())
            {
                boardPrinter.TriggerGameOver();
                Thread.Sleep(3000);
                Start();
            }
            boardClass.ClearSnake();
            snake.CheckIfEatingAndSpawnApple(boardClass, snake);
            snake.UpdateSnake(boardClass, snake);
            boardPrinter.Print(boardClass.GetBoard());
        }
    }
}
