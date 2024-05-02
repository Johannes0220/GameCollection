namespace GameCollection.Games.TicTacToe;

public class TicTacToeController:IPlayable
{
    private readonly TicTacToe _ticTacToe;
    private readonly TicTacToeView _ticTacToeView;
    private readonly string _name = "TicTacToe";
    private readonly Guid _guid = Guid.NewGuid();

    public TicTacToeController()
    {
        _ticTacToe = new TicTacToe();
        _ticTacToeView = new TicTacToeView();
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
                    _ticTacToeView.DisplayWinner(currentPlayer);
                    return;
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                _ticTacToeView.DisplayInvalidMove();
            }
        }

        _ticTacToeView.DisplayTie();
    }

    public string GetName()
    {
        return _name;
    }
}
