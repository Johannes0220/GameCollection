using System.Numerics;

internal class Program
{
    private static List<string> gameList = new List<string>();
    private static void Main(string[] args)
    {
        InitGameList();
        DisplayMainMenu();

    }

    private static void DisplayMainMenu()
    {
        Console.WriteLine("Choose the game you'd like to play!");

        for (int i = 0; i < gameList.Count; i++)
        {
            Console.WriteLine("\t" + i + ". " + gameList[i]);
        }

        ReadInput();
    }

    private static void ReadInput()
    {
        var valid = false;
        var input = "Keine Eingabe";
        while (!valid)
        {
            Console.Write("Enter the Number of your Game: ");
            input = Console.ReadLine();
            valid = CheckValid(input);
        }

        StartMiniGame(input);
    }

    private static void StartMiniGame(string? input)
    {
        Console.WriteLine(gameList[int.Parse(input)] + " wird gestartet!");
    }

    private static void InitGameList()
    {
        gameList.Add("Chess (Player vs. Player)");
        gameList.Add("MineSweeper");
        gameList.Add("Tic Tac Toe (Player vs. Player or Bot)");
        gameList.Add("Hangman");
    }

    private static bool CheckValid(string input)
    {
        var inputNum = 0;        
        try
        {
            inputNum = int.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(input + " is Not a Number");
            return false;
        }

        if (inputNum >=0 && inputNum < gameList.Count)
        {
            return true;
        }

        Console.WriteLine(inputNum + " is not in the List");
        return false;

    }
}