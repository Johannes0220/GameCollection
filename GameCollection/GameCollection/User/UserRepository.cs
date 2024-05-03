using System.Collections;
using System.Net;
using System.Text;
using System.Text.Json;
using GameCollection.Archivements;
using Utils;


namespace GameCollection.User
{
    public class UserRepository : IUserRepository
    {
        private readonly FileInfo _userFile;
        private readonly ICustomJsonSerializer _jsonSerializer;
        //private List<User> _users;
        private Dictionary<Guid, User> _users;
        public UserRepository(FileInfo userFile, ICustomJsonSerializer jsonSerializer)
        {
            //_users = new List<User>();
            _users=new Dictionary<Guid, User>();
            _userFile = userFile;
            _jsonSerializer = jsonSerializer;
            InitUserPersistation();
        }

        public List<User> GetAllUsers()

        {
            var users = _users.Values;
            
            
            return users.Cast<User>().ToList(); ;
        }

        public User GetUserById(Guid id)
        {

            var user=_users[id];

            throw new FileNotFoundException("User does not Exist");
        }

        public User CreateUser(string name)
        {

            var user=new User(Guid.NewGuid(), name);
            _users.Add(user.Id,user);
            WriteUsersToFile();
            return user;
        }

        public User UpdateUser(User user)
        {
            

            if (GetUserById(user.Id) is not null)
            {
                _users.Remove(user.Id);
                _users.Add(user.Id, user);
            }
            WriteUsersToFile();
            return user;
        }
        private void InitUserPersistation()
        {
            if (File.Exists(_userFile.FullName))
            {
                ReadUsersFromFile();
                return;
            }

            try
            {
                Directory.CreateDirectory(_userFile.Directory.FullName);
                using var file = File.Create(_userFile.FullName);
                file.Close();
                WriteUsersToFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            ReadUsersFromFile();

        }

        private void ReadUsersFromFile()
        {
            try
            {
                var usersString = File.ReadAllText(this._userFile.FullName);
                this._users =_jsonSerializer.Deserialize<Dictionary<Guid, User>>(usersString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        private void WriteUsersToFile()
        {
            try
            {
                var usersJson = _jsonSerializer.Serialize(this._users);
                File.WriteAllText(this._userFile.FullName, usersJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
