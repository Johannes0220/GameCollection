namespace GameCollection.Games.GuessTheNumber;

public class GuessTheNumberController:IPlayable
{
    private readonly GuessTheNumber _guessTheNumber;
    private readonly GuessTheNumberView _guessTheNumberView;
    private readonly string _name = "GuessTheNumber";
    private readonly Guid _guid = Guid.NewGuid();


    public GuessTheNumberController()
    {
        _guessTheNumber= new GuessTheNumber();
        _guessTheNumberView= new GuessTheNumberView();
    }
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
            }
            else
            {
                _guessTheNumberView.DisplayWrong(guess);
                _guessTheNumberView.DisplayHint(_guessTheNumber.GetHint(guess));
            }
        }
    }

    public string getName()
    {
        return _name;
    }
}
