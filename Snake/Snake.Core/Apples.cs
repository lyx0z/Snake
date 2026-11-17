namespace Snake.Core;

public static class Apples
{
    public static bool Eat(Position nextHead, Cell[,] board)
    {
        if (board[nextHead.Row, nextHead.Col] == Cell.Apple)
        {
            board[nextHead.Row, nextHead.Col] = Cell.Snake;
            return true;
        }

        return false;
    }
}
