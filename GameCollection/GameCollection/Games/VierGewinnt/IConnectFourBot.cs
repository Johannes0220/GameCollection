namespace GameCollection.Games.VierGewinnt;

public interface IConnectFourBot
{
    int getMove(Board board, int move);
}