using System.Text;
using System.Text.Json;



namespace GameCollection.User
{
    public class UserRepository
    {
        private FileInfo _userFile;
        private LinkedList<User> _users;
        public UserRepository(FileInfo userFile)
        {
            _users = new LinkedList<User>();
            _userFile = userFile;
            InitUserPersistation();
        }

        public User GetUserById(Guid id)
        {
            foreach (var user in _users)
            {
                if (user.Id.Equals(id))
                {
                    return user;
                }
            }

            throw new FileNotFoundException("User does not Exist");
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
                this._users =JsonSerializer.Deserialize<LinkedList<User>>(usersString);
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
                var usersJson = JsonSerializer.Serialize(this._users);
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
