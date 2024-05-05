namespace GameCollection.Games.VierGewinnt;

public interface IConnectFourBot
{
    int getMove(IBoard board, int move);
}