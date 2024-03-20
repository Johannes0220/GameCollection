using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using GameCollection.User;

public class Bootstrapper
{
    private static UserRepository _userRepository;
    private static DirectoryInfo rootPath = new DirectoryInfo(Environment.CurrentDirectory);
    private static DirectoryInfo storagePath = new DirectoryInfo(Path.Combine(rootPath.FullName,"storage"));

    private static DirectoryInfo localUserPath =new DirectoryInfo(Path.Combine(storagePath.FullName,"users"));
    private static void Main(string[] args)
    {
        InitializeUserRepository();
    }

    private static void InitializeUserRepository()
    {
        _userRepository = new UserRepository(new FileInfo(Path.Combine(localUserPath.FullName,"Users.json")));
    }
}