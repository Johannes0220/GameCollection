namespace GameCollection.Games.VierGewinnt;

public class ConnectFourDifficultyChooser
{
    private ConnectFourView _connectFourView;

    public ConnectFourDifficultyChooser(ConnectFourView connectFourView) 
    {
        _connectFourView = connectFourView;
    }

    public IConnectFourBot GetDifficulty()
    {
        var difficulty = _connectFourView.GetDifficulty();
        if (difficulty.Equals(0))
        {
            return new ConnectFourRandomBot();
        }
        else
        {
            return  new ConnectFourBlockBot();
        }
    }
}