using GameCollection.User;

namespace Test.User;

public class UserRepositoryMock:IUserRepository
{

    private Dictionary<Guid, GameCollection.User.User> _users;

    public UserRepositoryMock()
    {
        _users = new Dictionary<Guid, GameCollection.User.User>();
    }
    public List<GameCollection.User.User> GetAllUsers()
    {
        var users = _users.Values;


        return users.Cast<GameCollection.User.User>().ToList(); ;
    }

    public GameCollection.User.User GetUserById(Guid id)
    {
        return _users[id];
    }

    public GameCollection.User.User CreateUser(string name)
    {
        var user = new GameCollection.User.User(Guid.NewGuid(), name);
        _users.Add(user.Id, user);
        return user;
    }

    public GameCollection.User.User UpdateUser(GameCollection.User.User user)
    {
        if (GetUserById(user.Id) is not null)
        {
            _users.Remove(user.Id);
            _users.Add(user.Id, user);
        }
        return user;
    }
}