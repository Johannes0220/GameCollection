namespace GameCollection.Games.TicTacToe;

public class TicTacToeController:IPlayable
{
    private readonly TicTacToe _ticTacToe;
    private readonly TicTacToeView _ticTacToeView;
    private readonly string _name = "TicTacToe";
    private readonly Guid _guid = Guid.NewGuid();

    public TicTacToeController(TicTacToe ticTacToe, TicTacToeView ticTacToeView)
    {
        _ticTacToe = ticTacToe;
        _ticTacToeView = ticTacToeView;
    }

    public void StartGame()
    {
        char currentPlayer = 'X';
        while (!_ticTacToe.IsBoardFull())
        {
            _ticTacToeView.PrintBoard(_ticTacToe);
            int move = _ticTacToeView.GetPlayerMove(currentPlayer);
            if (_ticTacToe.IsValidMove(move))
            {
                _ticTacToe.MakeMove(move, currentPlayer);
                if (_ticTacToe.IsWinner(currentPlayer))
                {
                    _ticTacToeView.PrintBoard(_ticTacToe);
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    return;
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
        Console.WriteLine("It's a tie!");
    }

    public string getName()
    {
        return _name;
    }
}
