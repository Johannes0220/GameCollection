﻿using System.Xml.Linq;

namespace GameCollection.Games._2048;

public class Game2048View
{
    public void Render(int?[,] board, int score)
    {
        int horizontal = board.GetLength(0) * 8;
        string horizontalBar = new string('═', horizontal);
        string horizontalSpace = new string(' ', horizontal);

        Console.SetCursorPosition(0, 0);
        Console.WriteLine("2048");
        Console.WriteLine();
        Console.WriteLine($"╔{horizontalBar}╗");
        Console.WriteLine($"║{horizontalSpace}║");
        for (int i = board.GetLength(1) - 1; i >= 0; i--)
        {
            Console.Write("║");
            for (int j = 0; j < board.GetLength(0); j++)
            {
                Console.Write("  ");
                ConsoleColor background = Console.BackgroundColor;
                ConsoleColor foreground = Console.ForegroundColor;
                Console.BackgroundColor = GetColor(board[i, j]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(board[i, j]?.ToString().PadLeft(4) ?? "    ");
                Console.BackgroundColor = background;
                Console.ForegroundColor = foreground;
                Console.Write("  ");
            }
            Console.WriteLine("║");
            Console.WriteLine($"║{horizontalSpace}║");
        }
        Console.WriteLine($"╚{horizontalBar}╝");
        Console.WriteLine($"Score: {score}");
    }

    private static ConsoleColor GetColor(int? value)
    {
        if (value is null)
            return ConsoleColor.DarkGray;

        int index = (int)Math.Log(value.Value, 2) - 1;
        ConsoleColor[] colors =
        {
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
        };
        return colors[index % colors.Length];
    }

    public void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Game Over...");
        Console.WriteLine();
        Console.WriteLine("Play Again [enter], or quit [escape]?");
        while (true)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    return;
                case ConsoleKey.Escape:
                    Close();
                    return;
                default:
                    continue;
            }
        }
    }

    public void ClearConsole()
    {
        Console.CursorVisible = false;
        Console.Clear();
    }

    public void Close()
    {
        Console.Clear();
        Console.WriteLine("2048 was closed.");
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
}
