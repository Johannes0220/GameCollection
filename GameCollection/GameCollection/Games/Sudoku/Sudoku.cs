namespace GameCollection.Games.Sudoku;

using System;

public class Sudoku
{
    public int?[,] GeneratedBoard { get; private set; }
    public int?[,] ActiveBoard { get; private set; }

    public Sudoku()
    {
        GeneratedBoard = Generate();
        ActiveBoard = (int?[,])GeneratedBoard.Clone();
    }

    public int?[,] Generate(int blanks = 30)
    {
        Random random = new Random();
        int?[,] board = new int?[9, 9];
        var valids = InitializeValids();

        GenerateBoard(board, valids, random);

        InsertBlanks(board, random, blanks);

        return board;
    }

    private (int[] Values, int Count)[,] InitializeValids()
    {
        var valids = new (int[] Values, int Count)[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                valids[i, j] = (new int[9], 0);
            }
        }
        return valids;
    }

    private void GenerateBoard(int?[,] board, (int[] Values, int Count)[,] valids, Random random)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                valids[i, j].Count = 0;

                for (int value = 1; value <= 9; value++)
                {
                    if (IsValueValid(value, board, i, j))
                    {
                        valids[i, j].Values[valids[i, j].Count++] = value;
                    }
                }

                while (valids[i, j].Count == 0) 
                {
                    if (j == 0) 
                    {
                        j = 8; 
                    }
                    else
                    {
                        j--;
                    }

                    if (i < 0 || i >= 9 || j < 0 || j >= 9)
                    {
                        throw new InvalidOperationException("Ungültiger Index bei Rückschritt.");
                    }

                    board[i, j] = null;
                }

                int randomIndex = random.Next(0, valids[i, j].Count);

                int selectedValue = valids[i, j].Values[randomIndex];

                valids[i, j].Values[randomIndex] = valids[i, j].Values[valids[i, j].Count - 1];
                valids[i, j].Count--;

                board[i, j] = selectedValue;
            }
        }
    }

    private bool IsValueValid(int value, int?[,] board, int row, int col)
    {
        return IsSquareValid(value, board, row, col) && IsRowValid(value, board, row) && IsColumnValid(value, board, col);
    }

    private bool IsSquareValid(int value, int?[,] board, int row, int col)
    {
        int rowStart = (row / 3) * 3;
        int colStart = (col / 3) * 3;

        for (int i = rowStart; i < rowStart + 3; i++)
        {
            for (int j = colStart; j < colStart + 3; j++)
            {
                if (board[i, j] == value)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private bool IsRowValid(int value, int?[,] board, int row)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i] == value)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsColumnValid(int value, int?[,] board, int col)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i, col] == value)
            {
                return false;
            }
        }
        return true;
    }

    private void InsertBlanks(int?[,] board, Random random, int blanks)
    {
        foreach (int index in random.NextUnique(blanks, 0, 81))
        {
            int row = index / 9;
            int column = index % 9;
            board[row, column] = null;
        }
    }

    public bool IsValidMove(int value, int x, int y)
    {
        if (GeneratedBoard[x, y] is not null)
        {
            return false;
        }

        for (int i = 0; i < 9; i++)
        {
            if (ActiveBoard[x, i] == value || ActiveBoard[i, y] == value)
            {
                return false;
            }
        }

        int rowStart = (x / 3) * 3;
        int colStart = (y / 3) * 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (ActiveBoard[rowStart + i, colStart + j] == value)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool ContainsNulls()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (ActiveBoard[i, j] is null)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
