using System.Reflection;
using System.Text;

using GameCollection.User;
using Newtonsoft.Json;
using Utils;

namespace Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private static readonly DirectoryInfo _rootPath = new(Environment.CurrentDirectory);
        private FileInfo testUserFile = new FileInfo(Path.Combine(_rootPath.FullName,"\\Test\\User.json"));


        [TestMethod]
        public void TestInitUserPersistationIfNotExisting()
        {
            //setup
            try
            {
                Directory.Delete(testUserFile.DirectoryName, true);
            }
            catch (Exception)
            {

            }

            //Act
            var _userRepository = new UserRepository(testUserFile, new CustomJsonSerializer());

            //Test
            Assert.IsTrue(File.Exists(testUserFile.FullName));

            //clean up
            Directory.Delete(testUserFile.DirectoryName, true);

        }

        [TestMethod]
        public void TestInitUserPersistationIfExisting()
        {
            //Setup
            Directory.CreateDirectory(testUserFile.DirectoryName);
            using var file = File.Create(testUserFile.FullName);
            file.Close();
            var guid = Guid.NewGuid();
            var name = "someName";
            var user = new GameCollection.User.User(guid,name);
            var users = new Dictionary<Guid,GameCollection.User.User>();
            users.Add(user.Id, user);
            var writer = new StringWriter();
            var serializer=new JsonSerializer();
            serializer.Serialize(writer,users);
            
            var usersJson=writer.ToString();
            File.WriteAllText(testUserFile.FullName, usersJson);

            //Act
            var _userRepository = new UserRepository(testUserFile, new CustomJsonSerializer());

            //Test
            Assert.IsTrue(File.Exists(testUserFile.FullName));
            var testUser = _userRepository.GetUserById(guid);
            Assert.IsTrue(testUser.Id.Equals(guid));
            Assert.IsTrue(testUser.Name.Equals(name));

            //Cleanup
            Directory.Delete(testUserFile.DirectoryName, true);

        }
    }
}