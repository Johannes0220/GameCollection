using GameCollection.Games;
using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;

public class HangmanGameController:IPlayable
{
    private readonly Hangman _hangman;
    private readonly HangmanGameView _hangmanView;
    private readonly HangmanRenders _hangmanRenders;
    private readonly string _name = "Hangman";
    private readonly Guid _guid = Guid.NewGuid();

    public HangmanGameController()
    {
        _hangman = new Hangman();
        _hangmanView = new HangmanGameView();
        _hangmanRenders = new HangmanRenders();
    }

    public void StartGame()
    {
        while (_hangman.State == HangmanGameState.InProgress)
        {
            string currentWord = _hangman.GetRevealedWord();
            HangmanGameState state = _hangman.State;
            int incorrectGuesses = _hangman._incorrectGuesses;

            _hangmanView.RenderGameState(currentWord, state, incorrectGuesses, _hangmanRenders);
            var guess = _hangmanView.GetUserGuess();
            _hangman.Guess(guess);
        }

        _hangmanView.RenderGameState(_hangman.GetRevealedWord(), _hangman.State, _hangman._incorrectGuesses, _hangmanRenders);
    }

    public string getName()
    {
        return _name;
    }
}
