namespace Snake.Core;

public static class Rules
{
    private static int row = 5;
    private static int col = 5;

    public static Cell[,] SpawnFood(Board boardClass, bool isAppleOnBoard)
    {
        var board = boardClass.GetBoard();

        if (!isAppleOnBoard)
        {
            PickRandomCell(board);
            if (board[row, col] == Cell.Snake)
            {
                if (col + 1 >= board.GetLength(1))
                {
                    col = 0;
                }
                else
                {
                    col++;
                }
            }
        }

        board[row, col] = Cell.Apple;
        return board;
    }
    
    private static void PickRandomCell(Cell[,] board)
    {
        var rnd = new Random();
        row = rnd.Next(board.GetLength(0));
        col = rnd.Next(board.GetLength(1));
    }
}
