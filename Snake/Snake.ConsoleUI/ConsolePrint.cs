using Snake.Core;

namespace Snake.ConsoleUI;

public class ConsolePrint : IBoardPrinter
{
    public void Print(Cell[,]? board)
    {
        if (board is null)
        {
            return;
        }

        Console.Clear();

        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                Console.ForegroundColor = ChooseColor(board[row, col]);
                Console.Write(" ■ ");
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    private static ConsoleColor ChooseColor(Cell cell) =>
        cell switch
        {
            Cell.Snake => ConsoleColor.Green,
            Cell.Apple => ConsoleColor.Red,
            Cell.Empty => ConsoleColor.White,
            _ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null),
        };
}
