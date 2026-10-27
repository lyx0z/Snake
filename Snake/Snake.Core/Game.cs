namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter)
{
    private Direction direction = Direction.Right;
    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake();
        boardClass.SetSnake(snake.GetPositions());
        while (true)
        {
            if (Console.KeyAvailable)
            {
                direction = Rules.MoveTo(Console.ReadKey(true).Key, direction);
            }
            boardClass.ClearSnake();
            snake.MoveDirection(direction);
            
            boardClass.SetSnake(snake.GetPositions());
            boardPrinter.Print(boardClass.GetBoard());
            Thread.Sleep(800);
        }
    }
}
