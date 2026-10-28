namespace Snake.Core;

public static class Rules
{
    private static int row;
    private static int col;
    private static List<Position> ValidPositions = [];

    public static List<Position> FindValidPos(Cell[,] board)
    {
        for (row = 0; row < board.GetLength(0); row++)
        {
            for (col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] != Cell.Snake)
                {
                    var validPos = new Position(row, col);
                    ValidPositions.Add(validPos);
                }
            }
        }

        return ValidPositions;
    }

    public static Position PickRandomCell(Cell[,] board)
    {
        ValidPositions = FindValidPos(board);
        var rnd = new Random();
        var validPosition = ValidPositions[rnd.Next(0, ValidPositions.Count)];
        return validPosition;
    }
}
