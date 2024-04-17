using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;

public class HangmanView
{
    private readonly int _delayMainMenu = 3000;
    private readonly int _delayDeathAnimation = 200;

    public void GameStates(string currentWord, int incorrectGuesses)
    {
        Console.Clear();
        Console.WriteLine($"Hangman Game - Incorrect Guesses: {incorrectGuesses}");
        Console.WriteLine();
        Console.WriteLine($"Current Word: {currentWord}");
        Console.WriteLine();
    }

    public void DisplayLinesForGuess(int incorrectGuesses, HangmanRenders renders)
    {
        Console.WriteLine(renders.Renders[incorrectGuesses]);
        Console.WriteLine("Enter your guess (a-z):");
    }

    public void DisplayWinMessage(string randomWord)
    {
        Console.CursorVisible = false;
        Console.WriteLine(" ");
        Console.WriteLine($"Congratulations the word is '{randomWord}'! You won!");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
        Console.CursorVisible = true;
    }

    public void DisplayDeathAnimation(HangmanRenders renders)
    {
        Console.CursorVisible = false;
        Console.Clear();
        foreach (var frame in renders.DeathAnimation)
        {
            Console.WriteLine(" ");
            Console.WriteLine(frame);
            Thread.Sleep(_delayDeathAnimation);
            Console.Clear();
        }
    }

    public void DisplayLossMessage()
    {
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("Sorry, you lost.");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
        Console.CursorVisible = true;
    }

    public char GetUserGuess()
    {
        return Console.ReadKey().KeyChar;
    }
}
