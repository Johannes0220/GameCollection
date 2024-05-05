namespace GameCollection.Games.VierGewinnt;

public interface IBoard
{
    bool?[,] board { get; set; }
    int height { get; set; }
    int width { get; set; }
    void InitBoard();
    void DropPiece(int column, bool player);
    void RemovePiece(int column);
    bool IsColumnFull(int column);
    int GetFillStateColumn(int column);
}