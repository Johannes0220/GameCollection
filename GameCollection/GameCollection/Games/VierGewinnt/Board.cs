namespace GameCollection.Games.VierGewinnt;

public class Board
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

    public int GetFillStateColumn(int column)
    {
        for (int row = height - 1; ; row--)
        {
            if (row is 0 || board[column, row - 1].HasValue)
            {
                return row;
            }
        }
    }
}