namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake(inputReader);
        boardClass.SpawnApple();
        while (true)
        {
            snake.UpdateSnake(boardClass, snake);
            boardPrinter.Print(boardClass.GetBoard());
            Thread.Sleep(800);
        }
    }
}
