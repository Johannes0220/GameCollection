using System.Text;
using System.Text.Json;

namespace GameCollection.User
{
    internal class UserRepository
    {
        private FileInfo _userFile;
        private User[] _users;
        
        public UserRepository(FileInfo userFile)
        {
            _userFile = userFile;
            InitUserPersistation();
        }

        private void InitUserPersistation()
        {
            if(File.Exists(_userFile.FullName))
            {
                ReadUsersFromFile();
                return;
            }

            try
            {
            Directory.CreateDirectory(_userFile.Directory.FullName);
            using var file=File.Create(_userFile.FullName);
            file.WriteAsync(Encoding.UTF8.GetBytes("[]"));
            file.Close();
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
                this._users= JsonSerializer.Deserialize<User[]>(usersString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public UserRepository(User[] users, FileInfo userFile) { }

        private void WriteUsersToFile()
        {
            try
            {
                var usersJson = JsonSerializer.Serialize(this._users);
                File.WriteAllText(this._userFile.FullName,usersJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
