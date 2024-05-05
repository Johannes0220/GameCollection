namespace GameCollection.Games._2048;

public class Game2048Controller:IPlayable
{
    private Game2048 _game;
    private readonly Game2048View _game2048View;
    public static readonly string Name = "Game 2048";
    private readonly Guid _guid = Guid.NewGuid();

    public Game2048Controller()
    {
        _game = new Game2048();
        _game2048View = new Game2048View();
    }

    public IGameResult StartGame()
    {
        _game.GenerateNewTile();
        while (true)
        {
            _game2048View.ClearConsole();
            _game2048View.Render(_game.GetBoard(), _game.GetScore());

            if (_game.IsGameOver())
            {
                _game2048View.GameOver();
                break;
            }

            var key = Console.ReadKey(true).Key;
            //var key = _game2048View.GetKey();
            Game2048Direction direction;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    direction = Game2048Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Game2048Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    direction = Game2048Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Game2048Direction.Right;
                    break;
                case ConsoleKey.Escape:
                    _game2048View.Close();
                    return new ScoreGameResult(_game.GetScore());
                default:
                    continue;
            }

            if (_game.TryMove(direction)){}
                _game.GenerateNewTile();
        }
        return new ScoreGameResult(_game.GetScore());
    }


}
