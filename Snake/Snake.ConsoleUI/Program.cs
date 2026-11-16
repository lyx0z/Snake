namespace Snake.ConsoleUI;

using Core;

public static class Program
{
    private static Game game = new(new ConsolePrint(), new InputReader());

    public static void Main()
    {
        game.Start();
    }

    public static Game GetGame()
    {
        return game;
    }
}
