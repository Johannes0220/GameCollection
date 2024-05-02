using GameCollection.Games.VierGewinnt;

namespace Test.Games;

[TestClass]
public class ConnectFourTest
{
    [TestMethod]
    public void TestCheckFor4Vertical()
    {
        //Arange
        var connectFour = new ConnectFour();
        connectFour.InitGame();
        //Act
        for (int i = 0; i < 5; i++)
        {
        connectFour.SetInput(0);
        }
        //Assert
        Assert.IsTrue(connectFour.CheckFor4());
    }

    [TestMethod]
    public void TestCheckFor4Horizontal()
    {
        //Arange
        var connectFour = new ConnectFour();
        connectFour.InitGame();
        //Act
        for (int i = 0; i < 5; i++)
        {
            connectFour.SetInput(i);
        }
        //Assert
        Assert.IsTrue(connectFour.CheckFor4());
    }

    [TestMethod]
    public void TestCheckFor4UpwardDiagonal()
    {
        //Arange
        var connectFour = new ConnectFour();
        connectFour.InitGame();
        //Act
            connectFour.SetInput(0);
            var offset = 1;
        for (int i = 1; i < 4; i++)
        {

            connectFour.SwitchPlayer();
            for (int j = 0; j < offset; j++)
            {
                connectFour.SetInput(i);
            }
            connectFour.SwitchPlayer();
            connectFour.SetInput(i);
            offset++;
        }
        
        //Assert
        Assert.IsTrue(connectFour.CheckFor4());
    }

    [TestMethod]
    public void TestCheckFor4DownwardDiagonal()
    {
        //Arange
        var connectFour = new ConnectFour();
        connectFour.InitGame();
        //Act
        var offset = 3;
        for (int i = 0; i < 3; i++)
        {

            connectFour.SwitchPlayer();
            for (int j = 0; j < offset; j++)
            {
                connectFour.SetInput(i);
            }
            connectFour.SwitchPlayer();
            connectFour.SetInput(i);
            offset--;
        }
        connectFour.SetInput(3);
        //Assert
        Assert.IsTrue(connectFour.CheckFor4());
    }


}