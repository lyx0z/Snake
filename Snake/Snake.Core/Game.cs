namespace Snake.Core;

public class Game(IBoardPrinter boardPrinter, IInputReader inputReader)
{
    private Direction direction = Direction.Right;
    private bool running = true;

    public void Start()
    {
        var snake = new Snake();
        var board = new Board(snake.GetPositions());

        running = true;

        while (running)
        {
            direction = inputReader.ReadDirection(direction);
            var nextHead = snake.GetNextHead(direction);

            if (board.IsOutOfBounds(nextHead) || snake.IsEatingSelf(nextHead))
            {
                GameOver();
                continue;
            }

            if (Snake.IsEating(nextHead, board.applePosition))
            {
                snake.Grow();
                board.SpawnApple(snake.GetPositions());
            }

            snake.MoveTo(nextHead);
            boardPrinter.Print(board.GenerateNextFrame(snake.GetPositions()));
            Thread.Sleep(400);
        }
    }

    private void GameOver()
    {
        running = false;
        boardPrinter.PrintGameOver();
        if (inputReader.ReadKeyGameOver())
        {
            direction = Direction.Right;
            Start();
        }
    }
}
