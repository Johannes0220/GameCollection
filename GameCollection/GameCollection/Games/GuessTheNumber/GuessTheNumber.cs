namespace GameCollection.Games.GuessTheNumber;

public class GuessTheNumber
{
    int value = Random.Shared.Next(1, 101);

    public bool CheckGuess(int guess)
    {
        return guess == value;
    }

    public string GetHint(int guess)
    {
        return guess < value ? "Guess is too Low" : "Guess is too High";
    }
}
