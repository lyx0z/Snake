namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private bool isRunning = true;

    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake(inputReader);
        boardClass.SpawnApple();
        while (isRunning)
        {
            snake.UpdateSnake(boardClass, snake);
            boardPrinter.Print(boardClass.GetBoard());
            Thread.Sleep(800);
            if (Rules.IsOutOfBounds(snake.GetNextHead(), boardClass.GetBoard()))
            {
                boardPrinter.TriggerGameOver();
                isRunning = false;
            }
        }
    }
}
