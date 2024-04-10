using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;
public class Hangman
{
    private readonly string[] _wordArray = { "hangman", "game", "rainbow", "game", "street", "germany"};
    private readonly string _randomWord;
    private readonly char[] _revealedChars;
    public int _incorrectGuesses;
    public HangmanGameState State { get; private set; }

    public Hangman()
    {
        _randomWord = _wordArray[new Random().Next(_wordArray.Length)].ToLower();
        _revealedChars = new string('_', _randomWord.Length).ToCharArray();
        State = HangmanGameState.InProgress;
    }

    public void Guess(char guess)
    {
        bool correctGuess = false;
        for (int i = 0; i < _revealedChars.Length; i++)
        {
            if (_revealedChars[i] == '_' && _randomWord[i] == guess)
            {
                _revealedChars[i] = guess;
                correctGuess = true;
            }
        }
        if (!correctGuess)
        {
            _incorrectGuesses++;
            if (_incorrectGuesses >= 6)
                State = HangmanGameState.Lost;
        }
        if (!_revealedChars.Contains('_'))
            State = HangmanGameState.Won;
    }

    public string GetRevealedWord()
    {
        return new string(_revealedChars);
    }

    public string GetRandomWord()
    {
        return new string(_randomWord);
    }
}
