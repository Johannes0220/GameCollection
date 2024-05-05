namespace GameCollection.Games.VierGewinnt;

public class ConnectFourBlockBot : IConnectFourBot
{
    private ConnectFourRandomBot _randomBot = new ConnectFourRandomBot();
    public int getMove(IBoard board, int move)
    {
        switch(CheckForThree(board, move)){

            case Direction.HORIZONTAL:
                return move + 1;
            case Direction.VERTICAL: 
                return move;
            case Direction.POSTIVESLOPE:
                return move + 1;
            case Direction.NEGATIVESLOPE:
                return move - 1;
            case Direction.NOMATCH:
                return _randomBot.getMove(board, move);
            default: return 0;
        }
        //Vertical
        //&& board[_i + 1, move.J] == null && !(board[_i + 1, move.J - 1] is null)

    }

    private Direction CheckForThree(IBoard board, int move)
    {
        var row = board.GetFillStateColumn(move);
        bool player = true;
        { // horizontal
            int inARow = 0;
            for (int _i = 0; _i < board.width; _i++)
            {
                inARow = board.board[_i, row] == player ? inARow + 1 : 0;
                if (inARow >= 3) return Direction.HORIZONTAL;
            }
        }
        { // vertical
            int inARow = 0;
            for (int _j = 0; _j < board.height; _j++)
            {
                inARow = board.board[move, _j] == player ? inARow + 1 : 0;
                if (inARow >= 3) return Direction.VERTICAL;
            }
        }
        { // postive slope diagonal
            int inARow = 0;
            int min = Math.Min(move, row);
            for (int _i = move - min, _j = row - min; _i < board.width && _j < board.height; _i++, _j++)
            {
                inARow = board.board[_i, _j] == player ? inARow + 1 : 0;
                if (inARow >= 3) return Direction.POSTIVESLOPE;
            }
        }
        { // negative slope diagonal
            int inARow = 0;
            int offset = Math.Min(move, board.height - (row + 1));
            for (int _i = move - offset, _j = row + offset; _i < board.width && _j >= 0; _i++, _j--)
            {
                inARow = board.board[_i, _j] == player ? inARow + 1 : 0;
                if (inARow >= 3) return Direction.NEGATIVESLOPE;
            }
        }
        return Direction.NOMATCH;
    }
}

enum Direction
{
    HORIZONTAL,
    VERTICAL,
    POSTIVESLOPE,
    NEGATIVESLOPE,
    NOMATCH

}


