using Snake.Core;

namespace Snake.ConsoleUI;

public class ConsolePrint : IBoardPrinter
{
    public void Print(Board.Cell[,]? board)
    {
        if (board is null)
            return;

        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                Console.ForegroundColor = ChooseColor(board[row, col]);
                Console.Write(" ■ ");
            }
            Console.WriteLine();
        }
        Thread.Sleep(500);
        Console.Clear();
        Console.ResetColor();
    }

    private static ConsoleColor ChooseColor(Board.Cell cell)
    {
        switch (cell)
        {
            case Board.Cell.Snake:
                return ConsoleColor.Green;
            case Board.Cell.Apple:
                return ConsoleColor.Red;
            case Board.Cell.Empty:
            default:
                return ConsoleColor.White;
        }
    }
}
