﻿using GameCollection.Games;
using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;

public class HangmanGameController:IPlayable
{
    private readonly Hangman _hangman;
    private readonly HangmanView _hangmanView;
    private readonly HangmanRenders _hangmanRenders;
    private readonly Guid _guid = Guid.NewGuid();
    public static readonly string Name = "Hangman";
    public HangmanGameController()
    {
        _hangman = new Hangman();
        _hangmanView = new HangmanView();
        _hangmanRenders = new HangmanRenders();
    }
    public IGameResult StartGame()
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
        bool won = false;
        switch (_hangman.State)
        {
            case HangmanGameState.Won:
                _hangmanView.DisplayWinMessage(randomWord);
                won = true;
                break;
            case HangmanGameState.Lost:
                _hangmanView.DisplayDeathAnimation(_hangmanRenders);
                _hangmanView.DisplayLossMessage();
                break;
        }

        return new WinGameResult(won);
    }
}
