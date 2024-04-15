using System.Dynamic;

namespace GameCollection.Games.VierGewinnt;

public class ConnectFour
{
    Exception? exception = null;

    public bool?[,] board;
    public bool player1Turn { get; set; }
    (int I, int J) move = default;
    public void InitGame()
    {
        player1Turn = true;
        board = new bool?[7, 6];
        ResetBoard();
    }



    public void ResetBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = null;
            }
        }
    }

    public bool CheckFor4()
    {
        bool player = board[move.I, move.J]!.Value;
        { // horizontal
            int inARow = 0;
            for (int _i = 0; _i < board.GetLength(0); _i++)
            {
                inARow = board[_i, move.J] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        { // vertical
            int inARow = 0;
            for (int _j = 0; _j < board.GetLength(1); _j++)
            {
                inARow = board[move.I, _j] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        { // postive slope diagonal
            int inARow = 0;
            int min = Math.Min(move.I, move.J);
            for (int _i = move.I - min, _j = move.J - min; _i < board.GetLength(0) && _j < board.GetLength(1); _i++, _j++)
            {
                inARow = board[_i, _j] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        { // negative slope diagonal
            int inARow = 0;
            int offset = Math.Min(move.I, board.GetLength(1) - (move.J + 1));
            for (int _i = move.I - offset, _j = move.J + offset; _i < board.GetLength(0) && _j >= 0; _i++, _j--)
            {
                inARow = board[_i, _j] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        return false;
    }

    public bool CheckForDraw()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (!board[i, board.GetLength(1) - 1].HasValue)
            {
                return false;
            }
        }
        return true;
    }

    public void SetInput(int i)
    {
        for (int j = board.GetLength(1) - 1; ; j--)
        {
            if (j is 0 || board[i, j - 1].HasValue)
            {
                board[i, j] = player1Turn;
                move = (i, j);
                break;
            }
        }
    }

    public void SwitchPlayer()
    {
        player1Turn = !player1Turn;
    }
}