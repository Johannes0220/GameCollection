namespace GameCollection.Games.FlappyBird;

public class FlappyBirdView
{
    private const int PipeGapHeight = 6;
    private readonly int _delayMainMenu = 3000;

    public void Render(FlappyBird flappyBird)
    {
        Console.Clear();
        if (flappyBird.GameState == FlappyBirdGameState.Play)
        {
            RenderBird(flappyBird.BirdX, flappyBird.BirdY);
            RenderPipes(flappyBird.Pipes);
            RenderScore(flappyBird.Score);
        }
        else if (flappyBird.GameState == FlappyBirdGameState.GameOver)
        {
            GameOver(flappyBird.Score);
        }
    }

    private void RenderBird(float birdX, float birdY)
    {
        Console.SetCursorPosition((int)birdX, (int)birdY);
        Console.Write("~(^')>");
    }

    private void RenderPipes(List<(int X, int GapY)> pipes)
    {
        foreach (var (X, GapY) in pipes)
        {
            if (X >= 0 && X < Console.WindowWidth)
            {
                for (int y = 0; y < Math.Min(GapY, Console.WindowHeight); y++)
                {
                    Console.SetCursorPosition(X, y);
                    Console.Write("████");
                }

                for (int y = Math.Max(0, GapY); y < Math.Min(GapY + PipeGapHeight, Console.WindowHeight); y++)
                {
                    if (y < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(X, y);
                        Console.Write(" ");
                    }
                }

                for (int y = Math.Max(0, GapY + PipeGapHeight); y < Console.WindowHeight; y++)
                {
                    Console.SetCursorPosition(X, y);
                    Console.Write("████");
                }
            }
        }
    }

    private void RenderScore(int score)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write("Score: " + score);
    }

    public FlappyBirdUserAction GetUserAction()
    {
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    return FlappyBirdUserAction.Flap;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return FlappyBirdUserAction.Quit;
                }
            }
        }
    }

    public void StartMessage()
    {
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("Press the Spacebar to start or Escape to quit");
    }

    public void GameOver(int score)
    {
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("Gameover... Score: " + score);
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
    }

    public void ClearConsole()
    {
        Console.CursorVisible = false;
        Console.Clear();
    }

    public void Close()
    {
        Console.Clear();
        Console.WriteLine("Flappy Bird was closed.");
        Thread.Sleep(_delayMainMenu);
        Console.CursorVisible = true;
        Console.Clear();
    }
}
