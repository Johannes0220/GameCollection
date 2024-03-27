using System.Text;

using GameCollection.User;
using Newtonsoft.Json;

namespace Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private FileInfo testUserFile = new FileInfo("D:\\Test\\User.json");

        private UserRepository _userRepository;


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
            _userRepository = new UserRepository(testUserFile);

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
            var user = new User() { Id = guid, Name = name };
            var users = new LinkedList<User>(new User[] { user });
            var writer = new StringWriter();
            var serializer=new JsonSerializer();
            serializer.Serialize(writer,users);
            var usersJson=writer.ToString();
            File.WriteAllText(testUserFile.FullName, usersJson);

            //Act
            _userRepository = new UserRepository(testUserFile);

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