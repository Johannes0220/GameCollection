using System.Dynamic;

namespace GameCollection.Games.VierGewinnt;

public class ConnectFour
{
    Exception? exception = null;

    public Board board { get; set; }
    public bool player1Turn { get; set; }
    (int column, int row) move = default;
    public void InitGame()
    {
        player1Turn = true;
        board = new Board();
        board.InitBoard();
    }


    //TODO: Adjust Code to Board-Type
    //TODO: Make BlockBot work
    //TODO: Test Difficulty Choose & Block Bot



    public bool CheckFor4()
    {
        bool player = board.board[move.column, move.row]!.Value;
        { // horizontal
            int inARow = 0;
            for (int _column = 0; _column < board.width; _column++)
            {
                inARow = board.board[_column, move.row] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        { // vertical
            int inARow = 0;
            for (int _row = 0; _row < board.height; _row++)
            {
                inARow = board.board[move.column, _row] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        { // postive slope diagonal
            int inARow = 0;
            int min = Math.Min(move.column, move.row);
            for (int _column = move.column - min, _row = move.row - min; _column < board.width && _row < board.height; _column++, _row++)
            {
                inARow = board.board[_column, _row] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        { // negative slope diagonal
            int inARow = 0;
            int offset = Math.Min(move.column, board.height - (move.row + 1));
            for (int _column = move.column - offset, _row = move.row + offset; _column < board.width && _row >= 0; _column++, _row--)
            {
                inARow = board.board[_column, _row] == player ? inARow + 1 : 0;
                if (inARow >= 4) return true;
            }
        }
        return false;
    }

    public bool CheckForDraw()
    {
        for (int column = 0; column < board.width; column++)
        {
            if (!board.board[column, board.height - 1].HasValue)
            {
                return false;
            }
        }
        return true;
    }

    public void SetInput(int column)
    {
        var row=board.GetFillStateColumn(column);
        move = (column, row);
        board.board[column, row] = player1Turn;
    }

    public void SwitchPlayer()
    {
        player1Turn = !player1Turn;
    }
}