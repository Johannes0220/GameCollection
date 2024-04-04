using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using GameCollection.Controller;
using GameCollection.Games;
using GameCollection.User;
using Utils;

public class Bootstrapper
{
    private static UserRepository _userRepository;
    private static GameRepository _gameRepository;
    private static readonly DirectoryInfo _rootPath = new(Environment.CurrentDirectory);
    private static readonly DirectoryInfo _storagePath = new(Path.Combine(_rootPath.FullName,"storage"));
    private static readonly DirectoryInfo _localUserPath =new (Path.Combine(_storagePath.FullName,"users"));

    private static void Main(string[] args)
    {
        InitializeRepositories();
        var mainController = new MainController(_gameRepository,_userRepository);
        mainController.RunGameCollection();
    }

    private static void InitializeRepositories()
    {
        var jsonSerializer = new CustomJsonSerializer();
        _userRepository = new UserRepository(new FileInfo(Path.Combine(_localUserPath.FullName,"Users.json")),jsonSerializer);
        _gameRepository = new GameRepository();
    }
}