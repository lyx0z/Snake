namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private Direction direction = Direction.Right;
    private bool running = true;

    public void Start()
    {
        var board = new Board();
        var snake = new Snake();
        running = true;
        direction = Direction.Right;
        board.SpawnApple();

        while (running)
        {
            direction = inputReader.ReadDirection(direction);
            var nextHead = snake.GetNextHead(direction);

            if (board.IsOutOfBounds(nextHead) || snake.IsEatingSelf(nextHead))
            {
                board.ClearSnake();
                GameOver();
                continue;
            }

            if (snake.IsEating(nextHead, board.GetBoard()))
            {
                snake.Grow();
                board.SpawnApple();
            }

            snake.MoveTo(nextHead);
            board.ClearSnake();
            board.SetSnake(snake.GetPositions());
            boardPrinter.Print(board.GetBoard());
            Thread.Sleep(400);
        }
    }

    private void GameOver()
    {
        running = false;
        boardPrinter.PrintGameOver();
        if (inputReader.ReadKeyGameOver())
        {
            Start();
        }
    }
}
