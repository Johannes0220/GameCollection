namespace GameCollection.Games.VierGewinnt;

public interface IConnectFourBot
{
    int getMove(bool?[,] board);
}