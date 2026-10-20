namespace Snake.ConsoleUI;

public class ConsolePrint : IBoardPrinter
{
    public void BoardPrinter(bool[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                Console.WriteLine('*');
            }
        }
    }
}
