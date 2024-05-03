using GameCollection.User;

namespace Test.User;

[TestClass]
public class UserServiceTest
{

    [TestMethod]
    public void TestCreateUser()
    {
        //Arrange
        var service = new UserService(new UserRepositoryMock());
        //Act
        var user = service.CreateUser("TestUser");
        //Assert
        Assert.AreEqual(user.Name, "TestUser");
    }

    [TestMethod]
    public void TestUpdateUser()
    {
        //Arrange
        var service = new UserService(new UserRepositoryMock());
        var user = service.CreateUser("TestUser");
        //Act
        user.Name = "TestUser2";
        var updatedUser=service.UpdateUser(user);
        //Assert
        Assert.AreEqual(updatedUser.Name, "TestUser2");
    }

}