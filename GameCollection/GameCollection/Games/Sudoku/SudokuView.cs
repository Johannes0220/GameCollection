namespace GameCollection.Games.Sudoku;

using System;

public class SudokuView
{
    private readonly int _delayMainMenu = 3000;

    public void DisplayBoard(int?[,] board, int?[,] lockedBoard)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine("╔═══════╦═══════╦═══════╗");
        for (int i = 0; i < 9; i++)
        {
            Console.Write("║ ");
            for (int j = 0; j < 9; j++)
            {
                if (lockedBoard[i, j] is not null)
                {
                    Console.Write((lockedBoard[i, j].HasValue ? lockedBoard[i, j].ToString() : "■") + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write((board[i, j].HasValue ? board[i, j].ToString() : "■") + " ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (j is 2 or 5)
                {
                    Console.Write("║ ");
                }
            }
            Console.WriteLine("║");

            if (i is 2 or 5)
            {
                Console.WriteLine("╠═══════╬═══════╬═══════╣");
            }
        }
        Console.WriteLine("╚═══════╩═══════╩═══════╝");

        Console.ForegroundColor = originalColor;
    }

    public void DisplayInstructions()
    {
        Console.WriteLine("Sudoku");
        Console.WriteLine();
        Console.WriteLine("Press arrow keys to select a cell.");
        Console.WriteLine("Press 1-9 to insert values.");
        Console.WriteLine("Press [delete] or [backspace] to remove.");
        Console.WriteLine("Press [escape] to exit.");
        Console.WriteLine("Press [end] to generate a new sudoku.");
    }

    public void DisplayWinMessage()
    {
        Console.Clear();
        Console.WriteLine("Sudoku");
        Console.WriteLine();
        Console.WriteLine("You Win!");
        Console.WriteLine();
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
        Console.CursorVisible = true;
    }

    public void ShowGameOver()
    {
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("Gameover...");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
    }
}
