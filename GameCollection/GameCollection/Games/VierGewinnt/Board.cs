namespace GameCollection.Games.VierGewinnt;

public class Board : IBoard
{
    public bool?[,] board { get; set; }
    public int height { get; set; }
    public int width { get; set; }

    public void InitBoard()
    {
        board = new bool?[7, 6];
        width = board.GetLength(0);
        height = board.GetLength(1);
        for (int column = 0; column < board.GetLength(0); column++)
        {
            for (int row = 0; row < board.GetLength(1); row++)
            {
                board[column, row] = null;
            }
        }
    }

    public void DropPiece(int column, bool player)
    {
        int row = GetFillStateColumn(column);
        if (row != -1)
        {
            board[column, row] = player;
        }
        else
        {
            // Column is full, handle accordingly (throw exception, ignore, etc.)
            throw new InvalidOperationException("Column is full.");
        }
    }

    public void RemovePiece(int column)
    {
        int row = GetFillStateColumn(column) + 1; // Get the row above the last filled one
        if (row < height)
        {
            board[column, row] = null;
        }
        else
        {
            // No piece to remove, handle accordingly (throw exception, ignore, etc.)
            throw new InvalidOperationException("No piece to remove.");
        }
    }

    public bool IsColumnFull(int column)
    {
        return GetFillStateColumn(column) == -1;
    }

    public int GetFillStateColumn(int column)
    {
        for (int row = 0; row <= height - 1; row++)
        {
            if (board[column, row] == null)
            {
                return row;
            }
        }
        return -1; // Column is full
    }
}