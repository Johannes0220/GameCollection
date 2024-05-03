using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using GameCollection.Archivements;
using GameCollection.Controller;
using GameCollection.Games;
using GameCollection.User;
using Utils;

public class Bootstrapper
{
    private static IUserRepository _userRepository;
    private static GameRepository _gameRepository;
    private static readonly DirectoryInfo _rootPath = new(Environment.CurrentDirectory);
    private static readonly DirectoryInfo _storagePath = new(Path.Combine(_rootPath.FullName,"storage"));
    private static readonly DirectoryInfo _localUserPath =new (Path.Combine(_storagePath.FullName,"users"));
    private static ArchivmentController _archivmentController;
    private static ArchivmentFactory _archivmentFactory;
    private static IUserService _userService;

    private static void Main(string[] args)
    {
        InitializeRepositories();
        var mainController = new MainController(_gameRepository,_userService, _archivmentController);
        mainController.RunGameCollection();
    }

    private static void InitializeRepositories()
    {
        var jsonSerializer = new CustomJsonSerializer();
        _gameRepository = new GameRepository();
        _archivmentFactory = new ArchivmentFactory(_gameRepository);
        _archivmentController = new ArchivmentController(_archivmentFactory);
        _userRepository = new UserRepository(new FileInfo(Path.Combine(_localUserPath.FullName,"Users.json")),jsonSerializer);
        _userService = new UserService(_userRepository);
    }

    private static void HookToSafingLifecycle()
    {
        AppDomain.CurrentDomain.ProcessExit += new EventHandler((sender, eventArgs) =>
        {
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                _userRepository.UpdateUser(user);
            }
        });
    }
}