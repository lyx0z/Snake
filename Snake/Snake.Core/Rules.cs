namespace Snake.Core
{
    public static class Rules
    {
        public static bool IsOutOfBounds(Position nextHead, Cell[,] board)
        {
            var isRowInside = nextHead.Row >= 0 && nextHead.Row < board.GetLength(0);
            var isColInside = nextHead.Col >= 0 && nextHead.Col < board.GetLength(1);

            return !isRowInside || !isColInside;
        }

        public static bool EatAndSpawnApple(Position nextHead, Board boardClass, Cell[,] board)
        {
            if (board[nextHead.Row, nextHead.Col] == Cell.Apple)
            {
                board[nextHead.Row, nextHead.Col] = Cell.Snake;
                boardClass.SpawnApple();
                return true;
            }

            return false;
        }
    }
}
