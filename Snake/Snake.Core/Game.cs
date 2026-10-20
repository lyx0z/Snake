namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter)
{
    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake();
        boardClass.SetCell(snake.GetPositions());
        while (true)
        {
            boardPrinter.Print(boardClass.GetBoard());
            Thread.Sleep(500);
        }
    }
}
