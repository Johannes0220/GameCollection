using System.ComponentModel.Design;
using System.Globalization;

namespace GameCollection.Games.Memory;

public class Memory
{
    public Tile[,] board { get; set; }
    public (int Row, int Column)? firstSelection { get; set; }
    public (int Row, int Column)? secondSelection { get; set; }

    public (int Row, int Column) selection { get; set; }
public Memory()
    {
        selection = (0, 0);
    }



    public void InitializeAndShuffleBoard(int rows, int cols)
    {
        board = new Tile[rows, cols];

        // Initialize the board array with some values
        for (int i = 0, k = 2; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++, k++)
            {
                board[i, j] = new Tile { Value = k / 2 };
            }
        }

        // Shuffle the board
        ShuffleBoard(rows, cols);
    }

    public void CheckPair((int Row, int Column) firstSelection, (int Row, int Column) secondSelection)
    {
        Tile a = board[firstSelection!.Row, firstSelection.Column];
        Tile b = board[secondSelection!.Row, secondSelection.Column];
        if (a.Value != b.Value)
        {
            a.Visible = false;
            b.Visible = false;
        }
    }

    public bool AllTilesVisible()
    {
        for (int i = 0, k = 2; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++, k++)
            {
                if (!board[i, j].Visible)
                {
                    return false;
                }
            }
        }

        return true;
    }
    private void ShuffleBoard(int rows, int cols)
    {
        Random rand = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int randomRow = rand.Next(rows);
                int randomCol = rand.Next(cols);

                // Swap the tiles
                Tile temp = board[i, j];
                board[i, j] = board[randomRow, randomCol];
                board[randomRow, randomCol] = temp;
            }
        }
    }
}

