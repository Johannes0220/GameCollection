namespace GameCollection.Games.Snake;

public class SnakeController:IPlayable
{
    private readonly Snake _snake;
    private readonly SnakeView _snakeView;
    private readonly string _name = "Snake";
    private readonly Guid _guid = Guid.NewGuid();
    private readonly char[] _directionChars = { '^', 'v', '<', '>' };
    private bool closeRequested;
    private SnakeDirection? direction;

    public SnakeController()
    {
        _snake = new Snake(Console.WindowWidth, Console.WindowHeight);
        _snakeView = new SnakeView();
    }

    public void StartGame()
    {
        _snakeView.StartText();
        _snakeView.RenderSnakeHead(_snake.GetWidth(), _snake.GetHeight());
        var (foodX, foodY) = _snake.PositionFood();
        _snakeView.RenderFood(foodX, foodY);
        _snake.PositionSnake();
        _snake.PositionFood();

        bool firstMove = true;

        while (!_snake.GameOver() && !closeRequested)
        {
            int X = _snake.GetX();
            int Y = _snake.GetY();

            if (_snake.CheckWindowResize())
            {
                _snakeView.ResizeMessage();
                return;
            }

            if (firstMove && !Console.KeyAvailable)
            {
                Thread.Sleep(100);
                continue;
            }

            if (Console.KeyAvailable)
            {
                firstMove = false;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        direction = SnakeDirection.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = SnakeDirection.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = SnakeDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = SnakeDirection.Right;
                        break;
                    case ConsoleKey.Escape:
                        closeRequested = true;
                        break;
                }
            }

            switch (direction)
            {
                case SnakeDirection.Up:
                    Y--;
                    break;
                case SnakeDirection.Down:
                    Y++;
                    break;
                case SnakeDirection.Left:
                    X--;
                    break;
                case SnakeDirection.Right:
                    X++;
                    break;
            }

            if (_snake.CheckCollision(X, Y))
            {
                _snakeView.GameOver(_snake.GetSnakeLength());
                break;
            }

            Console.SetCursorPosition(X, Y);
            Console.Write(_directionChars[(int)direction!]);
            _snake.RenderSnakeMovement(X, Y);

            Thread.Sleep(100);
        }
    }

    public string getName()
    {
        return _name;
    }
}
