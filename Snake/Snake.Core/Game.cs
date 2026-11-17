namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private bool isRunning = true;

    public void Start()
    {
        Console.CursorVisible = false;
        var boardClass = new Board();
        var snake = new Snake(inputReader);
        boardClass.SpawnApple();
        while (isRunning)
        {
            Thread.Sleep(400);
            if (Board.IsOutOfBounds(snake.GetNextHead(), boardClass.GetBoard()))
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
