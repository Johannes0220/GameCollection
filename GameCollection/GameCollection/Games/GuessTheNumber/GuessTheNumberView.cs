namespace GameCollection.Games.GuessTheNumber;

public class GuessTheNumberView
{
    public int AskPlayerGuess()
    {
        Console.WriteLine("Guess a number between 1-100: ");
        bool valid = int.TryParse(Console.ReadLine()?.Trim(), out int input);
        if (!valid)
        {
            Console.WriteLine("Invalid.");
            return AskPlayerGuess();
        }

        return input;
    }

    public void DisplayRight()
    {
        Console.WriteLine("You guessed it right!");
    }
    public void DisplayWrong()
    {
        Console.WriteLine("Incorrect. Try again!");
    }

    public void DisplayHint(string hint)
    {
        Console.WriteLine($"Hint: {hint}");
    }

    public void DisplayExitMessage()
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
}