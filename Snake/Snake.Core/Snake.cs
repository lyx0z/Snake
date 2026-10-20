namespace Snake.Core;

public class Snake
{
    public void SpawnSnake(Board board)
    {
        for (var col = 5; col <= 9; col++)
        {
            board.SetCell(7, col, Cell.Snake);
        }
    }
}
