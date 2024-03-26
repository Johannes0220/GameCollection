using GameCollection.User;
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

            //Act
            _userRepository = new UserRepository(testUserFile);

            //Test
            Assert.IsTrue(File.Exists(testUserFile.FullName));

            //Cleanup
            Directory.Delete(testUserFile.DirectoryName, true);

        }
    }
}