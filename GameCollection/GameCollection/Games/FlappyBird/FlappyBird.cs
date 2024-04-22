namespace GameCollection.Games.FlappyBird;

public class FlappyBird
{
    private const float Gravity = .5f;
    private const int PipeWidth = 8;
    private const int PipeGapHeight = 6;
    private const int SpaceBetweenPipes = 45;
    public FlappyBirdGameState GameState { get; set; }
    public int Score { get; private set; }
    public List<(int X, int GapY)> Pipes { get { return pipes; } }
    public float BirdX { get { return birdX; } }
    public float BirdY { get { return birdY; } }
    private List<(int X, int GapY)> pipes;
    private float birdX;
    private float birdY;
    private float birdDY;

    public FlappyBird()
    {
        pipes = new List<(int X, int GapY)>();
        GameState = FlappyBirdGameState.Play;
        Score = 0;
        birdX = 10;
        birdY = Console.WindowHeight / 2;
        birdDY = 0;
    }

    public void Update()
    {
        if (GameState != FlappyBirdGameState.Play)
            return;

        birdDY += Gravity;
        birdY += birdDY;

        UpdatePipes();

        if (IsBirdCollidingWithPipe() || IsBirdOutOfBound())
        {
            GameState = FlappyBirdGameState.GameOver;
        }

        foreach (var pipe in pipes)
        {
            if (pipe.X + PipeWidth / 2 == (int)birdX)
            {
                Score++;
                break;
            }
        }
    }

    public void Flap()
    {
        birdDY = -1;
        birdY -= 1;  
    }

    private bool IsBirdCollidingWithPipe()
    {
        foreach (var (X, GapY) in pipes)
        {
            if (birdX + 5 >= X && birdX <= X + PipeWidth && (birdY <= GapY || birdY >= GapY + PipeGapHeight))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsBirdOutOfBound()
    {
        bool outOfBounds = birdY >= Console.WindowHeight || birdY < 0;
        return outOfBounds;
    }

    private void UpdatePipes()
    {
        int maxPipeX = Console.WindowWidth - PipeWidth / 2;

        for (int i = 0; i < pipes.Count; i++)
        {
            pipes[i] = (pipes[i].X - 1, pipes[i].GapY);
        }

        pipes.RemoveAll(p => p.X + PipeWidth / 2 < 0);

        if (pipes.Count == 0 || pipes[pipes.Count - 1].X <= maxPipeX - SpaceBetweenPipes)
        {
            int gapY = new Random().Next(0, Console.WindowHeight - PipeGapHeight - 1 - 6) + 3;
            pipes.Add((maxPipeX, gapY));
        }
    }

}
