namespace Snake.Core;

public static class Rules
{
    private static int row = 5;
    private static int col = 5;
    public static Cell[,] SpawnFood(Board boardClass, bool isAppleOnBoard)
    {
        var board = boardClass.GetBoard();
       
        if(!isAppleOnBoard)
        {
            var rnd = new Random();
            row = rnd.Next(board.GetLength(0));
            col = rnd.Next(board.GetLength(1));
            board[row, col] = Cell.Apple;
        }
        else
        {
            board[row, col] = Cell.Apple;
        }

        return board;
    }
}
