﻿using System.Collections;
using System.Text;
using System.Text.Json;
using Utils;


namespace GameCollection.User
{
    public class UserRepository
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
            //foreach (var user in _users)
            //{
            //    if (user.Id.Equals(id))
            //    {
            //        return user;
            //    }
            //}


            throw new FileNotFoundException("User does not Exist");
        }

        public User CreateUser(string name)
        {

            var user=new User(Guid.NewGuid(), name);
            _users.Add(user.Id,user);
            WriteUsersToFile();
            return user;
        }

        public User UpdateUser(Guid id, string name)
        {
            User user;
            try
            {
                user=GetUserById(id);
            }
            catch
            {
                throw new FileNotFoundException("This user does not Exist!");
            }
            _users.Remove(user.Id);

            var newUser = new User(id, name);
            _users.Add(newUser.Id, newUser);
            WriteUsersToFile();
            return newUser;
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
