namespace Snake.ConsoleUI;

using Core;

public static class Program
{
    public static void Main()
    {
        var game = new Game(new ConsolePrint(), new InputReader());
        game.Start();
    }
}
