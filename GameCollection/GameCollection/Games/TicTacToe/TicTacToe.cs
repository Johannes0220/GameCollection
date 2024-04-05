namespace GameCollection.Games.TicTacToe;

public class TicTacToe
{
    public char[] board;

    public TicTacToe()
    {
        board = new char[9];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = ' ';
        }
    }

    public bool IsWinner(char symbol)
    {
        for (int i = 0; i < 9; i += 3)
        {
            if (board[i] == symbol && board[i + 1] == symbol && board[i + 2] == symbol)
            {
                return true;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (board[i] == symbol && board[i + 3] == symbol && board[i + 6] == symbol)
            {
                return true;
            }
        }
        if ((board[0] == symbol && board[4] == symbol && board[8] == symbol) ||
            (board[2] == symbol && board[4] == symbol && board[6] == symbol))
        {
            return true;
        }
        return false;
    }

    public bool IsBoardFull()
    {
        foreach (char cell in board)
        {
            if (cell == ' ')
            {
                return false;
            }
        }
        return true;
    }

    public bool IsValidMove(int move)
    {
        return board[move] == ' ';
    }

    public void MakeMove(int move, char symbol)
    {
        if (IsValidMove(move))
        {
            board[move] = symbol;
        }
    }
}
