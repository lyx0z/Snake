namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter)
{
    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake();
        var rules = new Rules();
        boardClass.SetSnake(snake.GetPositions());
        while (true)
        {
            boardPrinter.Print(boardClass.GetBoard());
            boardClass.ClearSnake();
            snake.MoveDirection(rules.MoveTo(Console.ReadKey().Key));
            boardClass.SetSnake(snake.GetPositions());
        }
    }
}
