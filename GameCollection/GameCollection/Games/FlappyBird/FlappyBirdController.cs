namespace GameCollection.Games.FlappyBird;

public class FlappyBirdController : IPlayable
{
    private readonly FlappyBird _flappyBird;
    private readonly FlappyBirdView _flappyBirdView;
    private readonly Guid _guid = Guid.NewGuid();
    public static readonly string Name = "Flappy Bird";
    public FlappyBirdController()
    {
        _flappyBird = new FlappyBird();
        _flappyBirdView = new FlappyBirdView();
    }

    public IGameResult StartGame()
    {
        _flappyBird.GameState = FlappyBirdGameState.Play;

        _flappyBirdView.Render(_flappyBird);
        _flappyBirdView.StartMessage();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    break;  
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    _flappyBirdView.Close();
                    return new ScoreGameResult(_flappyBird.Score);
                }
            }

            Thread.Sleep(50);
        }

        while (_flappyBird.GameState == FlappyBirdGameState.Play)
        {
            _flappyBird.Update();
            _flappyBirdView.Render(_flappyBird);

            if (Console.KeyAvailable)
            {
                FlappyBirdUserAction action = _flappyBirdView.GetUserAction();
                if (action == FlappyBirdUserAction.Flap)
                {
                    _flappyBird.Flap();
                }
                else if (action == FlappyBirdUserAction.Quit)
                {
                    _flappyBird.GameState = FlappyBirdGameState.Quit;
                }
            }

            Thread.Sleep(100); 
        }

        if (_flappyBird.GameState == FlappyBirdGameState.Quit)
        {
            _flappyBirdView.Close();
        }
        else
        {
            _flappyBirdView.GameOver(_flappyBird.Score);
        }

        return new ScoreGameResult(_flappyBird.Score);
    }
}