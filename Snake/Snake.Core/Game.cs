namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter)
{
    public void Start()
    {
        var boardClass = new Board();
        while (true)
        {
            boardPrinter.Print(boardClass.GetBoard());
            Thread.Sleep(500);
        }
    }
}
