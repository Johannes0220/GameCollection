namespace GameCollection.Games.GuessTheNumber;

public class GuessTheNumberController:IPlayable
{
    private readonly GuessTheNumber _guessTheNumber;
    private readonly GuessTheNumberView _guessTheNumberView;
    private readonly string _name = "GuessTheNumber";
    private readonly Guid _guid = Guid.NewGuid();

    public GuessTheNumberController(GuessTheNumber guessTheNumber, GuessTheNumberView guessTheNumberView)
    {
        _guessTheNumber = guessTheNumber;
        _guessTheNumberView = guessTheNumberView;
    }

    public void StartGame()
    {
        var guess = 0;
        while (!_guessTheNumber.CheckGuess(guess))
        {
            guess = _guessTheNumberView.AskPlayerGuess();
            if (_guessTheNumber.CheckGuess(guess))
            {
                _guessTheNumberView.DisplayRight();
                _guessTheNumberView.DisplayExitMessage();
            }
            else
            {
                _guessTheNumberView.DisplayWrong();
                _guessTheNumberView.DisplayHint(_guessTheNumber.GetHint(guess));
            }
        }
    }

    public string getName()
    {
        return _name;
    }
}
