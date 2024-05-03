using GameCollection.Archivements;
using GameCollection.Controller;
using GameCollection.Games.VierGewinnt;
using Test.Archivments;

namespace Test.Controller;

[TestClass]
public class ArchivmentControllerTest
{
    [TestMethod]
    public void StartTrackingTest()
    {
        //Arrange
        MockTrackable mockArchivment =new MockTrackable();
        var archivments = new List<IArchivable>();
        archivments.Add(mockArchivment);
        var factory = new MockArchivmentFactory((IArchivable)mockArchivment);
        var controller = new ArchivmentController(factory);
        var user = new GameCollection.User.User(Guid.NewGuid(), "test");
        //Act
        controller.RunArchivmentsForGame(typeof(ConnectFourController),user);

        //Assert
        Assert.IsTrue(mockArchivment.StartedTracking);
    }

    [TestMethod]
    public void StoptrackingTest()
    {
        //Arrange
        MockTrackable mockArchivment = new MockTrackable();
        var archivments = new List<IArchivable>();
        archivments.Add(mockArchivment);
        var factory = new MockArchivmentFactory((IArchivable)mockArchivment);
        var controller = new ArchivmentController(factory);
        var user = new GameCollection.User.User(Guid.NewGuid(), "test");
        controller.RunArchivmentsForGame(typeof(ConnectFourController), user);
        //Act
        controller.UpdateArchivmentsForGame(typeof(ConnectFourController), user);

        //Assert
        Assert.IsTrue(mockArchivment.StoppedTracking);
    }
}