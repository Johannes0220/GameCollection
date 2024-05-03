namespace GameCollection.User;

public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(Guid id);
    User CreateUser(string name);
    User UpdateUser(User user);
}