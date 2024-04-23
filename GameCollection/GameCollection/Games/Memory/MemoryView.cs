using System.Globalization;

namespace GameCollection.Games.Memory;

public class MemoryView
{
    public void Render(Tile[,] board, (int Row, int Column) selection, (int Row, int Column)? firstSelection, (int Row, int Column)? secondSelection)
    {
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine();
        Console.WriteLine(" Memory");
        Console.WriteLine();
        Console.WriteLine();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            Console.Write("  ");
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(' ');
                if (firstSelection is not null && secondSelection is not null &&
                    (firstSelection == (i, j) || secondSelection == (i, j)))
                {
                    var (a, b) = (firstSelection.Value, secondSelection.Value);
                    if (board[a.Row, a.Column].Value == board[b.Row, b.Column].Value)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                }
                else if (firstSelection == (i, j) || secondSelection == (i, j))
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                else if (selection == (i, j))
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                else if (board[i, j].Visible)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }

                if (board[i, j].Visible)
                {
                    if (board[i, j].Value < 10)
                    {
                        Console.Write('0');
                    }

                    Console.Write(board[i, j].Value.ToString(CultureInfo.InvariantCulture));
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write("  ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine(" Controls...");
        Console.WriteLine(" - arrow keys: change selction");
        Console.WriteLine(" - enter: confirm & acknowledge");
    }

    public void EnsureConsoleSize(int minWidth, int minHeight)
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        while ((width < minWidth || height < minHeight))
        {
            Console.Clear();
            Console.WriteLine("Increase console size and press [enter]...");
            bool enter = false;
            while (!enter)
            {
                var key = Console.ReadKey(true).Key;
                if (ConsoleKey.Enter.Equals(key))
                {
                    enter = true;
                }
            }

            width = Console.WindowWidth;
            height = Console.WindowHeight;
            Console.Clear();
        }
    }

    public (int, int) GetSelection(Tile[,] board, (int,int)? firstSelection)
    {
        (int Row, int Column) selection = (0, 0);
        while (true)
        {
            Render(board, selection, firstSelection,null);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:
                    selection = (selection.Row, selection.Column == board.GetLength(1) - 1 ? 0 : selection.Column + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    selection = (selection.Row, selection.Column is 0 ? board.GetLength(1) - 1 : selection.Column - 1);
                    break;
                case ConsoleKey.UpArrow:
                    selection = (selection.Row is 0 ? board.GetLength(0) - 1 : selection.Row - 1, selection.Column);
                    break;
                case ConsoleKey.DownArrow:
                    selection = (selection.Row == board.GetLength(0) - 1 ? 0 : selection.Row + 1, selection.Column);
                    break;
                case ConsoleKey.Enter:
                    if (!board[selection.Row, selection.Column].Visible)
                    {
                        board[selection.Row, selection.Column].Visible = true;
                        if (firstSelection is null)
                        {
                            return selection;
                        }
                        if (firstSelection != selection)
                        {
                            return selection;
                        }
                    }
                    break;
            }
        }
    }
    public void RenderControls()
    {
        Console.WriteLine();
        Console.WriteLine(" Controls...");
        Console.WriteLine(" - arrow keys: change selection");
        Console.WriteLine(" - enter: confirm & acknowledge");
        Console.WriteLine(" - escape: exit");
    }

    public void RenderWinMessage()
    {
        Console.WriteLine();
        Console.WriteLine(" You Win!");
        Console.WriteLine(" Play again [enter] or exit [escape]?");
    }

    public static void RenderConsoleSizeMessage()
    {
        Console.Clear();
        Console.WriteLine("Increase console size and press [enter]...");
    }

    public void WaitForConfirmation()
    {
        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
        } while (!key.Equals(ConsoleKey.Enter));
    }
}
