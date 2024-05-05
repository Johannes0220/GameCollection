namespace GameCollection.Games;

public interface IWinGameResult: IGameResult
{
    bool Result { get; }
}