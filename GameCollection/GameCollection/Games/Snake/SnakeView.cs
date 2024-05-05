namespace GameCollection.Games.Snake;

public class SnakeView
{
    private readonly int _delayMainMenu = 3000;

    public void StartText()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.WriteLine("Welcome to Snake!");
        Console.WriteLine(" ");
        Console.WriteLine("Please not change the size of the window after choosing the game");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
    }

    public void RenderSnakeHead(int width, int height)
    {
        Console.SetCursorPosition(width / 2, height / 2);
        Console.Write('@');
    }

    public void RenderFood(int X, int Y)
    {
        Console.SetCursorPosition(X, Y);
        Console.Write('+');
    }

    public void ClearCell(int X, int Y)
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(' ');
    }

    public void ResizeMessage()
    {
        Console.Clear();
        Console.WriteLine("Console was resized. Snake game has ended.");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
    }

    public void GameOver(int score)
    {
        Console.Clear();
        Console.WriteLine("Game Over. Score: " + score + ".");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
    }

    public void Close()
    {
        Console.Clear();
        Console.WriteLine("Snake was closed.");
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
}
