namespace GameCollection.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
       _userRepository = userRepository;
    }
    public List<User> GetAllUsers()
    {
       return _userRepository.GetAllUsers();
    }

    public User GetUserById(Guid id)
    {
        return _userRepository.GetUserById(id);
    }

    public User CreateUser(string name)
    {
        return _userRepository.CreateUser(name);
    }

    public User UpdateUser(User user)
    {
        return _userRepository.UpdateUser(user);
    }
}