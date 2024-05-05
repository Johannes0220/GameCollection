namespace GameCollection.Games;

public class WinGameResult : IWinGameResult
{
    public WinGameResult(bool result)
    {
        Result = result;
    }
    public bool Result { get; }
}