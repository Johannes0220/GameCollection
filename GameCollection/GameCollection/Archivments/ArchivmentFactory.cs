using System.Collections;
using GameCollection.Games;
using GameCollection.Games._2048;
using System.Linq;
using GameCollection.Games.FlappyBird;
using GameCollection.Games.GuessTheNumber;
using GameCollection.Games.Hangman;
using GameCollection.Games.Snake;
using GameCollection.Games.TicTacToe;
using GameCollection.Games.TowerOfHanoi;
using GameCollection.Games.VierGewinnt;
using GameCollection.Archivments.Trackable;

namespace GameCollection.Archivements;

public class ArchivmentFactory : IArchivmentFactory
{
    private Dictionary<Type, List<Type>> _archivments;
    private readonly IGameRepository _gameRepository;

    public ArchivmentFactory(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
        _archivments = new();
        MapGames();
        MapArchivments();
    }

    public List<IArchivable> GetArchivmentsForGame(Type game)
    {
        var archivmentTypes = new List<Type>();
        _archivments.TryGetValue(game, out archivmentTypes);

        var archivments = new List<IArchivable>();
        foreach (var archivment in archivmentTypes)
        {
            archivments.Add((IArchivable)Activator.CreateInstance(archivment));
        }

        return archivments;

    }
    private void MapArchivments()
    {
        _archivments[typeof(Game2048Controller)].Add(typeof(TimePlayed));
        _archivments[typeof(FlappyBirdController)].Add(typeof(TimePlayed));
        _archivments[typeof(GuessTheNumberController)].Add(typeof(TimePlayed));
        _archivments[typeof(HangmanGameController)].Add(typeof(TimePlayed));
        _archivments[typeof(MemoryController)].Add(typeof(TimePlayed));
        _archivments[typeof(SnakeController)].Add(typeof(TimePlayed));
        _archivments[typeof(TicTacToeController)].Add(typeof(TimePlayed));
        _archivments[typeof(TowerOfHanoiController)].Add(typeof(TimePlayed));
        _archivments[typeof(ConnectFourController)].Add(typeof(TimePlayed));
    }

    private void MapGames()
    {
        var games = _gameRepository.GetAllGames();
        foreach (Type game in games)
        {
            _archivments.Add(game, new List<Type>());
        }
    }

}                  