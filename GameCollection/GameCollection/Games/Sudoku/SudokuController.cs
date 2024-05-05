using GameCollection.Games.Snake;

namespace GameCollection.Games.Sudoku;

public class SudokuController:IPlayable
{
    private Sudoku _sudoku;
    private SudokuView _view;
    private SudokuGameState _gameState;
    private readonly string _name = "Sudoku";
    private readonly Guid _guid = Guid.NewGuid();

    public SudokuController()
    {
        _sudoku = new Sudoku();
        _view = new SudokuView();
        _gameState = SudokuGameState.Ongoing;
    }

    public IGameResult StartGame()
    {
        int x = 0;
        int y = 0;

        while (_gameState != SudokuGameState.CloseRequested)
        {
            Console.Clear();
            _sudoku = new Sudoku();
            int?[,] generatedBoard = _sudoku.GeneratedBoard;
            int?[,] activeBoard = _sudoku.ActiveBoard;

            _gameState = SudokuGameState.Ongoing;

            while (_gameState == SudokuGameState.Ongoing)
            {
                Console.Clear();
                _view.DisplayBoard(activeBoard, generatedBoard);
                _view.DisplayInstructions();
                Console.SetCursorPosition((y * 2) + (y / 3) * 2 + 2, x + 3 + (x / 3));

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        x = (x <= 0) ? 8 : x - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        x = (x >= 8) ? 0 : x + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        y = (y <= 0) ? 8 : y - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        y = (y >= 8) ? 0 : y + 1;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (_sudoku.IsValidMove(1, x, y))
                            activeBoard[x, y] = 1;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (_sudoku.IsValidMove(2, x, y))
                            activeBoard[x, y] = 2;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (_sudoku.IsValidMove(3, x, y))
                            activeBoard[x, y] = 3;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (_sudoku.IsValidMove(4, x, y))
                            activeBoard[x, y] = 4;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        if (_sudoku.IsValidMove(5, x, y))
                            activeBoard[x, y] = 5;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        if (_sudoku.IsValidMove(6, x, y))
                            activeBoard[x, y] = 6;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        if (_sudoku.IsValidMove(7, x, y))
                            activeBoard[x, y] = 7;
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        if (_sudoku.IsValidMove(8, x, y))
                            activeBoard[x, y] = 8;
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        if (_sudoku.IsValidMove(9, x, y))
                            activeBoard[x, y] = 9;
                        break;

                    case ConsoleKey.Backspace:
                    case ConsoleKey.Delete:
                        activeBoard[x, y] = generatedBoard[x, y];
                        break;

                    case ConsoleKey.End:
                        _gameState = SudokuGameState.Ongoing; 
                        break;
                    case ConsoleKey.Escape:
                        _gameState = SudokuGameState.CloseRequested; 
                        break;
                }

                if (!_sudoku.ContainsNulls())
                {
                    _gameState = SudokuGameState.Win;
                }
            }

            if (_gameState == SudokuGameState.Win)
            {
                _view.DisplayWinMessage();
            }
        }

        _view.DisplayGameOverMesssage();
        //return new ScoreGameResult(_snake.GetSnakeLength());
        //return new WonGameResult(true);
        return null;
    }

    public string GetName()
    {
        return _name;
    }
}
