namespace GameCollection.Games.TicTacToe;

public class TicTacToeController:IPlayable
{
    public static readonly string Name = "Tic Tac Toe";
    private readonly TicTacToe _ticTacToe;
    private readonly TicTacToeView _ticTacToeView;
    private readonly Guid _guid = Guid.NewGuid();

    public TicTacToeController()
    {
        _ticTacToe = new TicTacToe();
        _ticTacToeView = new TicTacToeView();
    }

    public IGameResult StartGame()
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
                    return new WinGameResult(true);
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                _ticTacToeView.DisplayInvalidMove();
            }
        }

        _ticTacToeView.DisplayTie();
        return new WinGameResult(false);
    }
}
