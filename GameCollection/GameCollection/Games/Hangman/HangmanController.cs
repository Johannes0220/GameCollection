﻿using GameCollection.Games;
using GameCollection.Games.Hangman;

namespace GameCollection.Games.Hangman;

public class HangmanGameController:IPlayable
{
    private readonly HangmanGame _hangmanGame;
    private readonly HangmanGameView _hangmanView;
    private readonly HangmanRenders _hangmanRenders;
    private readonly string _name = "Hangman";
    private readonly Guid _guid = Guid.NewGuid();

    public HangmanGameController()
    {
        _hangmanGame = new HangmanGame();
        _hangmanView = new HangmanGameView();
        _hangmanRenders = new HangmanRenders();
    }

    public void StartGame()
    {
        while (_hangmanGame.State == HangmanGameState.InProgress)
        {
            string currentWord = _hangmanGame.GetRevealedWord();
            HangmanGameState state = _hangmanGame.State;
            int incorrectGuesses = _hangmanGame._incorrectGuesses;

            _hangmanView.RenderGameState(currentWord, state, incorrectGuesses, _hangmanRenders);

            char guess = Console.ReadKey().KeyChar;
            _hangmanGame.Guess(guess);
        }

        _hangmanView.RenderGameState(_hangmanGame.GetRevealedWord(), _hangmanGame.State, _hangmanGame._incorrectGuesses, _hangmanRenders);
    }

    public string getName()
    {
        return _name;
    }
}
