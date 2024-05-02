using GameCollection.Games;
using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;

public class HangmanGameController:IPlayable
{
    private readonly Hangman _hangman;
    private readonly HangmanView _hangmanView;
    private readonly HangmanRenders _hangmanRenders;
    private readonly string _name = "Hangman";
    private readonly Guid _guid = Guid.NewGuid();

    public HangmanGameController()
    {
        _hangman = new Hangman();
        _hangmanView = new HangmanView();
        _hangmanRenders = new HangmanRenders();
    }

    public void StartGame()
    {
        while (_hangman.State == HangmanGameState.InProgress)
        {
            string currentWord = _hangman.GetRevealedWord();
            HangmanGameState state = _hangman.State;
            int incorrectGuesses = _hangman._incorrectGuesses;
            _hangmanView.GameStates(currentWord, incorrectGuesses);
            _hangmanView.DisplayLinesForGuess(incorrectGuesses, _hangmanRenders);
            
            var guess = _hangmanView.GetUserGuess();
            _hangman.Guess(guess);
        }

        string randomWord = _hangman.GetRandomWord();

        switch (_hangman.State)
        {
            case HangmanGameState.Won:
                _hangmanView.DisplayWinMessage(randomWord);
                break;
            case HangmanGameState.Lost:
                _hangmanView.DisplayDeathAnimation(_hangmanRenders);
                _hangmanView.DisplayLossMessage();
                break;
        }
    }

    public string GetName()
    {
        return _name;
    }
}
