namespace GameCollection.Games.GuessTheNumber;

public class GuessTheNumberView
{
    private readonly int _delayMainMenu = 3000;

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
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
    }

    public void DisplayWrong(int guess)
    {
        Console.Clear();
        Console.WriteLine($"{guess} is incorrect. Try again!");
    }

    public void DisplayHint(string hint)
    {
        Console.WriteLine($"Hint: {hint}");
    }

    public void DisplayExitMessage()
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
        Console.Clear();
    }
}