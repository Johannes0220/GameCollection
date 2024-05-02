using Microsoft.VisualBasic.CompilerServices;

namespace GameCollection.Views;

public class MainMenuView: BasicView
{
    public int ShowMainMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[0] Play a Game");
        Console.WriteLine("[1] Check Archivments");
        var input = ReadNumericInput("Enter a number form the List!", 0, 1);
        return input;
    }
}