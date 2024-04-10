using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;

public class HangmanGameView
{
    public void RenderGameState(string currentWord, HangmanGameState state, int incorrectGuesses, HangmanRenders renders)
    {
        int delayDeathAnimation = 200;
        int delayMainMenu = 3000;
		Console.Clear();
        Console.WriteLine($"Hangman Game - Incorrect Guesses: {incorrectGuesses}");
        Console.WriteLine();
        Console.WriteLine($"Current Word: {currentWord}");
        Console.WriteLine();

        if (incorrectGuesses < renders.Renders.Length)
        {
            Console.WriteLine(renders.Renders[incorrectGuesses]);
        }
        else
        {
            Console.WriteLine(renders.Renders[renders.Renders.Length - 1]);
        }

        Console.WriteLine("Enter your guess (a-z):");

        if (state == HangmanGameState.Won)
        {
			Console.WriteLine(" ");
            Console.WriteLine("Congratulations! You won!");
            Console.WriteLine("You will be redirected to the game selection in 3 second");
            Thread.Sleep(delayMainMenu);
            Console.Clear();
        }
        else if (state == HangmanGameState.Lost)
        {
            Console.Clear();
            foreach (var frame in renders.DeathAnimation)
			{
				Console.WriteLine(frame);
                Thread.Sleep(delayDeathAnimation);
				Console.Clear();
            }
            Console.WriteLine(" ");
            Console.WriteLine("Sorry, you lost.");
            Console.WriteLine("You will be redirected to the game selection in 3 seconds");
            Thread.Sleep(delayMainMenu);
			Console.Clear();
        }
    }

    public char GetUserGuess()
    {
        return Console.ReadKey().KeyChar;
    }
}
