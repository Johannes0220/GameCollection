namespace GameCollection.Games.VierGewinnt;

public class ConnectFourRandomBot : IConnectFourBot
{
    public int getMove(IBoard board, int move)
    {
        int[] moves = Enumerable.Range(0, board.width).Where(column => !board.board[column, board.height - 1].HasValue).ToArray();
        return moves[Random.Shared.Next(moves.Length)];
        
    }
}