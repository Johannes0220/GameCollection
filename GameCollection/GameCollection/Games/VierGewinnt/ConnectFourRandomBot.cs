namespace GameCollection.Games.VierGewinnt;

public class ConnectFourRandomBot : IConnectFourBot
{
    public int getMove(bool?[,] board)
    {
        (int, int) move;
        int[] moves = Enumerable.Range(0, board.GetLength(0)).Where(i => !board[i, board.GetLength(1) - 1].HasValue).ToArray();
        return moves[Random.Shared.Next(moves.Length)];
        
    }
}