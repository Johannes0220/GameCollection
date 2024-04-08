using System.Globalization;
using GameCollection.Views;

namespace GameCollection.Games.TowerOfHanoi;

public class TowerOfHanoiView : BasicView
{
    public void DisplayRules()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.CursorVisible = false;
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  Tower Of Hanoi");
        Console.WriteLine();
        Console.WriteLine("  This is a puzzle game where you need to");
        Console.WriteLine("  move all the disks in the left stack to");
        Console.WriteLine("  the right stack. You can only move one");
        Console.WriteLine("  disk at a time from one stack to another");
        Console.WriteLine("  stack, and you may never place a disk on");
        Console.WriteLine("  top of a smaller disk on the same stack.");
        Console.WriteLine();
        Console.WriteLine("  press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
    }

    public int DisplayChooseDiskNumber()
    {
        Console.WriteLine();
        Console.WriteLine("  Tower Of Hanoi");
        Console.WriteLine();
        Console.WriteLine("  The more disks, the harder the puzzle.");
        Console.WriteLine();
        Console.WriteLine("  Select the number of disks:");
        Console.WriteLine("  [3] 3 disks");
        Console.WriteLine("  [4] 4 disks");
        Console.WriteLine("  [5] 5 disks");
        Console.WriteLine("  [6] 6 disks");
        Console.WriteLine("  [7] 7 disks");
        Console.WriteLine("  [8] 8 disks");
        return ReadNumericInput("", 3, 8);
    }

    public void RenderTowers(List<int>[] stacks, int disks, int minimumNumberOfMoves, int moves, TowerOfHanoiGameState state,
         int? source)
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  Tower Of Hanoi");
        Console.WriteLine();
        Console.WriteLine($"  Minimum Moves: {minimumNumberOfMoves}");
        Console.WriteLine();
        Console.WriteLine($"  Moves: {moves}");
        Console.WriteLine();
        for (int i = disks - 1; i >= 0; i--)
        {
            for (int j = 0; j < stacks.Length; j++)
            {
                Console.Write("  ");
                RenderDisk(stacks[j].Count > i ? stacks[j][i] : null,disks);
            }

            Console.WriteLine();
        }

        string towerBase = new string('─', disks) + '┴' + new string('─', disks);
        Console.WriteLine($"  {towerBase}  {towerBase}  {towerBase}");
        Console.WriteLine(
            $"  {RenderBelowBase(0, disks, source)}  {RenderBelowBase(1, disks, source)}  {RenderBelowBase(2, disks, source)}");
        Console.WriteLine();
    }

    public int DisplayChooseSource()
    {
        Console.WriteLine("  [0], [1], or [2] select source stack");
        Console.WriteLine("  [-1] give up");
        return ReadNumericInput("", -1, 2);
    }

    public int DisplayChooseTarget()
    {
        Console.WriteLine("  [0], [1], or [2] select target stack");
        Console.WriteLine("  [-1] give up");
        return ReadNumericInput("", -1, 2);
    }

    public void DisplayInvalidTarget()
    {
        Console.WriteLine("  You may not place a disk on top of a");
        Console.WriteLine("  smaller disk on the same stack.");
        Console.WriteLine();
    }

    public int DisplayWon()
    {
        Console.WriteLine("  You solved the puzzle!");
        Console.WriteLine("  [-1] return to menu");
        return ReadNumericInput("", -1, -1);
    }
    private string RenderBelowBase(int stack, int disks, int? source) =>
        stack == source
            ? new string('^', disks - 1) + $"[{(stack).ToString(CultureInfo.InvariantCulture)}]" + new string('^', disks - 1)
            : new string(' ', disks - 1) + $"[{(stack).ToString(CultureInfo.InvariantCulture)}]" + new string(' ', disks - 1);

    private void RenderDisk(int? disk, int disks)
    {
        if (disk is null)
        {
            Console.Write(new string(' ', disks) + '│' + new string(' ', disks));
        }
        else
        {
            Console.Write(new string(' ', disks - disk.Value));
            Console.BackgroundColor = disk switch
            {
                1 => ConsoleColor.Red,
                2 => ConsoleColor.Green,
                3 => ConsoleColor.Blue,
                4 => ConsoleColor.Magenta,
                5 => ConsoleColor.Cyan,
                6 => ConsoleColor.DarkYellow,
                7 => ConsoleColor.White,
                8 => ConsoleColor.DarkGray,
                _ => throw new NotImplementedException()
            };
            Console.Write(new string(' ', disk.Value));
            Console.Write('│');
            Console.Write(new string(' ', disk.Value));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(new string(' ', disks - disk.Value));
        }
    }
    public override object Show()
    {
        throw new NotImplementedException();
    }
}