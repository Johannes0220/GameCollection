//using GameCollection.Archivements;

//namespace Test.Archivments;

//[TestClass]
//public class TimePlayedTest
//{
//    [TestMethod]
//    public void StartTracking_SetsStartTime()
//    {
//        // Arrange
//        var timePlayed = new TimePlayed();

//        // Act
//        timePlayed.StartTracking();

//        // Assert
//        Assert.IsTrue(timePlayed.StartTime > DateTime.MinValue);
//    }

//    [TestMethod]
//    public void StopTracking_AddsElapsedTime()
//    {
//        // Arrange
//        var timePlayed = new TimePlayed();
//        timePlayed.StartTracking();
//        var startTime = timePlayed.StartTime;

//        // Act
//        System.Threading.Thread.Sleep(1000); // Simulate time passing
//        timePlayed.StopTracking();

//        // Assert
//        Assert.IsTrue(timePlayed.TimePlayed > TimeSpan.Zero);
//        Assert.IsTrue(timePlayed.TimePlayed > (DateTime.UtcNow - startTime));
//    }

//    [TestMethod]
//    public void GetLevel_ReturnsCorrectLevel()
//    {
//        // Arrange
//        var timePlayed = new TimePlayed();
//        timePlayed.StartTracking();
//        System.Threading.Thread.Sleep(2000); // Simulate time passing
//        timePlayed.StopTracking();

//        // Act
//        var level = timePlayed.GetLevel();

//        // Assert
//        Assert.AreEqual(2, level);
//    }

//    [TestMethod]
//    public void GetLevel_ReturnsZeroIfNoTimePlayed()
//    {
//        // Arrange
//        var timePlayed = new TimePlayed();

//        // Act
//        var level = timePlayed.GetLevel();

//        // Assert
//        Assert.AreEqual(0, level);
//    }
//}