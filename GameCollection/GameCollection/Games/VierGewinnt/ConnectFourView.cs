using GameCollection.Views;

namespace GameCollection.Games.VierGewinnt;

public class ConnectFourView: BasicView
{
    public const int moveMinI = 5;
    public const int moveJ = 2;
    public void RenderBoard(Board board)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("   ╔" + new string('-', board.width * 2 + 1) + "╗");
        Console.Write("   ║ ");
        int iOffset = Console.CursorLeft;
        int jOffset = Console.CursorTop;
        Console.WriteLine(new string(' ', board.width * 2) + "║");

        for (int j = 1; j < board.height * 2; j++)
        {
            Console.WriteLine("   ║" + new string(' ', board.width * 2 + 1) + "║");
        }

        Console.WriteLine("   ╚" + new string('═', board.width * 2 + 1) + "╝");

        int iFinal = Console.CursorLeft;
        int jFinal = Console.CursorTop;

        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                Console.SetCursorPosition(i * 2 + iOffset, (board.height - j) * 2 + jOffset - 1);
                if (board.board[i, j] == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('█');
                    Console.ResetColor();
                }
                else if (board.board[i, j] == false)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('█');
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.Write(' ');
                }
            }
        }
        Console.SetCursorPosition(iFinal, jFinal);
    }

    public int GetPlayerInput(Board board)
    {
        int i = 0;
        Console.SetCursorPosition(moveMinI, moveJ);
        Console.Write('v');
        var input = Console.ReadKey(true).Key;
        while (!input.Equals(ConsoleKey.Enter))
        {
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(i * 2 + moveMinI, moveJ);
                    Console.Write(' ');
                    i = Math.Max(0, i - 1);
                    Console.SetCursorPosition(i * 2 + moveMinI, moveJ);
                    Console.Write('v');
                    break;
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(i * 2 + moveMinI, moveJ);
                    Console.Write(' ');
                    i = Math.Min(board.width - 1, i + 1);
                    Console.SetCursorPosition(i * 2 + moveMinI, moveJ);
                    Console.Write('v');
                    break;
            }
            input=Console.ReadKey(true).Key;
        }

        if (board.board[i, board.height - 1] != null)
        {
            GetPlayerInput(board);
        }

        return i;
    }

    public void DisplayWon()
    {
        Console.WriteLine();
        Console.WriteLine("   You Win!");

    }

    public void DisplayLost()
    {
        Console.WriteLine();
        Console.WriteLine($"   You Lose!");
    }

    public void DisplayDraw()
    {
        Console.WriteLine();
        Console.WriteLine($"   Draw!");
    }

    public void DisplayReturnToGameMenu()
    {
        Console.WriteLine("   Exiting Game!!!");
    }

    public int GetDifficulty()
    {
        Console.WriteLine("Choose a Difficulty");
        Console.WriteLine("0: Easy");
        Console.WriteLine("1: Medium");
        return ReadNumericInput("", 0, 1);
    }
}