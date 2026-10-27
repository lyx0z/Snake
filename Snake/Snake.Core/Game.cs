namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private Direction direction = Direction.Right;
    private bool isAppleOnBoard;

    public void Start()
    {
        var boardClass = new Board();
        var snake = new Snake();
        var board = boardClass.GetBoard();
        boardClass.SetSnake(snake.GetPositions());
        while (true)
        {
            direction = inputReader.ReadDirection(direction);
            boardClass.ClearSnake();
            snake.MoveDirection(direction);
            boardClass.SetSnake(snake.GetPositions());
            foreach (var cell in board)
            {
                if (cell == Cell.Apple)
                {
                    isAppleOnBoard = true;
                }
            }
            board = Rules.SpawnFood(boardClass, isAppleOnBoard);
            boardPrinter.Print(board);
            Thread.Sleep(800);
        }
    }
}
